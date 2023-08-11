using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace TexturePacker
{
    public partial class frmSpriteSlicer : Form
    {
        public frmSpriteSlicer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Size inputSize = new Size(System.Convert.ToInt32(inputWidth.Text), System.Convert.ToInt32(inputHeight.Text));
				Size marginSize = new Size(System.Convert.ToInt32(marginWidth.Text), System.Convert.ToInt32(marginHeight.Text));
				Size spacingSize = new Size(System.Convert.ToInt32(spacingWidth.Text), System.Convert.ToInt32(spacingHeight.Text));
                Size outputSize = chkUseTrimSize.Checked ? inputSize : new Size(System.Convert.ToInt32(outputWidth.Text), System.Convert.ToInt32(outputHeight.Text));
                Rectangle trimRect = new Rectangle(0, 0, inputSize.Width, inputSize.Height);

                using (Bitmap bmpSrc = (Bitmap)Bitmap.FromFile(openFileDialog.FileName))
                {
                    if (chkAutoTrim.Checked)
                    {
                        trimRect = new Rectangle(inputSize.Width, inputSize.Height, 0, 0);

                        using (Bitmap bmpDest = new Bitmap(inputSize.Width, inputSize.Height))
                        {
                            using (Graphics g = Graphics.FromImage(bmpDest))
                            {
                                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                g.SmoothingMode = SmoothingMode.HighQuality;
                                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                                g.CompositingQuality = CompositingQuality.HighQuality;

                                int cols = (bmpSrc.Width - marginSize.Width) / (inputSize.Width + spacingSize.Width);
                                int rows = (bmpSrc.Height - marginSize.Height) / (inputSize.Height + spacingSize.Height);

                                for (int y = 0; y < rows; y++)
                                {
                                    for (int x = 0; x < cols; x++)
                                    {
										Rectangle srcRect = new Rectangle(marginSize.Width + x * (inputSize.Width + spacingSize.Width), marginSize.Height + y * (inputSize.Height + spacingSize.Height), inputSize.Width, inputSize.Height);

                                        g.Clear(Color.Empty);

                                        g.DrawImage(bmpSrc, new Rectangle(0, 0, inputSize.Width, inputSize.Height), srcRect, GraphicsUnit.Pixel);

                                        Rectangle rect = GetAlphaEdge(bmpDest);

                                        trimRect.X = Math.Min(trimRect.X, rect.X);
                                        trimRect.Y = Math.Min(trimRect.Y, rect.Y);
                                        trimRect.Width = Math.Max(trimRect.Width, rect.Width);
                                        trimRect.Height = Math.Max(trimRect.Height, rect.Height);

                                        if (chkUseTrimSize.Checked)
                                            outputSize = new Size(trimRect.Width, trimRect.Height);
                                    }
                                }
                            }
                        }
                    }

                    using (Bitmap bmpDest = new Bitmap(outputSize.Width, outputSize.Height))
                    {
                        using (Graphics g = Graphics.FromImage(bmpDest))
                        {
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            g.SmoothingMode = SmoothingMode.HighQuality;
                            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            g.CompositingQuality = CompositingQuality.HighQuality;

							int cols = (bmpSrc.Width - marginSize.Width) / (inputSize.Width + spacingSize.Width);
							int rows = (bmpSrc.Height - marginSize.Height) / (inputSize.Height + spacingSize.Height);

                            for (int y = 0; y < rows; y++)
                            {
                                for (int x = 0; x < cols; x++)
                                {
									Rectangle srcRect = new Rectangle(marginSize.Width + x * (inputSize.Width + spacingSize.Width), marginSize.Height + y * (inputSize.Height + spacingSize.Height), inputSize.Width, inputSize.Height);

                                    g.Clear(Color.Empty);

									g.DrawImage(bmpSrc, new Rectangle(0, 0, outputSize.Width, outputSize.Height), srcRect, GraphicsUnit.Pixel);

                                    bmpDest.Save(Path.Combine(Path.GetDirectoryName(openFileDialog.FileName), Path.GetFileNameWithoutExtension(openFileDialog.FileName) + "_" + String.Format("{0:00}", y * cols + x) + ".png"), System.Drawing.Imaging.ImageFormat.Png);
                                }
                            }
                        }
                    }
                }

                MessageBox.Show("Done!");
            }
        }

        public Rectangle GetAlphaEdge(Bitmap bmp)
        {
            Size min = new Size(bmp.Width, bmp.Height);
            Size max = new Size(0, 0);

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color color = bmp.GetPixel(x, y);

                    if (color != Color.FromArgb(0, 0, 0, 0))
                    {
                        min = new Size(Math.Min(min.Width, x), Math.Min(min.Height, y));
                        max = new Size(Math.Max(max.Width, x + 1), Math.Max(max.Height, y + 1));
                    }
                }
            }

            return new Rectangle(min.Width, min.Height, max.Width - min.Width, max.Height - min.Height);
        }
    }
}
