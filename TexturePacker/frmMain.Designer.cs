namespace TexturePacker
{
    partial class frmMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.grpFolders = new System.Windows.Forms.GroupBox();
			this.cboFolder = new System.Windows.Forms.ComboBox();
			this.txtSearchExt = new System.Windows.Forms.TextBox();
			this.lblSearchExt = new System.Windows.Forms.Label();
			this.chkRecursive = new System.Windows.Forms.CheckBox();
			this.butFolder = new System.Windows.Forms.Button();
			this.txtFolder = new System.Windows.Forms.TextBox();
			this.grpTextureOptions = new System.Windows.Forms.GroupBox();
			this.chkFillSpacing = new System.Windows.Forms.CheckBox();
			this.chkMultiTexture = new System.Windows.Forms.CheckBox();
			this.butColor = new System.Windows.Forms.Button();
			this.rdoColor = new System.Windows.Forms.RadioButton();
			this.rdoAlpha = new System.Windows.Forms.RadioButton();
			this.lblBackground = new System.Windows.Forms.Label();
			this.lblSpacing = new System.Windows.Forms.Label();
			this.txtSpacing = new System.Windows.Forms.TextBox();
			this.lblTextureHeight = new System.Windows.Forms.Label();
			this.txtTextureHeight = new System.Windows.Forms.TextBox();
			this.lblTextureWidth = new System.Windows.Forms.Label();
			this.txtTextureWidth = new System.Windows.Forms.TextBox();
			this.butGo = new System.Windows.Forms.Button();
			this.grpImageOptions = new System.Windows.Forms.GroupBox();
			this.lblFilter = new System.Windows.Forms.Label();
			this.chkNearestPower2 = new System.Windows.Forms.CheckBox();
			this.rdoBilinear = new System.Windows.Forms.RadioButton();
			this.rdoNearestNeighbor = new System.Windows.Forms.RadioButton();
			this.chkKeepAspect = new System.Windows.Forms.CheckBox();
			this.chkLimitSize = new System.Windows.Forms.CheckBox();
			this.lblImageHeight = new System.Windows.Forms.Label();
			this.txtImageHeight = new System.Windows.Forms.TextBox();
			this.lblImageWidth = new System.Windows.Forms.Label();
			this.txtImageWidth = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSpriteSheetSlicer = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPreProcessing = new System.Windows.Forms.TabPage();
			this.grpOutputOptions = new System.Windows.Forms.GroupBox();
			this.cboTextureFormat = new System.Windows.Forms.ComboBox();
			this.rdoXml = new System.Windows.Forms.RadioButton();
			this.rdoText = new System.Windows.Forms.RadioButton();
			this.lblFileFormat = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.tabPostProcessing = new System.Windows.Forms.TabPage();
			this.grpBatch = new System.Windows.Forms.GroupBox();
			this.chkBatchExecute = new System.Windows.Forms.CheckBox();
			this.txtBatchName = new System.Windows.Forms.TextBox();
			this.lblBatchName = new System.Windows.Forms.Label();
			this.txtBatchText = new System.Windows.Forms.TextBox();
			this.grpBatchOutput = new System.Windows.Forms.GroupBox();
			this.txtBatchOutput = new System.Windows.Forms.TextBox();
			this.rdoMeta = new System.Windows.Forms.RadioButton();
			this.grpFolders.SuspendLayout();
			this.grpTextureOptions.SuspendLayout();
			this.grpImageOptions.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPreProcessing.SuspendLayout();
			this.grpOutputOptions.SuspendLayout();
			this.tabPostProcessing.SuspendLayout();
			this.grpBatch.SuspendLayout();
			this.grpBatchOutput.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpFolders
			// 
			this.grpFolders.Controls.Add(this.cboFolder);
			this.grpFolders.Controls.Add(this.txtSearchExt);
			this.grpFolders.Controls.Add(this.lblSearchExt);
			this.grpFolders.Controls.Add(this.chkRecursive);
			this.grpFolders.Controls.Add(this.butFolder);
			this.grpFolders.Controls.Add(this.txtFolder);
			this.grpFolders.Location = new System.Drawing.Point(13, 11);
			this.grpFolders.Name = "grpFolders";
			this.grpFolders.Size = new System.Drawing.Size(508, 84);
			this.grpFolders.TabIndex = 0;
			this.grpFolders.TabStop = false;
			this.grpFolders.Text = "Input Folder(s)";
			// 
			// cboFolder
			// 
			this.cboFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFolder.FormattingEnabled = true;
			this.cboFolder.Location = new System.Drawing.Point(17, 22);
			this.cboFolder.Name = "cboFolder";
			this.cboFolder.Size = new System.Drawing.Size(74, 21);
			this.cboFolder.TabIndex = 5;
			this.cboFolder.SelectedIndexChanged += new System.EventHandler(this.cboFolder_SelectedIndexChanged);
			// 
			// txtSearchExt
			// 
			this.txtSearchExt.Location = new System.Drawing.Point(283, 51);
			this.txtSearchExt.Name = "txtSearchExt";
			this.txtSearchExt.Size = new System.Drawing.Size(156, 20);
			this.txtSearchExt.TabIndex = 4;
			this.txtSearchExt.TextChanged += new System.EventHandler(this.txtSearchExt_TextChanged);
			// 
			// lblSearchExt
			// 
			this.lblSearchExt.AutoSize = true;
			this.lblSearchExt.Location = new System.Drawing.Point(179, 55);
			this.lblSearchExt.Name = "lblSearchExt";
			this.lblSearchExt.Size = new System.Drawing.Size(98, 13);
			this.lblSearchExt.TabIndex = 3;
			this.lblSearchExt.Text = "Search Extensions:";
			// 
			// chkRecursive
			// 
			this.chkRecursive.AutoSize = true;
			this.chkRecursive.Location = new System.Drawing.Point(17, 54);
			this.chkRecursive.Name = "chkRecursive";
			this.chkRecursive.Size = new System.Drawing.Size(156, 17);
			this.chkRecursive.TabIndex = 2;
			this.chkRecursive.Text = "Recursive Directory Search";
			this.chkRecursive.UseVisualStyleBackColor = true;
			this.chkRecursive.CheckedChanged += new System.EventHandler(this.chkRecursive_CheckedChanged);
			// 
			// butFolder
			// 
			this.butFolder.Location = new System.Drawing.Point(449, 23);
			this.butFolder.Name = "butFolder";
			this.butFolder.Size = new System.Drawing.Size(39, 20);
			this.butFolder.TabIndex = 1;
			this.butFolder.Text = "...";
			this.butFolder.UseVisualStyleBackColor = true;
			this.butFolder.Click += new System.EventHandler(this.butFolder_Click);
			// 
			// txtFolder
			// 
			this.txtFolder.Location = new System.Drawing.Point(97, 23);
			this.txtFolder.Name = "txtFolder";
			this.txtFolder.Size = new System.Drawing.Size(342, 20);
			this.txtFolder.TabIndex = 0;
			this.txtFolder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtFolder.TextChanged += new System.EventHandler(this.txtFolder_TextChanged);
			// 
			// grpTextureOptions
			// 
			this.grpTextureOptions.Controls.Add(this.chkFillSpacing);
			this.grpTextureOptions.Controls.Add(this.chkMultiTexture);
			this.grpTextureOptions.Controls.Add(this.butColor);
			this.grpTextureOptions.Controls.Add(this.rdoColor);
			this.grpTextureOptions.Controls.Add(this.rdoAlpha);
			this.grpTextureOptions.Controls.Add(this.lblBackground);
			this.grpTextureOptions.Controls.Add(this.lblSpacing);
			this.grpTextureOptions.Controls.Add(this.txtSpacing);
			this.grpTextureOptions.Controls.Add(this.lblTextureHeight);
			this.grpTextureOptions.Controls.Add(this.txtTextureHeight);
			this.grpTextureOptions.Controls.Add(this.lblTextureWidth);
			this.grpTextureOptions.Controls.Add(this.txtTextureWidth);
			this.grpTextureOptions.Location = new System.Drawing.Point(13, 164);
			this.grpTextureOptions.Name = "grpTextureOptions";
			this.grpTextureOptions.Size = new System.Drawing.Size(508, 83);
			this.grpTextureOptions.TabIndex = 2;
			this.grpTextureOptions.TabStop = false;
			this.grpTextureOptions.Text = "Texture Options";
			// 
			// chkFillSpacing
			// 
			this.chkFillSpacing.AutoSize = true;
			this.chkFillSpacing.Location = new System.Drawing.Point(386, 49);
			this.chkFillSpacing.Name = "chkFillSpacing";
			this.chkFillSpacing.Size = new System.Drawing.Size(80, 17);
			this.chkFillSpacing.TabIndex = 11;
			this.chkFillSpacing.Text = "Fill Spacing";
			this.chkFillSpacing.UseVisualStyleBackColor = true;
			this.chkFillSpacing.CheckedChanged += new System.EventHandler(this.chkFillSpacing_CheckedChanged);
			// 
			// chkMultiTexture
			// 
			this.chkMultiTexture.AutoSize = true;
			this.chkMultiTexture.Location = new System.Drawing.Point(17, 24);
			this.chkMultiTexture.Name = "chkMultiTexture";
			this.chkMultiTexture.Size = new System.Drawing.Size(134, 17);
			this.chkMultiTexture.TabIndex = 0;
			this.chkMultiTexture.Text = "Allow Multiple Textures";
			this.chkMultiTexture.UseVisualStyleBackColor = true;
			this.chkMultiTexture.CheckedChanged += new System.EventHandler(this.chkMultiTexture_CheckedChanged);
			// 
			// butColor
			// 
			this.butColor.BackColor = System.Drawing.Color.Black;
			this.butColor.Location = new System.Drawing.Point(198, 48);
			this.butColor.Name = "butColor";
			this.butColor.Size = new System.Drawing.Size(34, 21);
			this.butColor.TabIndex = 8;
			this.butColor.UseVisualStyleBackColor = false;
			this.butColor.Click += new System.EventHandler(this.butColor_Click);
			// 
			// rdoColor
			// 
			this.rdoColor.AutoSize = true;
			this.rdoColor.Location = new System.Drawing.Point(143, 50);
			this.rdoColor.Name = "rdoColor";
			this.rdoColor.Size = new System.Drawing.Size(49, 17);
			this.rdoColor.TabIndex = 7;
			this.rdoColor.Text = "Color";
			this.rdoColor.UseVisualStyleBackColor = true;
			this.rdoColor.CheckedChanged += new System.EventHandler(this.rdoColor_CheckedChanged);
			// 
			// rdoAlpha
			// 
			this.rdoAlpha.AutoSize = true;
			this.rdoAlpha.Checked = true;
			this.rdoAlpha.Location = new System.Drawing.Point(85, 50);
			this.rdoAlpha.Name = "rdoAlpha";
			this.rdoAlpha.Size = new System.Drawing.Size(52, 17);
			this.rdoAlpha.TabIndex = 6;
			this.rdoAlpha.TabStop = true;
			this.rdoAlpha.Text = "Alpha";
			this.rdoAlpha.UseVisualStyleBackColor = true;
			this.rdoAlpha.CheckedChanged += new System.EventHandler(this.rdoAlpha_CheckedChanged);
			// 
			// lblBackground
			// 
			this.lblBackground.AutoSize = true;
			this.lblBackground.Location = new System.Drawing.Point(14, 53);
			this.lblBackground.Name = "lblBackground";
			this.lblBackground.Size = new System.Drawing.Size(68, 13);
			this.lblBackground.TabIndex = 5;
			this.lblBackground.Text = "Background:";
			// 
			// lblSpacing
			// 
			this.lblSpacing.AutoSize = true;
			this.lblSpacing.Location = new System.Drawing.Point(261, 50);
			this.lblSpacing.Name = "lblSpacing";
			this.lblSpacing.Size = new System.Drawing.Size(49, 13);
			this.lblSpacing.TabIndex = 9;
			this.lblSpacing.Text = "Spacing:";
			// 
			// txtSpacing
			// 
			this.txtSpacing.Location = new System.Drawing.Point(313, 47);
			this.txtSpacing.Name = "txtSpacing";
			this.txtSpacing.Size = new System.Drawing.Size(63, 20);
			this.txtSpacing.TabIndex = 10;
			this.txtSpacing.TextChanged += new System.EventHandler(this.txtSpacing_TextChanged);
			this.txtSpacing.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInteger_KeyPress);
			// 
			// lblTextureHeight
			// 
			this.lblTextureHeight.AutoSize = true;
			this.lblTextureHeight.Location = new System.Drawing.Point(383, 24);
			this.lblTextureHeight.Name = "lblTextureHeight";
			this.lblTextureHeight.Size = new System.Drawing.Size(41, 13);
			this.lblTextureHeight.TabIndex = 3;
			this.lblTextureHeight.Text = "Height:";
			// 
			// txtTextureHeight
			// 
			this.txtTextureHeight.Location = new System.Drawing.Point(427, 21);
			this.txtTextureHeight.Name = "txtTextureHeight";
			this.txtTextureHeight.Size = new System.Drawing.Size(63, 20);
			this.txtTextureHeight.TabIndex = 4;
			this.txtTextureHeight.TextChanged += new System.EventHandler(this.txtTextureHeight_TextChanged);
			this.txtTextureHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInteger_KeyPress);
			// 
			// lblTextureWidth
			// 
			this.lblTextureWidth.AutoSize = true;
			this.lblTextureWidth.Location = new System.Drawing.Point(269, 24);
			this.lblTextureWidth.Name = "lblTextureWidth";
			this.lblTextureWidth.Size = new System.Drawing.Size(38, 13);
			this.lblTextureWidth.TabIndex = 1;
			this.lblTextureWidth.Text = "Width:";
			// 
			// txtTextureWidth
			// 
			this.txtTextureWidth.Location = new System.Drawing.Point(313, 21);
			this.txtTextureWidth.Name = "txtTextureWidth";
			this.txtTextureWidth.Size = new System.Drawing.Size(63, 20);
			this.txtTextureWidth.TabIndex = 2;
			this.txtTextureWidth.TextChanged += new System.EventHandler(this.txtTextureWidth_TextChanged);
			this.txtTextureWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInteger_KeyPress);
			// 
			// butGo
			// 
			this.butGo.Location = new System.Drawing.Point(194, 417);
			this.butGo.Name = "butGo";
			this.butGo.Size = new System.Drawing.Size(154, 32);
			this.butGo.TabIndex = 4;
			this.butGo.Text = "GO!";
			this.butGo.UseVisualStyleBackColor = true;
			this.butGo.Click += new System.EventHandler(this.butGo_Click);
			// 
			// grpImageOptions
			// 
			this.grpImageOptions.Controls.Add(this.lblFilter);
			this.grpImageOptions.Controls.Add(this.chkNearestPower2);
			this.grpImageOptions.Controls.Add(this.rdoBilinear);
			this.grpImageOptions.Controls.Add(this.rdoNearestNeighbor);
			this.grpImageOptions.Controls.Add(this.chkKeepAspect);
			this.grpImageOptions.Controls.Add(this.chkLimitSize);
			this.grpImageOptions.Controls.Add(this.lblImageHeight);
			this.grpImageOptions.Controls.Add(this.txtImageHeight);
			this.grpImageOptions.Controls.Add(this.lblImageWidth);
			this.grpImageOptions.Controls.Add(this.txtImageWidth);
			this.grpImageOptions.Location = new System.Drawing.Point(13, 253);
			this.grpImageOptions.Name = "grpImageOptions";
			this.grpImageOptions.Size = new System.Drawing.Size(508, 87);
			this.grpImageOptions.TabIndex = 3;
			this.grpImageOptions.TabStop = false;
			this.grpImageOptions.Text = "Image Options";
			// 
			// lblFilter
			// 
			this.lblFilter.AutoSize = true;
			this.lblFilter.Location = new System.Drawing.Point(18, 53);
			this.lblFilter.Name = "lblFilter";
			this.lblFilter.Size = new System.Drawing.Size(32, 13);
			this.lblFilter.TabIndex = 3;
			this.lblFilter.Text = "Filter:";
			// 
			// chkNearestPower2
			// 
			this.chkNearestPower2.AutoSize = true;
			this.chkNearestPower2.Location = new System.Drawing.Point(160, 22);
			this.chkNearestPower2.Name = "chkNearestPower2";
			this.chkNearestPower2.Size = new System.Drawing.Size(105, 17);
			this.chkNearestPower2.TabIndex = 1;
			this.chkNearestPower2.Text = "Nearest Power 2";
			this.chkNearestPower2.UseVisualStyleBackColor = true;
			this.chkNearestPower2.CheckedChanged += new System.EventHandler(this.chkNearestPower2_CheckedChanged);
			// 
			// rdoBilinear
			// 
			this.rdoBilinear.AutoSize = true;
			this.rdoBilinear.Location = new System.Drawing.Point(170, 51);
			this.rdoBilinear.Name = "rdoBilinear";
			this.rdoBilinear.Size = new System.Drawing.Size(59, 17);
			this.rdoBilinear.TabIndex = 5;
			this.rdoBilinear.Text = "Bilinear";
			this.rdoBilinear.UseVisualStyleBackColor = true;
			this.rdoBilinear.CheckedChanged += new System.EventHandler(this.rdoBilinear_CheckedChanged);
			// 
			// rdoNearestNeighbor
			// 
			this.rdoNearestNeighbor.AutoSize = true;
			this.rdoNearestNeighbor.Checked = true;
			this.rdoNearestNeighbor.Location = new System.Drawing.Point(56, 51);
			this.rdoNearestNeighbor.Name = "rdoNearestNeighbor";
			this.rdoNearestNeighbor.Size = new System.Drawing.Size(108, 17);
			this.rdoNearestNeighbor.TabIndex = 4;
			this.rdoNearestNeighbor.TabStop = true;
			this.rdoNearestNeighbor.Text = "Nearest Neighbor";
			this.rdoNearestNeighbor.UseVisualStyleBackColor = true;
			this.rdoNearestNeighbor.CheckedChanged += new System.EventHandler(this.rdoNearestNeighbor_CheckedChanged);
			// 
			// chkKeepAspect
			// 
			this.chkKeepAspect.AutoSize = true;
			this.chkKeepAspect.Location = new System.Drawing.Point(313, 22);
			this.chkKeepAspect.Name = "chkKeepAspect";
			this.chkKeepAspect.Size = new System.Drawing.Size(115, 17);
			this.chkKeepAspect.TabIndex = 2;
			this.chkKeepAspect.Text = "Keep Aspect Ratio";
			this.chkKeepAspect.UseVisualStyleBackColor = true;
			this.chkKeepAspect.CheckedChanged += new System.EventHandler(this.chkKeepAspect_CheckedChanged);
			// 
			// chkLimitSize
			// 
			this.chkLimitSize.AutoSize = true;
			this.chkLimitSize.Location = new System.Drawing.Point(21, 22);
			this.chkLimitSize.Name = "chkLimitSize";
			this.chkLimitSize.Size = new System.Drawing.Size(70, 17);
			this.chkLimitSize.TabIndex = 0;
			this.chkLimitSize.Text = "Limit Size";
			this.chkLimitSize.UseVisualStyleBackColor = true;
			this.chkLimitSize.CheckedChanged += new System.EventHandler(this.chkLimitSize_CheckedChanged);
			// 
			// lblImageHeight
			// 
			this.lblImageHeight.AutoSize = true;
			this.lblImageHeight.Location = new System.Drawing.Point(383, 53);
			this.lblImageHeight.Name = "lblImageHeight";
			this.lblImageHeight.Size = new System.Drawing.Size(41, 13);
			this.lblImageHeight.TabIndex = 8;
			this.lblImageHeight.Text = "Height:";
			// 
			// txtImageHeight
			// 
			this.txtImageHeight.Location = new System.Drawing.Point(427, 50);
			this.txtImageHeight.Name = "txtImageHeight";
			this.txtImageHeight.Size = new System.Drawing.Size(63, 20);
			this.txtImageHeight.TabIndex = 9;
			this.txtImageHeight.TextChanged += new System.EventHandler(this.txtImageHeight_TextChanged);
			this.txtImageHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInteger_KeyPress);
			// 
			// lblImageWidth
			// 
			this.lblImageWidth.AutoSize = true;
			this.lblImageWidth.Location = new System.Drawing.Point(269, 53);
			this.lblImageWidth.Name = "lblImageWidth";
			this.lblImageWidth.Size = new System.Drawing.Size(38, 13);
			this.lblImageWidth.TabIndex = 6;
			this.lblImageWidth.Text = "Width:";
			// 
			// txtImageWidth
			// 
			this.txtImageWidth.Location = new System.Drawing.Point(313, 50);
			this.txtImageWidth.Name = "txtImageWidth";
			this.txtImageWidth.Size = new System.Drawing.Size(63, 20);
			this.txtImageWidth.TabIndex = 7;
			this.txtImageWidth.TextChanged += new System.EventHandler(this.txtImageWidth_TextChanged);
			this.txtImageWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInteger_KeyPress);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuTools});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(550, 24);
			this.menuStrip1.TabIndex = 5;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// mnuFile
			// 
			this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.mnuSave,
            this.mnuSaveAs,
            this.toolStripMenuItem1,
            this.mnuExit});
			this.mnuFile.Name = "mnuFile";
			this.mnuFile.Size = new System.Drawing.Size(37, 20);
			this.mnuFile.Text = "File";
			// 
			// mnuOpen
			// 
			this.mnuOpen.Name = "mnuOpen";
			this.mnuOpen.Size = new System.Drawing.Size(123, 22);
			this.mnuOpen.Text = "Open";
			this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
			// 
			// mnuSave
			// 
			this.mnuSave.Name = "mnuSave";
			this.mnuSave.Size = new System.Drawing.Size(123, 22);
			this.mnuSave.Text = "Save";
			this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
			// 
			// mnuSaveAs
			// 
			this.mnuSaveAs.Name = "mnuSaveAs";
			this.mnuSaveAs.Size = new System.Drawing.Size(123, 22);
			this.mnuSaveAs.Text = "Save As...";
			this.mnuSaveAs.Click += new System.EventHandler(this.mnuSaveAs_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 6);
			// 
			// mnuExit
			// 
			this.mnuExit.Name = "mnuExit";
			this.mnuExit.Size = new System.Drawing.Size(123, 22);
			this.mnuExit.Text = "Exit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// mnuTools
			// 
			this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSpriteSheetSlicer});
			this.mnuTools.Name = "mnuTools";
			this.mnuTools.Size = new System.Drawing.Size(47, 20);
			this.mnuTools.Text = "Tools";
			// 
			// mnuSpriteSheetSlicer
			// 
			this.mnuSpriteSheetSlicer.Name = "mnuSpriteSheetSlicer";
			this.mnuSpriteSheetSlicer.Size = new System.Drawing.Size(167, 22);
			this.mnuSpriteSheetSlicer.Text = "Sprite Sheet Slicer";
			this.mnuSpriteSheetSlicer.Click += new System.EventHandler(this.mnuSpriteSheetSlicer_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 460);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(550, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 6;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPreProcessing);
			this.tabControl1.Controls.Add(this.tabPostProcessing);
			this.tabControl1.Location = new System.Drawing.Point(5, 27);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(541, 382);
			this.tabControl1.TabIndex = 7;
			// 
			// tabPreProcessing
			// 
			this.tabPreProcessing.Controls.Add(this.grpFolders);
			this.tabPreProcessing.Controls.Add(this.grpTextureOptions);
			this.tabPreProcessing.Controls.Add(this.grpOutputOptions);
			this.tabPreProcessing.Controls.Add(this.grpImageOptions);
			this.tabPreProcessing.Location = new System.Drawing.Point(4, 22);
			this.tabPreProcessing.Name = "tabPreProcessing";
			this.tabPreProcessing.Padding = new System.Windows.Forms.Padding(3);
			this.tabPreProcessing.Size = new System.Drawing.Size(533, 356);
			this.tabPreProcessing.TabIndex = 0;
			this.tabPreProcessing.Text = "Pre-Processing";
			this.tabPreProcessing.UseVisualStyleBackColor = true;
			// 
			// grpOutputOptions
			// 
			this.grpOutputOptions.Controls.Add(this.rdoMeta);
			this.grpOutputOptions.Controls.Add(this.cboTextureFormat);
			this.grpOutputOptions.Controls.Add(this.rdoXml);
			this.grpOutputOptions.Controls.Add(this.rdoText);
			this.grpOutputOptions.Controls.Add(this.lblFileFormat);
			this.grpOutputOptions.Controls.Add(this.txtName);
			this.grpOutputOptions.Controls.Add(this.lblName);
			this.grpOutputOptions.Location = new System.Drawing.Point(13, 101);
			this.grpOutputOptions.Name = "grpOutputOptions";
			this.grpOutputOptions.Size = new System.Drawing.Size(508, 57);
			this.grpOutputOptions.TabIndex = 1;
			this.grpOutputOptions.TabStop = false;
			this.grpOutputOptions.Text = "Output Options";
			// 
			// cboTextureFormat
			// 
			this.cboTextureFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTextureFormat.FormattingEnabled = true;
			this.cboTextureFormat.Location = new System.Drawing.Point(208, 21);
			this.cboTextureFormat.Name = "cboTextureFormat";
			this.cboTextureFormat.Size = new System.Drawing.Size(81, 21);
			this.cboTextureFormat.TabIndex = 5;
			this.cboTextureFormat.SelectedIndexChanged += new System.EventHandler(this.cboTextureFormat_SelectedIndexChanged);
			// 
			// rdoXml
			// 
			this.rdoXml.AutoSize = true;
			this.rdoXml.Location = new System.Drawing.Point(409, 24);
			this.rdoXml.Name = "rdoXml";
			this.rdoXml.Size = new System.Drawing.Size(42, 17);
			this.rdoXml.TabIndex = 4;
			this.rdoXml.Text = "Xml";
			this.rdoXml.UseVisualStyleBackColor = true;
			this.rdoXml.CheckedChanged += new System.EventHandler(this.rdoXml_CheckedChanged);
			// 
			// rdoText
			// 
			this.rdoText.AutoSize = true;
			this.rdoText.Checked = true;
			this.rdoText.Location = new System.Drawing.Point(361, 24);
			this.rdoText.Name = "rdoText";
			this.rdoText.Size = new System.Drawing.Size(46, 17);
			this.rdoText.TabIndex = 3;
			this.rdoText.TabStop = true;
			this.rdoText.Text = "Text";
			this.rdoText.UseVisualStyleBackColor = true;
			this.rdoText.CheckedChanged += new System.EventHandler(this.rdoText_CheckedChanged);
			// 
			// lblFileFormat
			// 
			this.lblFileFormat.AutoSize = true;
			this.lblFileFormat.Location = new System.Drawing.Point(297, 26);
			this.lblFileFormat.Name = "lblFileFormat";
			this.lblFileFormat.Size = new System.Drawing.Size(61, 13);
			this.lblFileFormat.TabIndex = 2;
			this.lblFileFormat.Text = "File Format:";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(55, 21);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(143, 20);
			this.txtName.TabIndex = 1;
			this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(11, 24);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(38, 13);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "Name:";
			// 
			// tabPostProcessing
			// 
			this.tabPostProcessing.Controls.Add(this.grpBatch);
			this.tabPostProcessing.Controls.Add(this.grpBatchOutput);
			this.tabPostProcessing.Location = new System.Drawing.Point(4, 22);
			this.tabPostProcessing.Name = "tabPostProcessing";
			this.tabPostProcessing.Padding = new System.Windows.Forms.Padding(3);
			this.tabPostProcessing.Size = new System.Drawing.Size(533, 356);
			this.tabPostProcessing.TabIndex = 1;
			this.tabPostProcessing.Text = "Post-Processing";
			this.tabPostProcessing.UseVisualStyleBackColor = true;
			// 
			// grpBatch
			// 
			this.grpBatch.Controls.Add(this.chkBatchExecute);
			this.grpBatch.Controls.Add(this.txtBatchName);
			this.grpBatch.Controls.Add(this.lblBatchName);
			this.grpBatch.Controls.Add(this.txtBatchText);
			this.grpBatch.Location = new System.Drawing.Point(13, 11);
			this.grpBatch.Name = "grpBatch";
			this.grpBatch.Size = new System.Drawing.Size(508, 179);
			this.grpBatch.TabIndex = 2;
			this.grpBatch.TabStop = false;
			this.grpBatch.Text = "Batch";
			// 
			// chkBatchExecute
			// 
			this.chkBatchExecute.AutoSize = true;
			this.chkBatchExecute.Location = new System.Drawing.Point(15, 23);
			this.chkBatchExecute.Name = "chkBatchExecute";
			this.chkBatchExecute.Size = new System.Drawing.Size(65, 17);
			this.chkBatchExecute.TabIndex = 4;
			this.chkBatchExecute.Text = "Execute";
			this.chkBatchExecute.UseVisualStyleBackColor = true;
			// 
			// txtBatchName
			// 
			this.txtBatchName.Location = new System.Drawing.Point(210, 20);
			this.txtBatchName.Name = "txtBatchName";
			this.txtBatchName.Size = new System.Drawing.Size(143, 20);
			this.txtBatchName.TabIndex = 3;
			// 
			// lblBatchName
			// 
			this.lblBatchName.AutoSize = true;
			this.lblBatchName.Location = new System.Drawing.Point(166, 23);
			this.lblBatchName.Name = "lblBatchName";
			this.lblBatchName.Size = new System.Drawing.Size(38, 13);
			this.lblBatchName.TabIndex = 2;
			this.lblBatchName.Text = "Name:";
			// 
			// txtBatchText
			// 
			this.txtBatchText.Location = new System.Drawing.Point(15, 51);
			this.txtBatchText.Multiline = true;
			this.txtBatchText.Name = "txtBatchText";
			this.txtBatchText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtBatchText.Size = new System.Drawing.Size(477, 111);
			this.txtBatchText.TabIndex = 1;
			this.txtBatchText.WordWrap = false;
			// 
			// grpBatchOutput
			// 
			this.grpBatchOutput.Controls.Add(this.txtBatchOutput);
			this.grpBatchOutput.Location = new System.Drawing.Point(13, 196);
			this.grpBatchOutput.Name = "grpBatchOutput";
			this.grpBatchOutput.Size = new System.Drawing.Size(508, 149);
			this.grpBatchOutput.TabIndex = 1;
			this.grpBatchOutput.TabStop = false;
			this.grpBatchOutput.Text = "Output";
			// 
			// txtBatchOutput
			// 
			this.txtBatchOutput.Location = new System.Drawing.Point(16, 21);
			this.txtBatchOutput.Multiline = true;
			this.txtBatchOutput.Name = "txtBatchOutput";
			this.txtBatchOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtBatchOutput.Size = new System.Drawing.Size(477, 111);
			this.txtBatchOutput.TabIndex = 1;
			this.txtBatchOutput.WordWrap = false;
			// 
			// rdoMeta
			// 
			this.rdoMeta.AutoSize = true;
			this.rdoMeta.Location = new System.Drawing.Point(453, 24);
			this.rdoMeta.Name = "rdoMeta";
			this.rdoMeta.Size = new System.Drawing.Size(49, 17);
			this.rdoMeta.TabIndex = 6;
			this.rdoMeta.Text = "Meta";
			this.rdoMeta.UseVisualStyleBackColor = true;
			this.rdoMeta.CheckedChanged += new System.EventHandler(this.rdoMeta_CheckedChanged);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(550, 482);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.butGo);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Texture Packer v1.6.1 - By Ben Baker";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.grpFolders.ResumeLayout(false);
			this.grpFolders.PerformLayout();
			this.grpTextureOptions.ResumeLayout(false);
			this.grpTextureOptions.PerformLayout();
			this.grpImageOptions.ResumeLayout(false);
			this.grpImageOptions.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPreProcessing.ResumeLayout(false);
			this.grpOutputOptions.ResumeLayout(false);
			this.grpOutputOptions.PerformLayout();
			this.tabPostProcessing.ResumeLayout(false);
			this.grpBatch.ResumeLayout(false);
			this.grpBatch.PerformLayout();
			this.grpBatchOutput.ResumeLayout(false);
			this.grpBatchOutput.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFolders;
        private System.Windows.Forms.Button butFolder;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.GroupBox grpTextureOptions;
        private System.Windows.Forms.Button butGo;
        private System.Windows.Forms.Label lblTextureWidth;
        private System.Windows.Forms.TextBox txtTextureWidth;
        private System.Windows.Forms.Label lblTextureHeight;
        private System.Windows.Forms.TextBox txtTextureHeight;
        private System.Windows.Forms.Label lblSpacing;
        private System.Windows.Forms.TextBox txtSpacing;
        private System.Windows.Forms.GroupBox grpImageOptions;
        private System.Windows.Forms.CheckBox chkRecursive;
        private System.Windows.Forms.CheckBox chkLimitSize;
        private System.Windows.Forms.Label lblImageHeight;
        private System.Windows.Forms.TextBox txtImageHeight;
        private System.Windows.Forms.Label lblImageWidth;
        private System.Windows.Forms.TextBox txtImageWidth;
        private System.Windows.Forms.Button butColor;
        private System.Windows.Forms.RadioButton rdoColor;
        private System.Windows.Forms.RadioButton rdoAlpha;
        private System.Windows.Forms.Label lblBackground;
        private System.Windows.Forms.CheckBox chkKeepAspect;
        private System.Windows.Forms.RadioButton rdoBilinear;
        private System.Windows.Forms.RadioButton rdoNearestNeighbor;
        private System.Windows.Forms.CheckBox chkNearestPower2;
        private System.Windows.Forms.CheckBox chkMultiTexture;
        private System.Windows.Forms.TextBox txtSearchExt;
        private System.Windows.Forms.Label lblSearchExt;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.CheckBox chkFillSpacing;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuSpriteSheetSlicer;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPreProcessing;
        private System.Windows.Forms.TabPage tabPostProcessing;
        private System.Windows.Forms.GroupBox grpOutputOptions;
        private System.Windows.Forms.ComboBox cboTextureFormat;
        private System.Windows.Forms.RadioButton rdoXml;
        private System.Windows.Forms.RadioButton rdoText;
        private System.Windows.Forms.Label lblFileFormat;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cboFolder;
        private System.Windows.Forms.GroupBox grpBatchOutput;
        private System.Windows.Forms.TextBox txtBatchOutput;
        private System.Windows.Forms.GroupBox grpBatch;
        private System.Windows.Forms.TextBox txtBatchText;
        private System.Windows.Forms.CheckBox chkBatchExecute;
        private System.Windows.Forms.TextBox txtBatchName;
        private System.Windows.Forms.Label lblBatchName;
		private System.Windows.Forms.RadioButton rdoMeta;
    }
}

