using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Collections;

namespace TexturePacker
{
	public class CacheNode
	{
		public string Name = null;
		public string Path = null;
		public string Extension = null;
		public Size TextureSize = new Size(1024, 1024);
		public bool Clamp = true;
		public bool Linear = true;
		public bool ColorKey = false;
		public int PixelSpacing = 1;
		public bool FillSpacing = false;
		public Size MaxSize = new Size(128, 128);
		public bool KeepAspect = true;
		public bool LimitSize = false;
		public bool BilinearFilter = false;
		public bool Recursive = false;
		public bool ForceTextureRemake = false;

		public CacheNode()
		{
		}

		public CacheNode(Size textureSize, bool clamp, bool linear, bool recursive, bool colorKey)
		{
			TextureSize = textureSize;
			Clamp = clamp;
			Linear = linear;
			Recursive = recursive;
			ColorKey = colorKey;
		}

		public void ReadIni(string fileName)
		{
			using (IniFile iniFile = new IniFile(fileName))
				ReadIni(iniFile, "General");
		}

		public void ReadIni(IniFile iniFile, string name)
		{
			Name = iniFile.Read(name, "Name", Name);
			Path = iniFile.Read(name, "Path", Path);
			Extension = iniFile.Read(name, "Extension", Extension);
			TextureSize = iniFile.Read<Size>(name, "TextureSize", TextureSize);
			Clamp = iniFile.Read<bool>(name, "Clamp", Clamp);
			Linear = iniFile.Read<bool>(name, "Linear", Linear);
			ColorKey = iniFile.Read<bool>(name, "ColorKey", ColorKey);
			PixelSpacing = iniFile.Read<int>(name, "PixelSpacing", PixelSpacing);
			FillSpacing = iniFile.Read<bool>(name, "FillSpacing", FillSpacing);
			MaxSize = iniFile.Read<Size>(name, "MaxSize", MaxSize);
			KeepAspect = iniFile.Read<bool>(name, "KeepAspect", KeepAspect);
			LimitSize = iniFile.Read<bool>(name, "LimitSize", LimitSize);
			BilinearFilter = iniFile.Read<bool>(name, "BilinearFilter", BilinearFilter);
			Recursive = iniFile.Read<bool>(name, "Recursive", Recursive);
			ForceTextureRemake = iniFile.Read<bool>(name, "ForceTextureRemake", ForceTextureRemake);
		}

		public void WriteIni(string fileName)
		{
			using (IniFile iniFile = new IniFile(fileName))
				WriteIni(iniFile, "General");
		}

		public void WriteIni(IniFile iniFile, string name)
		{
			iniFile.Write(name, "Name", Name);
			iniFile.Write(name, "Path", Path);
			iniFile.Write(name, "Extension", Extension);
			iniFile.Write<Size>(name, "TextureSize", TextureSize);
			iniFile.Write<bool>(name, "Clamp", Clamp);
			iniFile.Write<bool>(name, "Linear", Linear);
			iniFile.Write<bool>(name, "ColorKey", ColorKey);
			iniFile.Write<int>(name, "PixelSpacing", PixelSpacing);
			iniFile.Write<bool>(name, "FillSpacing", FillSpacing);
			iniFile.Write<Size>(name, "MaxSize", MaxSize);
			iniFile.Write<bool>(name, "KeepAspect", KeepAspect);
			iniFile.Write<bool>(name, "LimitSize", LimitSize);
			iniFile.Write<bool>(name, "BilinearFilter", BilinearFilter);
			iniFile.Write<bool>(name, "Recursive", Recursive);
			iniFile.Write<bool>(name, "ForceTextureRemake", ForceTextureRemake);
		}
	}

	public class ImageAtlasNode : IComparer<ImageAtlasNode>
	{
		public int Index;
		public string FileName;
		public Size Size;
		public bool Processed = false;

		public ImageAtlasNode()
		{
		}

		public ImageAtlasNode(int index, string fileName)
		{
			Index = index;
			FileName = fileName;

			ImageHeader.TryGetDimensions(fileName, out Size);
		}

		#region IComparer<ImageAtlasNode> Members

		public int Compare(ImageAtlasNode x, ImageAtlasNode y)
		{
			return x.FileName.CompareTo(y.FileName);
		}

		#endregion
	}

	public class BitmapSizeComparer : IComparer<ImageAtlasNode>
	{
		public int Compare(ImageAtlasNode x, ImageAtlasNode y)
		{
			int width = -(x.Size.Width).CompareTo(y.Size.Width);
			int height = -(x.Size.Height).CompareTo(y.Size.Height);

			if (width == 0 && height == 0)
				return x.Index.CompareTo(y.Index);

			return (width != 0 ? width : height);
		}
	}

	public class ImageNode : IComparer<ImageNode>
	{
		public int Id = -1;
		public string FileName = String.Empty;
		public string Name = String.Empty;
		public int X = 0;
		public int Y = 0;
		public int Width = 0;
		public int Height = 0;
		public long LastWriteTime = 0;
		public TextureNode TextureNode = null;
		public Rectangle Rect { get { return new Rectangle(X, Y, Width, Height); } }
		public RectangleF RectF { get { return new RectangleF((float)X / TextureNode.TextureSize.Width, (float)Y / TextureNode.TextureSize.Height, (float)Width / TextureNode.TextureSize.Width, (float)Height / TextureNode.TextureSize.Height); } }

		public ImageNode()
		{
		}

		public ImageNode(TextureNode textureNode)
		{
			TextureNode = textureNode;
			FileName = textureNode.FileName;
			Name = textureNode.Name;
			Width = textureNode.TextureSize.Width;
			Height = textureNode.TextureSize.Height;
		}

		public ImageNode(TextureNode textureNode, int id, string fileName, string name, int x, int y, int width, int height, long lastWriteTime)
		{
			TextureNode = textureNode;
			Id = id;
			FileName = fileName;
			Name = name;
			X = x;
			Y = y;
			Width = width;
			Height = height;
			LastWriteTime = lastWriteTime;
		}

		#region IComparer<ImageNode> Members

		public int Compare(ImageNode x, ImageNode y)
		{
			return x.Name.CompareTo(y.Name);
		}

		#endregion
	};

	public class TextureNode
	{
		private enum XmlElement
		{
			None,
			Texture,
			Image
		}

		public string FileName = String.Empty;
		public string Name = String.Empty;
		public string Path = String.Empty;
		public Size TextureSize = Size.Empty;
		public bool Clamp = true;
		public bool Linear = true;
		public bool ColorKey = false;
		//public Texture2D Texture = null;
		public List<ImageNode> ImageList = null;
		public bool UseRefCount = true;
		public int RefCount = 0;

		public TextureNode()
		{
			ImageList = new List<ImageNode>();
		}

		/* public TextureNode(string name, Texture2D texture)
		{
			Name = name;
			Texture = texture;
			FileName = texture.FileName;
			TextureSize = texture.Size;
			Clamp = texture.Clamp;
			Linear = texture.Linear;
			ImageList = new List<ImageNode>();
		} */

		public TextureNode(string fileName, string name, int width, int height)
		{
			FileName = fileName;
			Name = name;
			TextureSize = new Size(width, height);
			ImageList = new List<ImageNode>();
		}

		public TextureNode(string fileName, string name, bool clamp, bool linear)
		{
			FileName = fileName;
			Name = name;
			Clamp = clamp;
			Linear = linear;
			ImageList = new List<ImageNode>();
		}

		public TextureNode(string fileName, string name, int width, int height, bool clamp, bool linear)
		{
			FileName = fileName;
			Name = name;
			TextureSize = new Size(width, height);
			Clamp = clamp;
			Linear = linear;
			ImageList = new List<ImageNode>();
		}

		public static TextureNode ReadXml(string fileName)
		{
			XmlReader xmlReader = null;
			XmlElement xmlElement = XmlElement.None;
			Hashtable attribHash = new Hashtable();
			TextureNode textureNode = null;

			try
			{
				xmlReader = XmlReader.Create(fileName);

				xmlReader.Read();

				while (xmlReader.Read())
				{
					switch (xmlReader.NodeType)
					{
						case XmlNodeType.Element:
							switch (xmlReader.LocalName.ToLower())
							{
								case "texture":
									xmlElement = XmlElement.Texture;
									textureNode = new TextureNode();
									break;
								case "image":
									xmlElement = XmlElement.Image;
									break;
								default:
									xmlElement = XmlElement.None;
									break;
							}

							if (xmlReader.HasAttributes)
							{
								attribHash.Clear();
								while (xmlReader.MoveToNextAttribute())
									attribHash.Add(xmlReader.Name.ToLower(), xmlReader.Value);
							}

							switch (xmlElement)
							{
								case XmlElement.Texture:
									if (textureNode != null)
									{
										textureNode.FileName = System.IO.Path.Combine((string)attribHash["path"], (string)attribHash["name"]);
										textureNode.Name = (string)attribHash["name"];
										textureNode.Path = (string)attribHash["path"];
										textureNode.TextureSize = StringTools.FromString<Size>((string)attribHash["texturesize"]);
										textureNode.Clamp = StringTools.FromString<bool>((string)attribHash["clamp"]);
										textureNode.Linear = StringTools.FromString<bool>((string)attribHash["linear"]);
										textureNode.ColorKey = StringTools.FromString<bool>((string)attribHash["colorkey"]);
									}
									break;
								case XmlElement.Image:
									if (textureNode != null)
										textureNode.ImageList.Add(new ImageNode(textureNode, StringTools.FromString<int>((string)attribHash["id"]), System.IO.Path.Combine(textureNode.Path, (string)attribHash["name"]), (string)attribHash["name"], StringTools.FromString<int>((string)attribHash["x"]), StringTools.FromString<int>((string)attribHash["y"]), StringTools.FromString<int>((string)attribHash["width"]), StringTools.FromString<int>((string)attribHash["height"]), StringTools.FromString<long>((string)attribHash["lastwritetime"])));
									break;
								default:
									break;
							}

							xmlReader.MoveToElement();
							break;

						case XmlNodeType.Text:
							string text = xmlReader.Value.Trim();
							switch (xmlElement)
							{
								default:
									break;
							}
							break;

						case XmlNodeType.EndElement:
							switch (xmlElement)
							{
								case XmlElement.Texture:
									textureNode = null;
									break;
								default:
									break;
							}
							break;
					}
				}
			}
			catch (Exception ex)
			{
				//LogFile.WriteLine("ReadTextureXml", "TextureManager", ex.Message, ex.StackTrace);
			}
			finally
			{
				if (xmlReader != null)
				{
					xmlReader.Close();
					xmlReader = null;
				}
			}

			return textureNode;
		}

		/* public void WriteXml()
		{
			WriteIni(TextureManager.UseFileCache);
		}

		public void WriteXml(bool useFileCache)
		{
			string xmlFileName = GetXmlFileName(useFileCache);

			WriteXml(xmlFileName, this);
		} */

		public static void WriteXml(string fileName, TextureNode textureNode)
		{
			XmlWriter xmlWriter = null;

			try
			{
				XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
				xmlWriterSettings.Encoding = Encoding.UTF8;
				xmlWriterSettings.Indent = true;

				xmlWriter = XmlWriter.Create(fileName, xmlWriterSettings);

				xmlWriter.WriteStartDocument();

				xmlWriter.WriteStartElement("Texture");

				xmlWriter.WriteAttributeString("Name", textureNode.Name);
				xmlWriter.WriteAttributeString("Path", textureNode.Path);
				xmlWriter.WriteAttributeString("TextureSize", StringTools.ToString<Size>(textureNode.TextureSize));
				xmlWriter.WriteAttributeString("Clamp", textureNode.Clamp.ToString());
				xmlWriter.WriteAttributeString("Linear", textureNode.Linear.ToString());
				xmlWriter.WriteAttributeString("ColorKey", textureNode.ColorKey.ToString());

				foreach (ImageNode imageNode in textureNode.ImageList)
				{
					xmlWriter.WriteStartElement("Image");

					xmlWriter.WriteAttributeString("Id", imageNode.Id.ToString());
					xmlWriter.WriteAttributeString("Name", imageNode.Name);
					xmlWriter.WriteAttributeString("X", imageNode.X.ToString());
					xmlWriter.WriteAttributeString("Y", imageNode.Y.ToString());
					xmlWriter.WriteAttributeString("Width", imageNode.Width.ToString());
					xmlWriter.WriteAttributeString("Height", imageNode.Height.ToString());
					xmlWriter.WriteAttributeString("LastWriteTime", imageNode.LastWriteTime.ToString());

					xmlWriter.WriteEndElement();
				}

				xmlWriter.WriteEndElement();
				xmlWriter.WriteEndDocument();
			}
			catch (Exception ex)
			{
				//LogFile.WriteLine("WriteTextureXml", "TextureManager", ex.Message, ex.StackTrace);
			}
			finally
			{
				if (xmlWriter != null)
				{
					xmlWriter.Flush();
					xmlWriter.Close();
					xmlWriter = null;
				}
			}
		}

		public void WriteXml(string fileName)
		{
			WriteXml(fileName, this);
		}

		public void WriteTxt(string fileName)
		{
			List<string> textList = new List<string>();

			textList.Add(String.Format("texture name={0} width={1} height={2} imageCount={3}", Name, TextureSize.Width, TextureSize.Height, ImageList.Count));

			foreach (ImageNode imageNode in ImageList)
				textList.Add(String.Format("image name={0} x={1} y={2} width={3} height={4}", imageNode.Name, imageNode.X, imageNode.Y, imageNode.Width, imageNode.Height));

			File.WriteAllLines(fileName, textList.ToArray());
		}

		private long UnixTimeNow()
		{
			var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
			return (long)timeSpan.TotalSeconds;
		}

		public void WriteMeta(string fileName)
		{
			List<string> textList = new List<string>();

			textList.Add("fileFormatVersion: 2");
			textList.Add(String.Format("guid: {0}", Guid.NewGuid().ToString("N")));
			textList.Add(String.Format("timeCreated: {0}", UnixTimeNow()));
			textList.Add("licenseType: Pro");
			textList.Add("TextureImporter:");
			textList.Add("  fileIDToRecycleName:");

			int fileID = 21300000;

			foreach (ImageNode imageNode in ImageList)
			{
				textList.Add(String.Format("    {0}: {1}", fileID, System.IO.Path.GetFileNameWithoutExtension(imageNode.Name)));

				fileID += 2;
			}

			textList.Add("  serializedVersion: 4");
			textList.Add("  mipmaps:");
			textList.Add("    mipMapMode: 0");
			textList.Add("    enableMipMap: 0");
			textList.Add("    sRGBTexture: 1");
			textList.Add("    linearTexture: 0");
			textList.Add("    fadeOut: 0");
			textList.Add("    borderMipMap: 0");
			textList.Add("    mipMapFadeDistanceStart: 1");
			textList.Add("    mipMapFadeDistanceEnd: 3");
			textList.Add("  bumpmap:");
			textList.Add("    convertToNormalMap: 0");
			textList.Add("    externalNormalMap: 0");
			textList.Add("    heightScale: 0.25");
			textList.Add("    normalMapFilter: 0");
			textList.Add("  isReadable: 0");
			textList.Add("  grayScaleToAlpha: 0");
			textList.Add("  generateCubemap: 6");
			textList.Add("  cubemapConvolution: 0");
			textList.Add("  seamlessCubemap: 0");
			textList.Add("  textureFormat: -3");
			textList.Add("  maxTextureSize: 2048");
			textList.Add("  textureSettings:");
			textList.Add("    filterMode: -1");
			textList.Add("    aniso: 16");
			textList.Add("    mipBias: -1");
			textList.Add("    wrapMode: 1");
			textList.Add("  nPOTScale: 0");
			textList.Add("  lightmap: 0");
			textList.Add("  compressionQuality: 50");
			textList.Add("  spriteMode: 2");
			textList.Add("  spriteExtrude: 1");
			textList.Add("  spriteMeshType: 0");
			textList.Add("  alignment: 0");
			textList.Add("  spritePivot: {x: 0.5, y: 0.5}");
			textList.Add("  spriteBorder: {x: 0, y: 0, z: 0, w: 0}");
			textList.Add("  spritePixelsToUnits: 1");
			textList.Add("  alphaUsage: 1");
			textList.Add("  alphaIsTransparency: 1");
			textList.Add("  spriteTessellationDetail: -1");
			textList.Add("  textureType: 8");
			textList.Add("  textureShape: 1");
			textList.Add("  maxTextureSizeSet: 0");
			textList.Add("  compressionQualitySet: 0");
			textList.Add("  textureFormatSet: 0");
			textList.Add("  platformSettings:");
			textList.Add("  - buildTarget: DefaultTexturePlatform");
			textList.Add("    maxTextureSize: 2048");
			textList.Add("    textureFormat: -1");
			textList.Add("    textureCompression: 0");
			textList.Add("    compressionQuality: 50");
			textList.Add("    crunchedCompression: 0");
			textList.Add("    allowsAlphaSplitting: 0");
			textList.Add("    overridden: 0");
			textList.Add("  - buildTarget: Standalone");
			textList.Add("    maxTextureSize: 2048");
			textList.Add("    textureFormat: -1");
			textList.Add("    textureCompression: 0");
			textList.Add("    compressionQuality: 50");
			textList.Add("    crunchedCompression: 0");
			textList.Add("    allowsAlphaSplitting: 0");
			textList.Add("    overridden: 0");
			textList.Add("  spriteSheet:");
			textList.Add("    serializedVersion: 2");
			textList.Add("    sprites:");

			foreach (ImageNode imageNode in ImageList)
			{
				textList.Add("    - serializedVersion: 2");
				textList.Add(String.Format("      name: {0}", System.IO.Path.GetFileNameWithoutExtension(imageNode.Name)));
				textList.Add("      rect:");
				textList.Add("        serializedVersion: 2");
				textList.Add(String.Format("        x: {0}", imageNode.X));
				textList.Add(String.Format("        y: {0}", TextureSize.Height - imageNode.Y - imageNode.Height));
				textList.Add(String.Format("        width: {0}", imageNode.Width));
				textList.Add(String.Format("        height: {0}", imageNode.Height));
				textList.Add("      alignment: 0");
				textList.Add("      pivot: {x: 0.5, y: 0.5}");
				textList.Add("      border: {x: 0, y: 0, z: 0, w: 0}");
				textList.Add("      outline: []");
				textList.Add("      tessellationDetail: -1");
			}

			textList.Add("    outline: []");
			textList.Add("  spritePackingTag: ");
			textList.Add("  userData: ");
			textList.Add("  assetBundleName: ");
			textList.Add("  assetBundleVariant: ");

			File.WriteAllLines(fileName, textList.ToArray());
		}

		public int ImageCount
		{
			get { return ImageList.Count; }
		}
	}
}
