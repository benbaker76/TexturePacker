namespace TexturePacker
{
    partial class frmSpriteSlicer
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSpriteSlicer));
			this.grpOutputSize = new System.Windows.Forms.GroupBox();
			this.chkUseTrimSize = new System.Windows.Forms.CheckBox();
			this.chkAutoTrim = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.outputHeight = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.outputWidth = new System.Windows.Forms.TextBox();
			this.grpInputSize = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.inputHeight = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.inputWidth = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.grpMarginSize = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.marginHeight = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.marginWidth = new System.Windows.Forms.TextBox();
			this.grpSpacingSize = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.spacingHeight = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.spacingWidth = new System.Windows.Forms.TextBox();
			this.grpOutputSize.SuspendLayout();
			this.grpInputSize.SuspendLayout();
			this.grpMarginSize.SuspendLayout();
			this.grpSpacingSize.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpOutputSize
			// 
			this.grpOutputSize.Controls.Add(this.label3);
			this.grpOutputSize.Controls.Add(this.outputHeight);
			this.grpOutputSize.Controls.Add(this.label4);
			this.grpOutputSize.Controls.Add(this.outputWidth);
			this.grpOutputSize.Location = new System.Drawing.Point(12, 109);
			this.grpOutputSize.Name = "grpOutputSize";
			this.grpOutputSize.Size = new System.Drawing.Size(192, 91);
			this.grpOutputSize.TabIndex = 9;
			this.grpOutputSize.TabStop = false;
			this.grpOutputSize.Text = "Output Size";
			// 
			// chkUseTrimSize
			// 
			this.chkUseTrimSize.AutoSize = true;
			this.chkUseTrimSize.Location = new System.Drawing.Point(34, 230);
			this.chkUseTrimSize.Name = "chkUseTrimSize";
			this.chkUseTrimSize.Size = new System.Drawing.Size(91, 17);
			this.chkUseTrimSize.TabIndex = 6;
			this.chkUseTrimSize.Text = "Use Trim Size";
			this.chkUseTrimSize.UseVisualStyleBackColor = true;
			// 
			// chkAutoTrim
			// 
			this.chkAutoTrim.AutoSize = true;
			this.chkAutoTrim.Location = new System.Drawing.Point(34, 208);
			this.chkAutoTrim.Name = "chkAutoTrim";
			this.chkAutoTrim.Size = new System.Drawing.Size(101, 17);
			this.chkAutoTrim.TabIndex = 5;
			this.chkAutoTrim.Text = "Auto Trim Alpha";
			this.chkAutoTrim.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(18, 53);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Height:";
			// 
			// outputHeight
			// 
			this.outputHeight.Location = new System.Drawing.Point(80, 50);
			this.outputHeight.Name = "outputHeight";
			this.outputHeight.Size = new System.Drawing.Size(94, 20);
			this.outputHeight.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(18, 27);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Width:";
			// 
			// outputWidth
			// 
			this.outputWidth.Location = new System.Drawing.Point(80, 24);
			this.outputWidth.Name = "outputWidth";
			this.outputWidth.Size = new System.Drawing.Size(94, 20);
			this.outputWidth.TabIndex = 1;
			// 
			// grpInputSize
			// 
			this.grpInputSize.Controls.Add(this.label2);
			this.grpInputSize.Controls.Add(this.inputHeight);
			this.grpInputSize.Controls.Add(this.label1);
			this.grpInputSize.Controls.Add(this.inputWidth);
			this.grpInputSize.Location = new System.Drawing.Point(12, 12);
			this.grpInputSize.Name = "grpInputSize";
			this.grpInputSize.Size = new System.Drawing.Size(192, 91);
			this.grpInputSize.TabIndex = 8;
			this.grpInputSize.TabStop = false;
			this.grpInputSize.Text = "Input Size";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Height:";
			// 
			// inputHeight
			// 
			this.inputHeight.Location = new System.Drawing.Point(80, 50);
			this.inputHeight.Name = "inputHeight";
			this.inputHeight.Size = new System.Drawing.Size(94, 20);
			this.inputHeight.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Width:";
			// 
			// inputWidth
			// 
			this.inputWidth.Location = new System.Drawing.Point(80, 24);
			this.inputWidth.Name = "inputWidth";
			this.inputWidth.Size = new System.Drawing.Size(94, 20);
			this.inputWidth.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(143, 259);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(140, 32);
			this.button1.TabIndex = 7;
			this.button1.Text = "GO!";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// grpMarginSize
			// 
			this.grpMarginSize.Controls.Add(this.label5);
			this.grpMarginSize.Controls.Add(this.marginHeight);
			this.grpMarginSize.Controls.Add(this.label6);
			this.grpMarginSize.Controls.Add(this.marginWidth);
			this.grpMarginSize.Location = new System.Drawing.Point(210, 12);
			this.grpMarginSize.Name = "grpMarginSize";
			this.grpMarginSize.Size = new System.Drawing.Size(192, 91);
			this.grpMarginSize.TabIndex = 9;
			this.grpMarginSize.TabStop = false;
			this.grpMarginSize.Text = "Margin Size";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(18, 53);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(41, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Height:";
			// 
			// marginHeight
			// 
			this.marginHeight.Location = new System.Drawing.Point(80, 50);
			this.marginHeight.Name = "marginHeight";
			this.marginHeight.Size = new System.Drawing.Size(94, 20);
			this.marginHeight.TabIndex = 3;
			this.marginHeight.Text = "0";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(18, 27);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(38, 13);
			this.label6.TabIndex = 2;
			this.label6.Text = "Width:";
			// 
			// marginWidth
			// 
			this.marginWidth.Location = new System.Drawing.Point(80, 24);
			this.marginWidth.Name = "marginWidth";
			this.marginWidth.Size = new System.Drawing.Size(94, 20);
			this.marginWidth.TabIndex = 1;
			this.marginWidth.Text = "0";
			// 
			// grpSpacingSize
			// 
			this.grpSpacingSize.Controls.Add(this.label7);
			this.grpSpacingSize.Controls.Add(this.spacingHeight);
			this.grpSpacingSize.Controls.Add(this.label8);
			this.grpSpacingSize.Controls.Add(this.spacingWidth);
			this.grpSpacingSize.Location = new System.Drawing.Point(211, 109);
			this.grpSpacingSize.Name = "grpSpacingSize";
			this.grpSpacingSize.Size = new System.Drawing.Size(192, 91);
			this.grpSpacingSize.TabIndex = 9;
			this.grpSpacingSize.TabStop = false;
			this.grpSpacingSize.Text = "Spacing Size";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(18, 53);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(41, 13);
			this.label7.TabIndex = 4;
			this.label7.Text = "Height:";
			// 
			// spacingHeight
			// 
			this.spacingHeight.Location = new System.Drawing.Point(80, 50);
			this.spacingHeight.Name = "spacingHeight";
			this.spacingHeight.Size = new System.Drawing.Size(94, 20);
			this.spacingHeight.TabIndex = 3;
			this.spacingHeight.Text = "0";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(18, 27);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(38, 13);
			this.label8.TabIndex = 2;
			this.label8.Text = "Width:";
			// 
			// spacingWidth
			// 
			this.spacingWidth.Location = new System.Drawing.Point(80, 24);
			this.spacingWidth.Name = "spacingWidth";
			this.spacingWidth.Size = new System.Drawing.Size(94, 20);
			this.spacingWidth.TabIndex = 1;
			this.spacingWidth.Text = "0";
			// 
			// frmSpriteSlicer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(415, 303);
			this.Controls.Add(this.chkAutoTrim);
			this.Controls.Add(this.chkUseTrimSize);
			this.Controls.Add(this.grpSpacingSize);
			this.Controls.Add(this.grpMarginSize);
			this.Controls.Add(this.grpOutputSize);
			this.Controls.Add(this.grpInputSize);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmSpriteSlicer";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Sprite Sheet Slicer";
			this.grpOutputSize.ResumeLayout(false);
			this.grpOutputSize.PerformLayout();
			this.grpInputSize.ResumeLayout(false);
			this.grpInputSize.PerformLayout();
			this.grpMarginSize.ResumeLayout(false);
			this.grpMarginSize.PerformLayout();
			this.grpSpacingSize.ResumeLayout(false);
			this.grpSpacingSize.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpOutputSize;
        private System.Windows.Forms.CheckBox chkUseTrimSize;
        private System.Windows.Forms.CheckBox chkAutoTrim;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox outputHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox outputWidth;
        private System.Windows.Forms.GroupBox grpInputSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputWidth;
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox grpMarginSize;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox marginHeight;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox marginWidth;
		private System.Windows.Forms.GroupBox grpSpacingSize;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox spacingHeight;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox spacingWidth;
    }
}