using OpenCvSharp;

namespace FingerprintApp
{
    public abstract class ProcessingLayer
    {
        public abstract string Name { get; }
        public abstract Control GetOptionsControl();
        public abstract void ProcessMatrix(Mat mat, out Mat result);
    }

    public class GaussianBlurLayer : ProcessingLayer
    {
        public int KernelSize { get; set; }
        public double Sigma { get; set; }

        public GaussianBlurLayer()
        {
            KernelSize = 3; 
            Sigma = 0.0;
        }

        public override string Name => "GaussianBlur";

        public override Control GetOptionsControl()
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,  
                RowCount = 2, 
                ColumnCount = 2, 
                AutoSize = true,  
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(10),  
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single 
            };

            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize)); 
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize)); 
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50)); 
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50)); 

            Label lblKernelSize = new Label { Text = "Kernel Size", TextAlign = System.Drawing.ContentAlignment.MiddleLeft, Dock = DockStyle.Top, AutoSize = true };
            NumericUpDown numKernelSize = new NumericUpDown { Minimum = 1, Maximum = 100, Increment = 2, Value = KernelSize, Dock = DockStyle.Top, AutoSize = true };
            Label lblSigma = new Label { Text = "Sigma", TextAlign = System.Drawing.ContentAlignment.MiddleLeft, Dock = DockStyle.Top , AutoSize = true };
            NumericUpDown numSigma = new NumericUpDown { Minimum = 0, Maximum = 100, DecimalPlaces = 1, Value = (decimal)Sigma, Dock = DockStyle.Top , AutoSize = true };

            numKernelSize.ValueChanged += (s, e) => { KernelSize = (int) numKernelSize.Value; };
            numSigma.ValueChanged += (s, e) => { Sigma = (double) numSigma.Value; };

            tableLayoutPanel.Controls.Add(lblKernelSize, 0, 0); 
            tableLayoutPanel.Controls.Add(numKernelSize, 1, 0);
            tableLayoutPanel.Controls.Add(lblSigma, 0, 1); 
            tableLayoutPanel.Controls.Add(numSigma, 1, 1); 

            numKernelSize.TextAlign = HorizontalAlignment.Center; 
            numSigma.TextAlign = HorizontalAlignment.Center;

            return tableLayoutPanel;
        }

        public override void ProcessMatrix(Mat mat, out Mat result)
        {
            result = new Mat(mat.Size(), MatType.CV_8U);
            Cv2.GaussianBlur(mat, result, new OpenCvSharp.Size(KernelSize, KernelSize), Sigma);
        }

    }
    public class GaussianBinarizeLayer : ProcessingLayer
    {
        public int KernelSize { get; set; }
        public double Sigma { get; set; }

        public GaussianBinarizeLayer()
        {
            KernelSize = 3; 
            Sigma = 0.0;
        }

        public override string Name => "GaussianBinarize";

        public override Control GetOptionsControl()
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 2, 
                AutoSize = true, 
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(10),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };

            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50)); 
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50)); 

            Label lblKernelSize = new Label { Text = "Kernel Size", TextAlign = ContentAlignment.MiddleLeft, Dock = DockStyle.Top, AutoSize = true };
            NumericUpDown numKernelSize = new NumericUpDown { Minimum = 1, Maximum = 100, Increment = 2, Value = KernelSize, Dock = DockStyle.Top, AutoSize = true };
            Label lblSigma = new Label { Text = "Sigma", TextAlign = ContentAlignment.MiddleLeft, Dock = DockStyle.Top, AutoSize = true };
            NumericUpDown numSigma = new NumericUpDown { Minimum = 0, Maximum = 100, DecimalPlaces = 1, Value = (decimal)Sigma, Dock = DockStyle.Top, AutoSize = true };

            numKernelSize.ValueChanged += (s, e) => { KernelSize = (int)numKernelSize.Value; };
            numSigma.ValueChanged += (s, e) => { Sigma = (double)numSigma.Value; };

            tableLayoutPanel.Controls.Add(lblKernelSize, 0, 0); 
            tableLayoutPanel.Controls.Add(numKernelSize, 1, 0);  
            tableLayoutPanel.Controls.Add(lblSigma, 0, 1); 
            tableLayoutPanel.Controls.Add(numSigma, 1, 1); 
            numKernelSize.TextAlign = HorizontalAlignment.Center;
            numSigma.TextAlign = HorizontalAlignment.Center;

            return tableLayoutPanel;
        }

        public override void ProcessMatrix(Mat mat, out Mat result)
        {
            result = new Mat(mat.Size(), MatType.CV_8U);
            Cv2.GaussianBlur(mat, result, new OpenCvSharp.Size(KernelSize, KernelSize), Sigma);
            Cv2.Compare(mat, result, result, CmpType.GE);
        }

    }

    public class InvertLayer : ProcessingLayer
    {
        public override string Name => "Invert";

        public override Control GetOptionsControl()
        {
            TableLayoutPanel tableLayoutPanel = new();
            return tableLayoutPanel;
        }

        public override void ProcessMatrix(Mat mat, out Mat result)
        {
            result = new Mat(mat.Size(), MatType.CV_8U);
            Cv2.BitwiseNot(mat, result);
        }
    }

    public class ThresholdLayer : ProcessingLayer
    {
        public int Threshold { get; set; }

        public ThresholdLayer()
        {
            Threshold = 127;
        }

        public override string Name => "Threshold";

        public override Control GetOptionsControl()
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill, 
                RowCount = 1,
                ColumnCount = 2,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(10), 
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };

            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            Label lblThreshold = new Label { Text = "Threshold (0-256)", TextAlign = ContentAlignment.MiddleLeft, Dock = DockStyle.Top, AutoSize = true };
            NumericUpDown numThreshold = new NumericUpDown { Minimum = 0, Maximum = 256, Increment = 1, Value = Threshold,Dock = DockStyle.Top, AutoSize = true };
            numThreshold.ValueChanged += (s, e) => { Threshold = (int)numThreshold.Value; };

            tableLayoutPanel.Controls.Add(lblThreshold, 0, 0);
            tableLayoutPanel.Controls.Add(numThreshold, 1, 0);
            numThreshold.TextAlign = HorizontalAlignment.Center;

            return tableLayoutPanel;
        }

        public override void ProcessMatrix(Mat mat, out Mat result)
        {
            result = new Mat(mat.Size(), MatType.CV_8U);
            Cv2.Threshold(mat, result, Threshold, 256, ThresholdTypes.Binary);
        }

    }

    // TODO: Convert gabor function into a layer with params Sigma, NumOrientations, Wavelength, Gamma, and Psi
    /* 
        private void Gabor(Mat mat, out Mat smoothRidges)
        {
            smoothRidges = new Mat(mat.Size(), MatType.CV_32F);

            int numAngles = 16;
            double deltaTheta = Math.PI / numAngles; // Angle step size
            Mat maxResponse = new Mat(mat.Size(), MatType.CV_32F);

            for (int i = 0; i < numAngles; i++)
            {
                double currentTheta = i * deltaTheta;
                Mat gaborKernel = Cv2.GetGaborKernel(new OpenCvSharp.Size(gaborSize, gaborSize), sigma, currentTheta, wavelength, gamma, psi, MatType.CV_64F);
                Mat response = new Mat();
                Cv2.Filter2D(mat, response, MatType.CV_32F, gaborKernel);
                Cv2.Max(smoothRidges, response, smoothRidges);
            }
            smoothRidges.ConvertTo(smoothRidges, MatType.CV_8U);
        }
        */

}
