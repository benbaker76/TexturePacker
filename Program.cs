using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace TexturePacker
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int dwProcessId);
        [DllImport("kernel32.dll")]
        private static extern bool FreeConsole();
        private const int ATTACH_PARENT_PROCESS = -1;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            int argCount = args == null ? 0 : args.Length;

            if (argCount > 0)
            {
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    AttachConsole(ATTACH_PARENT_PROCESS);
                    Console.WriteLine("");
                }

                for (int i = 0; i < Globals.MAX_FOLDERS; i++)
                    Settings.File.FolderList.Add(String.Empty);

                string output, error;

                Settings.File.FileName = args[0];

                ReadConfig(Path.Combine(Application.StartupPath, Settings.File.FileName));

                Program.ProcessFiles(out output, out error);

                Console.WriteLine(output);
                Console.Error.WriteLine(error);

                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    SendKeys.SendWait("{ENTER}");
                    FreeConsole();
                }

                return 1;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());

            return 1;
        }

        private static bool IsAtlasDone(List<ImageAtlasNode> imageAtlasList)
        {
            foreach (ImageAtlasNode imageAtlas in imageAtlasList)
            {
                if (!imageAtlas.Processed)
                    return false;
            }

            return true;
        }

        private static void ExecuteBatch(string fileName, string arguments, out string output, out string error)
        {
            int ExitCode;
            ProcessStartInfo ProcessInfo;
            Process process;

            ProcessInfo = new ProcessStartInfo(Path.GetFileName(fileName), arguments);
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;
            ProcessInfo.WorkingDirectory = Path.GetDirectoryName(fileName);

            ProcessInfo.RedirectStandardError = true;
            ProcessInfo.RedirectStandardOutput = true;

            process = Process.Start(ProcessInfo);
            process.WaitForExit();

            output = process.StandardOutput.ReadToEnd();
            error = process.StandardError.ReadToEnd();

            ExitCode = process.ExitCode;

            process.Close();
        }

        public static void ReadConfig(string fileName)
        {
            IniFile iniFile = new IniFile(fileName);

            for (int i = 0; i < Globals.MAX_FOLDERS; i++)
                Settings.File.FolderList[i] = String.Empty;

            if (iniFile.ContainsKey("General", "Folder"))
            {
                Settings.File.FolderList[0] = iniFile.Read("General", "Folder", String.Empty);

                iniFile.TryDeleteKey("General", "Folder");
            }
            else
            {
                for (int i = 0; i < Globals.MAX_FOLDERS; i++)
                    Settings.File.FolderList[i] = iniFile.Read("General", String.Format("Folder{0}", i + 1), String.Empty);
            }

            Settings.File.FileName = Path.GetFileName(iniFile.Read("General", "FileName", Settings.File.DefaultFileName));
            Settings.General.Recursive = iniFile.Read<bool>("General", "Recursive", Settings.General.Recursive);
            Settings.General.SearchExt = iniFile.Read("General", "SearchExt", Settings.General.SearchExt);
            Settings.General.Name = iniFile.Read("General", "Name", Settings.General.Name);
            Settings.General.TextureFormat = iniFile.Read("General", "TextureFormat", Settings.General.TextureFormat);
            Settings.General.FileFormat = iniFile.Read<FileFormat>("General", "FileFormat", Settings.General.FileFormat);
            Settings.General.MultiTexture = iniFile.Read<bool>("General", "MultiTexture", Settings.General.MultiTexture);
            Settings.General.TextureWidth = iniFile.Read<int>("General", "TextureWidth", Settings.General.TextureWidth);
            Settings.General.TextureHeight = iniFile.Read<int>("General", "TextureHeight", Settings.General.TextureHeight);
            Settings.General.Alpha = iniFile.Read<bool>("General", "Alpha", Settings.General.Alpha);
            Settings.General.Color = iniFile.Read<bool>("General", "Color", Settings.General.Color);
            Settings.General.BackColor = Color.FromArgb(iniFile.Read<int>("General", "BackColor", Settings.General.BackColor.ToArgb()));
            Settings.General.Spacing = iniFile.Read<int>("General", "Spacing", Settings.General.Spacing);
            Settings.General.FillSpacing = iniFile.Read<bool>("General", "FillSpacing", Settings.General.FillSpacing);
            Settings.General.LimitSize = iniFile.Read<bool>("General", "LimitSize", Settings.General.LimitSize);
            Settings.General.NearestPower2 = iniFile.Read<bool>("General", "NearestPower2", Settings.General.NearestPower2);
            Settings.General.KeepAspect = iniFile.Read<bool>("General", "KeepAspect", Settings.General.KeepAspect);
            Settings.General.NearestNeighbor = iniFile.Read<bool>("General", "NearestNeighbor", Settings.General.NearestNeighbor);
            Settings.General.Bilinear = iniFile.Read<bool>("General", "Bilinear", Settings.General.Bilinear);
            Settings.General.ImageWidth = iniFile.Read<int>("General", "ImageWidth", Settings.General.ImageWidth);
            Settings.General.ImageHeight = iniFile.Read<int>("General", "ImageHeight", Settings.General.ImageHeight);
            Settings.Batch.Execute = iniFile.Read<bool>("Batch", "Execute", Settings.Batch.Execute);
            Settings.Batch.Name = iniFile.Read("Batch", "Name", Settings.Batch.Name);
            Settings.Batch.Text = iniFile.Read("Batch", "Text", Settings.Batch.Text).Replace("[br]", Environment.NewLine);
        }

        public static void WriteConfig(string fileName)
        {
            IniFile iniFile = new IniFile(fileName);

            iniFile.Write("General", "FileName", Path.GetFileName(Settings.File.FileName));

            for (int i = 0; i < Globals.MAX_FOLDERS; i++)
            {
                iniFile.Write("General", String.Format("Folder{0}", i + 1), Settings.File.FolderList[i]);
            }

            iniFile.Write<bool>("General", "Recursive", Settings.General.Recursive);
            iniFile.Write("General", "SearchExt", Settings.General.SearchExt);
            iniFile.Write("General", "Name", Settings.General.Name);
            iniFile.Write("General", "TextureFormat", Settings.General.TextureFormat);
            iniFile.Write<FileFormat>("General", "FileFormat", Settings.General.FileFormat);
            iniFile.Write<bool>("General", "MultiTexture", Settings.General.MultiTexture);
            iniFile.Write<int>("General", "TextureWidth", Settings.General.TextureWidth);
            iniFile.Write<int>("General", "TextureHeight", Settings.General.TextureHeight);
            iniFile.Write<bool>("General", "Alpha", Settings.General.Alpha);
            iniFile.Write<bool>("General", "Color", Settings.General.Color);
            iniFile.Write<int>("General", "BackColor", Settings.General.BackColor.ToArgb());
            iniFile.Write<int>("General", "Spacing", Settings.General.Spacing);
            iniFile.Write<bool>("General", "FillSpacing", Settings.General.FillSpacing);
            iniFile.Write<bool>("General", "LimitSize", Settings.General.LimitSize);
            iniFile.Write<bool>("General", "NearestPower2", Settings.General.NearestPower2);
            iniFile.Write<bool>("General", "KeepAspect", Settings.General.KeepAspect);
            iniFile.Write<bool>("General", "NearestNeighbor", Settings.General.NearestNeighbor);
            iniFile.Write<bool>("General", "Bilinear", Settings.General.Bilinear);
            iniFile.Write<int>("General", "ImageWidth", Settings.General.ImageWidth);
            iniFile.Write<int>("General", "ImageHeight", Settings.General.ImageHeight);
            iniFile.Write<bool>("Batch", "Execute", Settings.Batch.Execute);
            iniFile.Write("Batch", "Name", Settings.Batch.Name);
            iniFile.Write("Batch", "Text", Settings.Batch.Text.Replace(Environment.NewLine, "[br]"));
        }

        public static void ProcessFiles(out string output, out string error)
        {
            Settings.General.Name = String.IsNullOrEmpty(Settings.General.Name) ? "texture" : Settings.General.Name;
			List<FileInfo> fileList = new List<FileInfo>();

            output = String.Empty;
            error = String.Empty;

            for (int i = 0; i < Globals.MAX_FOLDERS; i++)
            {
                if (String.IsNullOrEmpty(Settings.File.FolderList[i]))
                    continue;

                if (!Directory.Exists(Settings.File.FolderList[i]))
                    continue;

				fileList.AddRange(FileIO.GetFileList(Settings.File.FolderList[i], Convert.RemoveWhiteSpace(Settings.General.SearchExt).Split(new char[] { ',' }), Settings.General.Recursive));
            }

			if (fileList.Count == 0)
                return;

			List<ImageAtlasNode> imageAtlasList = new List<ImageAtlasNode>();
			int textureCount = 0, imageIndex = 0;
            RectanglePacker rectPacker;

			for (int i = 0; i < fileList.Count; i++)
				imageAtlasList.Add(new ImageAtlasNode(i, fileList[i].FullName));

			imageAtlasList.Sort(new ImageAtlasNode());
			imageAtlasList.Sort(new BitmapSizeComparer());

            rectPacker = new RectanglePacker(Settings.General.TextureWidth, Settings.General.TextureHeight);
            Bitmap textureBitmap = new Bitmap(Settings.General.TextureWidth, Settings.General.TextureHeight);
            Graphics g = Graphics.FromImage(textureBitmap);
			TextureNode textureNode = new TextureNode();

            if (Settings.General.NearestNeighbor)
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            else
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;

            if (Settings.General.Color)
                g.Clear(Settings.General.BackColor);

			while (!IsAtlasDone(imageAtlasList))
            {
                foreach (ImageAtlasNode imageAtlas in imageAtlasList)
                {
					if (imageAtlas.Processed)
                        continue;

                    try
                    {
						using (Bitmap imageBitmap = FileIO.LoadBitmap(imageAtlas.FileName))
                        {
							imageBitmap.SetResolution(96.0f, 96.0f);

							long fileLastWriteTime = FileIO.GetFileLastWriteTime(imageAtlas.FileName).ToBinary();
							Point imagePoint = Point.Empty;
							Size imageSize = new Size(Math.Min(imageBitmap.Width, Settings.General.TextureWidth - Settings.General.Spacing), Math.Min(imageBitmap.Height, Settings.General.TextureHeight - Settings.General.Spacing));

                            if (Settings.General.LimitSize)
                            {
                                if (Settings.General.KeepAspect)
                                {
									imageSize = Convert.ResizeImage(imageBitmap.Size, new Size(Settings.General.ImageWidth, Settings.General.ImageHeight));
                                }
                                else
                                {
									imageSize = new Size(imageBitmap.Width > Settings.General.ImageWidth ? Settings.General.ImageWidth : imageBitmap.Width, imageBitmap.Height > Settings.General.ImageHeight ? Settings.General.ImageHeight : imageBitmap.Height);
                                }

                                if (Settings.General.NearestPower2)
									imageSize = Convert.GetNearestPower2Size(imageSize, new Size(16384, 16384));
                            }

							if (imageSize.Width + Settings.General.Spacing > Settings.General.TextureWidth || imageSize.Height + Settings.General.Spacing > Settings.General.TextureHeight)
                            {
								imageAtlas.Processed = true;

                                continue;
                            }

							if (rectPacker.FindPoint(new Size(imageSize.Width + Settings.General.Spacing, imageSize.Height + Settings.General.Spacing), ref imagePoint))
                            {
                                int halfSpacing = Settings.General.Spacing / 2;
								Point imageOffset = new Point(imagePoint.X + halfSpacing, imagePoint.Y + halfSpacing);

								g.DrawImage(imageBitmap, new Rectangle(imageOffset, imageSize), new Rectangle(0, 0, imageBitmap.Width, imageBitmap.Height), GraphicsUnit.Pixel);

                                if (Settings.General.FillSpacing && Settings.General.Spacing > 1)
                                {
                                    for (int i = 0; i < halfSpacing; i++)
                                    {
										g.DrawImage(imageBitmap, new Rectangle(imagePoint.X + i, imagePoint.Y + halfSpacing, 1, imageSize.Height), new Rectangle(0, 0, 1, imageBitmap.Height), GraphicsUnit.Pixel);
										g.DrawImage(imageBitmap, new Rectangle(imagePoint.X + halfSpacing + imageSize.Width + i, imagePoint.Y + halfSpacing, 1, imageSize.Height), new Rectangle(imageBitmap.Width - 1, 0, 1, imageBitmap.Height), GraphicsUnit.Pixel);

										g.DrawImage(imageBitmap, new Rectangle(imagePoint.X + halfSpacing, imagePoint.Y + i, imageSize.Width, 1), new Rectangle(0, 0, imageBitmap.Width, 1), GraphicsUnit.Pixel);
										g.DrawImage(imageBitmap, new Rectangle(imagePoint.X + halfSpacing, imagePoint.Y + halfSpacing + imageSize.Height + i, imageSize.Width, 1), new Rectangle(0, imageBitmap.Height - 1, imageBitmap.Width, 1), GraphicsUnit.Pixel);
                                    }

                                    for (int i = 0; i < halfSpacing; i++)
                                    {
                                        for (int j = 0; j < halfSpacing; j++)
                                        {
											g.DrawImage(imageBitmap, new Rectangle(imagePoint.X + i, imagePoint.Y + j, 1, 1), new Rectangle(0, 0, 1, 1), GraphicsUnit.Pixel);
											g.DrawImage(imageBitmap, new Rectangle(imagePoint.X + halfSpacing + imageSize.Width + i, imagePoint.Y + j, 1, 1), new Rectangle(imageBitmap.Width - 1, 0, 1, 1), GraphicsUnit.Pixel);
											g.DrawImage(imageBitmap, new Rectangle(imagePoint.X + i, imagePoint.Y + halfSpacing + imageSize.Height + j, 1, 1), new Rectangle(0, imageBitmap.Height - 1, 1, 1), GraphicsUnit.Pixel);
											g.DrawImage(imageBitmap, new Rectangle(imagePoint.X + halfSpacing + imageSize.Width + i, imagePoint.Y + halfSpacing + imageSize.Height + j, 1, 1), new Rectangle(imageBitmap.Width - 1, imageBitmap.Height - 1, 1, 1), GraphicsUnit.Pixel);
                                        }
                                    }
                                }

								string imageName = Path.GetFileName(imageAtlas.FileName);

								textureNode.ImageList.Add(new ImageNode(textureNode, imageIndex, imageAtlas.FileName, imageName, imageOffset.X, imageOffset.Y, imageSize.Width, imageSize.Height, fileLastWriteTime));

								imageAtlas.Processed = true;

								imageIndex++;
                            }
                        }
                    }
                    catch
                    {
						imageAtlas.Processed = true;
                    }
                }

                System.Drawing.Imaging.ImageFormat imageFormat;

                switch (Settings.General.TextureFormat)
                {
                    case ".png":
                        imageFormat = System.Drawing.Imaging.ImageFormat.Png;
                        break;
                    case ".bmp":
                        imageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
                        break;
                    case ".jpg":
                        imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                    case ".gif":
                        imageFormat = System.Drawing.Imaging.ImageFormat.Gif;
                        break;
                    case ".tif":
                        imageFormat = System.Drawing.Imaging.ImageFormat.Tiff;
                        break;
                    default:
                        imageFormat = System.Drawing.Imaging.ImageFormat.Png;
                        break;
                }

				string fileName = Settings.General.Name + (Settings.General.MultiTexture ? textureCount.ToString("00") : String.Empty);
				string fileNameExt = Path.ChangeExtension(fileName, Settings.General.TextureFormat);
				string fullPath = Path.Combine(Application.StartupPath, fileName);
				string fullPathExt = Path.Combine(fullPath, fileNameExt);

				textureNode.FileName = fileNameExt;
				textureNode.Path = fullPathExt;
				textureNode.Name = fileName;
				textureNode.TextureSize = new Size(Settings.General.TextureWidth, Settings.General.TextureHeight); ;

				textureNode.ImageList.Sort(new ImageNode());

				textureBitmap.Save(fullPath + Settings.General.TextureFormat, imageFormat);

				switch (Settings.General.FileFormat)
				{
					case FileFormat.Text:
						textureNode.WriteTxt(fullPath + ".txt");
						break;
					case FileFormat.Xml:
						textureNode.WriteXml(fullPath + ".xml");
						break;
					case FileFormat.Meta:
						textureNode.WriteMeta(fullPath + Settings.General.TextureFormat + ".meta");
						break;
				}

                if (Settings.Batch.Execute)
                {
                    string batchFileName = Path.Combine(Application.StartupPath, Settings.Batch.Name);
                    File.WriteAllText(batchFileName, Settings.Batch.Text);

                    ExecuteBatch(batchFileName, String.Format("\"{0}\" \"{1}\" \"{2}\" \"{3}\" \"{4}\"", fileName, fileNameExt, fullPath, fullPathExt, Settings.General.TextureFormat), out output, out error);

                    File.Delete(batchFileName);
                }

                if (!Settings.General.MultiTexture)
                    break;

                textureBitmap.Dispose();
                g.Dispose();

                rectPacker = new RectanglePacker(Settings.General.TextureWidth, Settings.General.TextureHeight);
                textureBitmap = new Bitmap(Settings.General.TextureWidth, Settings.General.TextureHeight);
                g = Graphics.FromImage(textureBitmap);

                if (Settings.General.NearestNeighbor)
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                else
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;

                if (Settings.General.Color)
                    g.Clear(Settings.General.BackColor);

				textureNode = new TextureNode();

                textureCount++;

				Application.DoEvents();
            }
        }
    }
}
