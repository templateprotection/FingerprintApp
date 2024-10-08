namespace FingerprintApp
{
    partial class LayerAddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            buttonOk = new Button();
            comboBoxLayerTypes = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(buttonOk);
            splitContainer1.Panel1.Controls.Add(comboBoxLayerTypes);
            splitContainer1.Size = new Size(753, 454);
            splitContainer1.SplitterDistance = 368;
            splitContainer1.TabIndex = 0;
            // 
            // buttonOk
            // 
            buttonOk.Location = new Point(12, 369);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(343, 73);
            buttonOk.TabIndex = 1;
            buttonOk.Text = "OK";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // comboBoxLayerTypes
            // 
            comboBoxLayerTypes.Dock = DockStyle.Fill;
            comboBoxLayerTypes.FormattingEnabled = true;
            comboBoxLayerTypes.Location = new Point(0, 0);
            comboBoxLayerTypes.Name = "comboBoxLayerTypes";
            comboBoxLayerTypes.Size = new Size(368, 49);
            comboBoxLayerTypes.TabIndex = 0;
            comboBoxLayerTypes.SelectedIndexChanged += comboBoxLayerTypes_SelectedIndexChanged;
            // 
            // LayerAddForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(753, 454);
            Controls.Add(splitContainer1);
            Name = "LayerAddForm";
            Text = "LayerAddForm";
            splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private ComboBox comboBoxLayerTypes;
        private Button buttonOk;
    }
}