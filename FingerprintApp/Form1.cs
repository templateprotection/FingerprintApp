using OpenCvSharp;
using OpenCvSharp.Extensions;



namespace FingerprintApp
{
    public partial class Form1 : Form
    {
        private Bitmap originalBitmap;
        private Bitmap minutiaeBitmap;
        private int rotationAngle = 0;
        
        private ProcessingLayerManager processingLayerManager;


        public Form1()
        {
            InitializeComponent();
            processingLayerManager = new ProcessingLayerManager();
            originalBitmap = new Mat(new OpenCvSharp.Size(1, 1), MatType.CV_8U).ToBitmap();
            minutiaeBitmap = new Mat(new OpenCvSharp.Size(1, 1), MatType.CV_8U).ToBitmap();
            UpdateLayerList();
        }

        

        private void MorphologicalSkeleton(Mat img, out Mat skel) // TODO: Possibly move this to a ProcessingLayer
        {
            skel = Mat.Zeros(img.Size(), MatType.CV_8UC1);
            Mat temp = new Mat();
            Mat element = Cv2.GetStructuringElement(MorphShapes.Cross, new OpenCvSharp.Size(3, 3));

            bool done = false;
            do
            {
                Mat opened = new Mat();
                Cv2.MorphologyEx(img, opened, MorphTypes.Open, element);
                Cv2.BitwiseNot(opened, temp);
                Cv2.BitwiseAnd(img, temp, temp);
                Cv2.BitwiseOr(skel, temp, skel);
                Cv2.Erode(img, img, element);
                double maxVal;
                Cv2.MinMaxLoc(img, out _, out maxVal);
                done = (maxVal == 0);

            } while (!done);
        }

        private void UpdateLayerList()
        {
            listBoxLayers.Items.Clear();
            listBoxLayers.Items.AddRange(processingLayerManager.ProcessingLayers.Select(p => p.Name).ToArray());
        }


        private void UpdateMinutiaePicture()
        {
            Bitmap originalBitmap = (Bitmap)pictureBoxOriginal.Image;
            if (originalBitmap == null)
                return;

            Mat originalMat = BitmapConverter.ToMat(originalBitmap);
            Mat grayMat = new Mat();
            if (originalMat.Channels() > 1)
                Cv2.CvtColor(originalMat, grayMat, ColorConversionCodes.BGR2GRAY);
            else
                Cv2.CopyTo(originalMat, grayMat);

            Mat binaryMat = new Mat(grayMat.Size(), MatType.CV_8U);
            processingLayerManager.ProcessAllLayers(grayMat, out binaryMat);
            
            if (checkBoxSkeletonize.Checked)
            {
                Mat skeletonMat = new Mat(binaryMat.Size(), MatType.CV_8UC1, new Scalar(0));
                MorphologicalSkeleton(binaryMat, out skeletonMat);
                Bitmap skeletonPic = BitmapConverter.ToBitmap(skeletonMat);
                pictureBoxMinutiae.Image = skeletonPic;
            }
            else
            {
                Bitmap binaryPic = BitmapConverter.ToBitmap(binaryMat);
                pictureBoxMinutiae.Image = binaryPic;
            }
        }

        private void UpdateOriginalPicture()
        {
            if (originalBitmap == null)
                return;

            Mat originalMat = BitmapConverter.ToMat(originalBitmap);
            Point2f center = new Point2f(originalMat.Width / 2f, originalMat.Height / 2f);
            Mat rotationMatrix = Cv2.GetRotationMatrix2D(center, rotationAngle, 1.0);
            Mat rotatedMat = new Mat();
            Cv2.WarpAffine(originalMat, rotatedMat, rotationMatrix, originalMat.Size());
            Bitmap rotatedPic = BitmapConverter.ToBitmap(rotatedMat);
            pictureBoxOriginal.Image = rotatedPic;
        }


        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.tif",
                Title = "Select an Image"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                Image img = Image.FromFile(filePath);
                Mat mat = ((Bitmap)img).ToMat();
                Cv2.Resize(mat, mat, new OpenCvSharp.Size(700, 850));
                originalBitmap = mat.ToBitmap();
                UpdateOriginalPicture();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            UpdateMinutiaePicture();
        }

        private void checkBoxSkeletonize_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMinutiaePicture();
        }
        

        private void buttonSaveImage_Click(object sender, EventArgs e)
        {
            if (pictureBoxMinutiae.Image != null)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                    saveFileDialog.Title = "Save Image";
                    saveFileDialog.FileName = "MinutiaeImage";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        pictureBoxMinutiae.Image.Save(saveFileDialog.FileName);
                    }
                }
            }
            else
            {
                MessageBox.Show("No image to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void listBoxLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBoxLayers.SelectedIndex;

            splitContainerLayers.Panel2.Controls.Clear();
            if (processingLayerManager != null && selectedIndex >= 0)
            {
                int layerIndex = Math.Max(selectedIndex, 0);
                ProcessingLayer layer = processingLayerManager.ProcessingLayers[layerIndex];
                Control options = layer.GetOptionsControl();
                splitContainerLayers.Panel2.Controls.Add(options);
            }
        }

        private void buttonAddLayer_Click(object sender, EventArgs e)
        {
            LayerAddForm addLayerForm = new LayerAddForm();
            int selectedIndex = listBoxLayers.SelectedIndex;
            int numLayers = processingLayerManager.ProcessingLayers.Count;
            int insertIndex = selectedIndex >= 0 ? selectedIndex + 1 : numLayers;

            if (addLayerForm.ShowDialog() == DialogResult.OK)
            {
                ProcessingLayer layer = addLayerForm.CurrentProcessingLayer;
                processingLayerManager.ProcessingLayers.Insert(insertIndex, layer);
                addLayerForm.Close();
            }
            UpdateLayerList();
        }

        private void buttonRemoveLayer_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxLayers.SelectedIndex;
            if (selectedIndex >= 0)
            {
                processingLayerManager.ProcessingLayers.RemoveAt(selectedIndex);
                UpdateLayerList();
            }
            else
            {
                MessageBox.Show("No layer selected");
            }
        }

        private void sliderRotation_Scroll(object sender, EventArgs e)
        {
            textBoxRotation.Text = sliderRotation.Value.ToString();
            rotationAngle = sliderRotation.Value;
            UpdateOriginalPicture();
        }
    }
}
