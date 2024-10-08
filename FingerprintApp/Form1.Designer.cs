namespace FingerprintApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBoxMinutiae = new PictureBox();
            pictureBoxOriginal = new PictureBox();
            buttonLoadImage = new Button();
            buttonSaveImage = new Button();
            openFileDialog1 = new OpenFileDialog();
            openFileDialog2 = new OpenFileDialog();
            buttonUpdate = new Button();
            splitContainer1 = new SplitContainer();
            textBoxRotation = new TextBox();
            labelRotation = new Label();
            sliderRotation = new TrackBar();
            buttonRemoveLayer = new Button();
            buttonAddLayer = new Button();
            splitContainerLayers = new SplitContainer();
            listBoxLayers = new ListBox();
            checkBoxSkeletonize = new CheckBox();
            splitContainer2 = new SplitContainer();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMinutiae).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sliderRotation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerLayers).BeginInit();
            splitContainerLayers.Panel1.SuspendLayout();
            splitContainerLayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxMinutiae
            // 
            pictureBoxMinutiae.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxMinutiae.Dock = DockStyle.Fill;
            pictureBoxMinutiae.Location = new Point(0, 0);
            pictureBoxMinutiae.Name = "pictureBoxMinutiae";
            pictureBoxMinutiae.Size = new Size(527, 736);
            pictureBoxMinutiae.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxMinutiae.TabIndex = 0;
            pictureBoxMinutiae.TabStop = false;
            // 
            // pictureBoxOriginal
            // 
            pictureBoxOriginal.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxOriginal.Dock = DockStyle.Fill;
            pictureBoxOriginal.Location = new Point(0, 0);
            pictureBoxOriginal.Name = "pictureBoxOriginal";
            pictureBoxOriginal.Size = new Size(544, 736);
            pictureBoxOriginal.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxOriginal.TabIndex = 1;
            pictureBoxOriginal.TabStop = false;
            // 
            // buttonLoadImage
            // 
            buttonLoadImage.Location = new Point(33, 40);
            buttonLoadImage.Name = "buttonLoadImage";
            buttonLoadImage.Size = new Size(240, 58);
            buttonLoadImage.TabIndex = 2;
            buttonLoadImage.Text = "Load Image";
            buttonLoadImage.UseVisualStyleBackColor = true;
            buttonLoadImage.Click += buttonLoadImage_Click;
            // 
            // buttonSaveImage
            // 
            buttonSaveImage.Location = new Point(320, 40);
            buttonSaveImage.Name = "buttonSaveImage";
            buttonSaveImage.Size = new Size(240, 58);
            buttonSaveImage.TabIndex = 3;
            buttonSaveImage.Text = "Save Image";
            buttonSaveImage.UseVisualStyleBackColor = true;
            buttonSaveImage.Click += buttonSaveImage_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(287, 591);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(273, 124);
            buttonUpdate.TabIndex = 7;
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(textBoxRotation);
            splitContainer1.Panel1.Controls.Add(labelRotation);
            splitContainer1.Panel1.Controls.Add(sliderRotation);
            splitContainer1.Panel1.Controls.Add(buttonRemoveLayer);
            splitContainer1.Panel1.Controls.Add(buttonAddLayer);
            splitContainer1.Panel1.Controls.Add(splitContainerLayers);
            splitContainer1.Panel1.Controls.Add(checkBoxSkeletonize);
            splitContainer1.Panel1.Controls.Add(buttonLoadImage);
            splitContainer1.Panel1.Controls.Add(buttonSaveImage);
            splitContainer1.Panel1.Controls.Add(buttonUpdate);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1682, 736);
            splitContainer1.SplitterDistance = 603;
            splitContainer1.TabIndex = 8;
            // 
            // textBoxRotation
            // 
            textBoxRotation.Location = new Point(320, 189);
            textBoxRotation.Name = "textBoxRotation";
            textBoxRotation.ReadOnly = true;
            textBoxRotation.Size = new Size(109, 47);
            textBoxRotation.TabIndex = 19;
            // 
            // labelRotation
            // 
            labelRotation.AutoSize = true;
            labelRotation.Location = new Point(98, 189);
            labelRotation.Name = "labelRotation";
            labelRotation.Size = new Size(218, 41);
            labelRotation.TabIndex = 18;
            labelRotation.Text = "Rotation (Deg):";
            // 
            // sliderRotation
            // 
            sliderRotation.Location = new Point(33, 119);
            sliderRotation.Maximum = 15;
            sliderRotation.Minimum = -15;
            sliderRotation.Name = "sliderRotation";
            sliderRotation.Size = new Size(527, 114);
            sliderRotation.TabIndex = 17;
            sliderRotation.Scroll += sliderRotation_Scroll;
            // 
            // buttonRemoveLayer
            // 
            buttonRemoveLayer.Location = new Point(156, 591);
            buttonRemoveLayer.Name = "buttonRemoveLayer";
            buttonRemoveLayer.Size = new Size(111, 60);
            buttonRemoveLayer.TabIndex = 16;
            buttonRemoveLayer.Text = "DEL";
            buttonRemoveLayer.UseVisualStyleBackColor = true;
            buttonRemoveLayer.Click += buttonRemoveLayer_Click;
            // 
            // buttonAddLayer
            // 
            buttonAddLayer.Location = new Point(33, 591);
            buttonAddLayer.Name = "buttonAddLayer";
            buttonAddLayer.Size = new Size(111, 60);
            buttonAddLayer.TabIndex = 15;
            buttonAddLayer.Text = "ADD";
            buttonAddLayer.UseVisualStyleBackColor = true;
            buttonAddLayer.Click += buttonAddLayer_Click;
            // 
            // splitContainerLayers
            // 
            splitContainerLayers.Location = new Point(33, 325);
            splitContainerLayers.Name = "splitContainerLayers";
            // 
            // splitContainerLayers.Panel1
            // 
            splitContainerLayers.Panel1.Controls.Add(listBoxLayers);
            splitContainerLayers.Size = new Size(527, 250);
            splitContainerLayers.SplitterDistance = 240;
            splitContainerLayers.TabIndex = 14;
            // 
            // listBoxLayers
            // 
            listBoxLayers.Dock = DockStyle.Fill;
            listBoxLayers.FormattingEnabled = true;
            listBoxLayers.ItemHeight = 41;
            listBoxLayers.Location = new Point(0, 0);
            listBoxLayers.Name = "listBoxLayers";
            listBoxLayers.Size = new Size(240, 250);
            listBoxLayers.TabIndex = 0;
            listBoxLayers.SelectedIndexChanged += listBoxLayers_SelectedIndexChanged;
            // 
            // checkBoxSkeletonize
            // 
            checkBoxSkeletonize.AutoSize = true;
            checkBoxSkeletonize.Location = new Point(48, 670);
            checkBoxSkeletonize.Name = "checkBoxSkeletonize";
            checkBoxSkeletonize.Size = new Size(208, 45);
            checkBoxSkeletonize.TabIndex = 9;
            checkBoxSkeletonize.Text = "Skeletonize";
            checkBoxSkeletonize.UseVisualStyleBackColor = true;
            checkBoxSkeletonize.CheckedChanged += checkBoxSkeletonize_CheckedChanged;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(pictureBoxOriginal);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(pictureBoxMinutiae);
            splitContainer2.Size = new Size(1075, 736);
            splitContainer2.SplitterDistance = 544;
            splitContainer2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 281);
            label1.Name = "label1";
            label1.Size = new Size(252, 41);
            label1.TabIndex = 20;
            label1.Text = "Processing Layers";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1682, 736);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Fingerprint Extraction Tool";
            ((System.ComponentModel.ISupportInitialize)pictureBoxMinutiae).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sliderRotation).EndInit();
            splitContainerLayers.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerLayers).EndInit();
            splitContainerLayers.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxMinutiae;
        private PictureBox pictureBoxOriginal;
        private Button buttonLoadImage;
        private Button buttonSaveImage;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private Button buttonUpdate;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private CheckBox checkBoxSkeletonize;
        private SplitContainer splitContainerLayers;
        private ListBox listBoxLayers;
        private Button buttonRemoveLayer;
        private Button buttonAddLayer;
        private TextBox textBoxRotation;
        private Label labelRotation;
        private TrackBar sliderRotation;
        private Label label1;
    }
}
