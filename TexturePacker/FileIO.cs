using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace TexturePacker
{
	public class FileIO
	{
		public static DateTime GetFileLastWriteTime(string fileName)
		{
			try
			{
				return File.GetLastWriteTime(fileName);
			}
			catch
			{
			}

			return DateTime.MinValue;
		}

		public static bool TryOpenFile(Form owner, string initialDirectory, string initialFileName, string extension, out string fileName)
		{
			fileName = null;

			try
			{
				OpenFileDialog fd = new OpenFileDialog();

				fd.Title = "Open File";
				fd.InitialDirectory = initialDirectory;
				fd.FileName = initialFileName;
				fd.Filter = String.Format("{0} Files (*{1})|*{2}|All Files (*.*)|*.*", extension.Substring(1, 1).ToUpper() + extension.Substring(2), extension, extension);
				fd.RestoreDirectory = true;
				fd.CheckFileExists = true;

				if (fd.ShowDialog(owner) == DialogResult.OK)
				{
					fileName = fd.FileName;

					return true;
				}
			}
			catch (Exception ex)
			{
				//LogFile.WriteEntry("TryOpenFile", "FileIO", ex.Message, ex.StackTrace);
			}

			return false;
		}

		public static bool TrySaveFile(Control parent, string initialDirectory, string initialFileName, string extension, out string fileName)
		{
			fileName = null;

			try
			{
				SaveFileDialog fd = new SaveFileDialog();

				fd.Title = "Save Layout";
				fd.InitialDirectory = initialDirectory;
				fd.FileName = initialFileName;
				fd.Filter = String.Format("{0} Files (*{1})|*{2}|All Files (*.*)|*.*", extension.Substring(1, 1).ToUpper() + extension.Substring(2), extension, extension);
				fd.OverwritePrompt = true;
				fd.RestoreDirectory = true;

				if (fd.ShowDialog(parent) == DialogResult.OK)
				{
					fileName = fd.FileName;

					return true;
				}
			}
			catch (Exception ex)
			{
				//LogFile.WriteEntry("TrySaveFile", "FileIO", ex.Message, ex.StackTrace);
			}

			return false;
		}

		public static bool TryOpenFolder(Control parent, string selectedPath, out string folder)
		{
			folder = null;

			try
			{
				FolderBrowserDialog fb = new FolderBrowserDialog();

				fb.SelectedPath = selectedPath;
				fb.ShowNewFolderButton = true;

				if (fb.ShowDialog(parent) == DialogResult.OK)
				{
					folder = fb.SelectedPath;

					return true;
				}
			}
			catch (Exception ex)
			{
				//LogFile.WriteEntry("TryOpenFolder", "FileIO", ex.Message, ex.StackTrace);
			}

			return false;
		}

		public static List<FileInfo> GetFileList(string path, string[] searchPattern, bool recursive)
		{
			List<FileInfo> fileList = new List<FileInfo>();

			foreach (string ext in searchPattern)
				fileList.AddRange(GetFileList(path, ext, recursive));

			return fileList;
		}

		public static List<FileInfo> GetFileList(string path, string searchPattern, bool recursive)
		{
			List<FileInfo> fileList = new List<FileInfo>();
			DirectoryInfo di = new DirectoryInfo(path);
			FileInfo[] fileInfo = di.GetFiles(searchPattern);

			DirectoryInfo[] directoryInfo = di.GetDirectories();

			if (recursive)
			{
				foreach (DirectoryInfo diSub in directoryInfo)
					fileList.AddRange(GetFileList(diSub.FullName, searchPattern, recursive));
			}

			foreach (FileInfo fi in fileInfo)
				fileList.Add(fi);

			return fileList;
		}

		public static Bitmap LoadBitmap(string fileName)
		{
			try
			{
				Bitmap bitmap = null;

				switch (Path.GetExtension(fileName))
				{
					case ".pcx":
						Pcx pcx = new Pcx(fileName);
						bitmap = pcx.PcxImage;
						break;
					case ".tga":
						TargaImage targaImage = new TargaImage(fileName);
						bitmap = targaImage.Image;
						break;
					default:
						bitmap = new Bitmap(fileName);
						break;
				}

				return bitmap;
			}
			catch
			{
			}

			return null;
		}
	}
}
