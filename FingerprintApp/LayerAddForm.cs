using OpenCvSharp;

namespace FingerprintApp
{
    public partial class LayerAddForm : Form
    {
        private ProcessingLayerManager? processingLayerManager;
        public ProcessingLayer CurrentProcessingLayer { get; private set; }

        public LayerAddForm()
        {
            InitializeComponent();
            processingLayerManager = ProcessingLayerManager.Instance;
            PopulateLayers();
        }

        public void PopulateLayers()
        {
            comboBoxLayerTypes.Items.AddRange(processingLayerManager?.AllProcessingLayerNames.ToArray() ?? Array.Empty<string>());
            comboBoxLayerTypes.SelectedIndex = 0;
        }


        private void comboBoxLayerTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            if (processingLayerManager != null && comboBoxLayerTypes.SelectedItem != null)
            {
                string layerName = comboBoxLayerTypes.SelectedItem?.ToString() ?? "Null";
                ProcessingLayer layer = processingLayerManager.GetLayerFromString(layerName);
                Control options = layer.GetOptionsControl();
                splitContainer1.Panel2.Controls.Add(options);
                CurrentProcessingLayer = layer;
            }
            else
            {
                MessageBox.Show("Unable to load ProcessingLayerManager");
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

    public class ProcessingLayerManager
    {
        public static ProcessingLayerManager? Instance;

        public List<String> AllProcessingLayerNames { get; private set; }
        public List<ProcessingLayer> ProcessingLayers { get; set; }

        public ProcessingLayerManager()
        {
            Instance = this;

            AllProcessingLayerNames = new List<String> {
                "GaussianBlur", 
                "GaussianBinarize", 
                "Invert",
                "Threshold",
                //"Gabor", // TODO
            };

            ProcessingLayers = new List<ProcessingLayer>()
            {
                new GaussianBinarizeLayer() { KernelSize = 57, Sigma = 0 },
                new GaussianBlurLayer() { KernelSize = 17, Sigma = 0 },
                new GaussianBinarizeLayer() { KernelSize = 29, Sigma = 0 },
                new GaussianBlurLayer() { KernelSize = 7, Sigma = 0 },
                new ThresholdLayer() { Threshold = 127 },
            };
        }
        

        public ProcessingLayer GetLayerFromString(String layerType)
        {
            switch (layerType)
            {
                case "GaussianBlur":
                    return new GaussianBlurLayer();
                case "GaussianBinarize":
                    return new GaussianBinarizeLayer();
                case "Invert":
                    return new InvertLayer();
                case "Threshold":
                    return new ThresholdLayer();
                default:
                    return new GaussianBlurLayer();
            }
        }

        public void ProcessAllLayers(Mat mat, out Mat result)
        {
            result = new Mat(mat.Size(), MatType.CV_8U);
            Cv2.CopyTo(mat, result);
            foreach (ProcessingLayer layer in ProcessingLayers)
            { 
                layer.ProcessMatrix(result, out result);
            }
        }
    }
}
