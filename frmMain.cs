using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace TexturePacker
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Globals.MAX_FOLDERS; i++)
            {
                Settings.File.FolderList.Add(String.Empty);
                cboFolder.Items.Add(String.Format("{0}", i + 1));
            }

            cboFolder.SelectedIndex = 0;

            cboTextureFormat.Items.AddRange(Globals.TextureFormats);

            ReadConfig(Path.Combine(Application.StartupPath, Settings.File.DefaultFileName));
            ReadConfig(Path.Combine(Application.StartupPath, Settings.File.FileName));
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteConfig(Path.Combine(Application.StartupPath, Settings.File.DefaultFileName));
            WriteConfig(Path.Combine(Application.StartupPath, Settings.File.FileName));
        }

        private void txtInteger_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !(e.KeyChar == '\b'))
                e.Handled = true;
        }

        private void butFolder_Click(object sender, EventArgs e)
        {
            string folder = null;

            if (FileIO.TryOpenFolder(this, Application.StartupPath, out folder))
                txtFolder.Text = folder;
        }

        private void butGo_Click(object sender, EventArgs e)
        {
            string output, error;

            txtBatchOutput.Clear();

            Program.ProcessFiles(out output, out error);

            txtBatchOutput.AppendText(output);
            txtBatchOutput.AppendText(error);

            txtBatchOutput.SelectionStart = txtBatchOutput.Text.Length;
            txtBatchOutput.ScrollToCaret();

            MessageBox.Show(this, "Done!");
        }

        private void butColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;
            cd.FullOpen = true;
            cd.Color = butColor.BackColor;

            if (cd.ShowDialog() == DialogResult.OK)
            {
                butColor.BackColor = cd.Color;
                Settings.General.BackColor = cd.Color;
            }
        }

        void ReadConfig(string fileName)
        {
            Program.ReadConfig(fileName);

            chkRecursive.Checked = Settings.General.Recursive;
            txtSearchExt.Text = Settings.General.SearchExt;
            txtName.Text = Settings.General.Name;
            cboTextureFormat.Text = Settings.General.TextureFormat;

			switch (Settings.General.FileFormat)
			{
				case FileFormat.Text:
					rdoText.Checked = true;
					break;
				case FileFormat.Xml:
					rdoXml.Checked = true;
					break;
				case FileFormat.Meta:
					rdoMeta.Checked = true;
					break;
			}

            chkMultiTexture.Checked = Settings.General.MultiTexture;
            txtTextureWidth.Text = Settings.General.TextureWidth.ToString();
            txtTextureHeight.Text = Settings.General.TextureHeight.ToString();
            rdoAlpha.Checked = Settings.General.Alpha;
            rdoColor.Checked = Settings.General.Color;
            butColor.BackColor = Settings.General.BackColor;
            txtSpacing.Text = Settings.General.Spacing.ToString();
            chkFillSpacing.Checked = Settings.General.FillSpacing;
            chkLimitSize.Checked = Settings.General.LimitSize;
            chkNearestPower2.Checked = Settings.General.NearestPower2;
            chkKeepAspect.Checked = Settings.General.KeepAspect;
            rdoNearestNeighbor.Checked = Settings.General.NearestNeighbor;
            rdoBilinear.Checked = Settings.General.Bilinear;
            txtImageWidth.Text = Settings.General.ImageWidth.ToString();
            txtImageHeight.Text = Settings.General.ImageHeight.ToString();
            chkBatchExecute.Checked = Settings.Batch.Execute;
            txtBatchName.Text = Settings.Batch.Name;
            txtBatchText.Text = Settings.Batch.Text;

            toolStripStatusLabel1.Text = Path.GetFileName(Settings.File.FileName);

            cboFolder_SelectedIndexChanged(this, new EventArgs());
        }

        void WriteConfig(string fileName)
        {
            Program.WriteConfig(fileName);

            toolStripStatusLabel1.Text = Path.GetFileName(Settings.File.FileName);
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            string fileName = null;

            if (FileIO.TryOpenFile(this, Application.StartupPath, Settings.File.FileName, ".ini", out fileName))
            {
                Settings.File.FileName = fileName;

                ReadConfig(Settings.File.FileName);
            }
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            WriteConfig(Settings.File.FileName);
        }

        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            string fileName = null;

            if (FileIO.TrySaveFile(this, Application.StartupPath, Settings.File.FileName, ".ini", out fileName))
            {
                Settings.File.FileName = fileName;

                WriteConfig(Settings.File.FileName);
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuSpriteSheetSlicer_Click(object sender, EventArgs e)
        {
            using (frmSpriteSlicer frmSpriteSlicer = new frmSpriteSlicer())
                frmSpriteSlicer.ShowDialog(this);
        }

        private void cboFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFolder.Text = Settings.File.FolderList[cboFolder.SelectedIndex];
        }

        private void txtFolder_TextChanged(object sender, EventArgs e)
        {
            Settings.File.FolderList[cboFolder.SelectedIndex] = txtFolder.Text;
        }

        private void chkRecursive_CheckedChanged(object sender, EventArgs e)
        {
            Settings.General.Recursive = chkRecursive.Checked;
        }

        private void txtSearchExt_TextChanged(object sender, EventArgs e)
        {
            Settings.General.SearchExt = txtSearchExt.Text;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            Settings.General.Name = txtName.Text;
        }

        private void cboTextureFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.General.TextureFormat = cboTextureFormat.Text;
        }

        private void rdoText_CheckedChanged(object sender, EventArgs e)
        {
			Settings.General.FileFormat = FileFormat.Text;
        }

        private void rdoXml_CheckedChanged(object sender, EventArgs e)
        {
			Settings.General.FileFormat = FileFormat.Xml;
        }

		private void rdoMeta_CheckedChanged(object sender, EventArgs e)
		{
			Settings.General.FileFormat = FileFormat.Meta;
		}

        private void chkMultiTexture_CheckedChanged(object sender, EventArgs e)
        {
            Settings.General.MultiTexture = chkMultiTexture.Checked;
        }

        private void rdoAlpha_CheckedChanged(object sender, EventArgs e)
        {
            Settings.General.Alpha = rdoAlpha.Checked;
        }

        private void rdoColor_CheckedChanged(object sender, EventArgs e)
        {
            Settings.General.Color = rdoColor.Checked;
        }

        private void txtTextureWidth_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(txtTextureWidth.Text, out Settings.General.TextureWidth);
        }

        private void txtTextureHeight_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(txtTextureHeight.Text, out Settings.General.TextureHeight);
        }

        private void txtSpacing_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(txtSpacing.Text, out Settings.General.Spacing);
        }

        private void chkFillSpacing_CheckedChanged(object sender, EventArgs e)
        {
            Settings.General.FillSpacing = chkFillSpacing.Checked;
        }

        private void chkLimitSize_CheckedChanged(object sender, EventArgs e)
        {
            Settings.General.LimitSize = chkLimitSize.Checked;
        }

        private void chkNearestPower2_CheckedChanged(object sender, EventArgs e)
        {
            Settings.General.NearestPower2 = chkNearestPower2.Checked;
        }

        private void chkKeepAspect_CheckedChanged(object sender, EventArgs e)
        {
            Settings.General.KeepAspect = chkKeepAspect.Checked;
        }

        private void rdoNearestNeighbor_CheckedChanged(object sender, EventArgs e)
        {
            Settings.General.NearestNeighbor = rdoNearestNeighbor.Checked;
        }

        private void rdoBilinear_CheckedChanged(object sender, EventArgs e)
        {
            Settings.General.Bilinear = rdoBilinear.Checked;
        }

        private void txtImageWidth_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(txtImageWidth.Text, out Settings.General.ImageWidth);
        }

        private void txtImageHeight_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(txtImageHeight.Text, out Settings.General.ImageHeight);
        }
    }
}
