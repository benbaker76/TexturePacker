using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Collections;

namespace TexturePacker
{
    public enum FileFormat
    {
        Text,
        Xml,
		Meta
    };

    public class Globals
    {
        public const int MAX_FOLDERS = 10;

        public static string[] TextureFormats =
        {
            ".png",
            ".bmp",
            ".jpg",
            ".gif",
            ".tif"
        };
    }

    public class Settings
    {
        public class General
        {
            public static bool Recursive = false;
            public static string SearchExt = "*.png,*.bmp,*.jpg,*.gif,*.tif,*.pcx,*.tga";
            public static string Name = "texture";
            public static string TextureFormat = ".png";
			public static FileFormat FileFormat = FileFormat.Text;
            public static bool MultiTexture = true;
            public static int TextureWidth = 512;
            public static int TextureHeight = 512;
            public static bool Alpha = true;
            public static bool Color = false;
            public static System.Drawing.Color BackColor = System.Drawing.Color.Black;
            public static int Spacing = 0;
            public static bool FillSpacing = true;
            public static bool LimitSize = false;
            public static bool NearestPower2 = false;
            public static bool KeepAspect = false;
            public static bool NearestNeighbor = true;
            public static bool Bilinear = false;
            public static int ImageWidth = 128;
            public static int ImageHeight = 128;
        }

        public class Batch
        {
            public static bool Execute = false;
            public static string Name = "run.bat";
            public static string Text = "@ECHO OFF[br]ECHO Name: %1[br]ECHO Name+Ext: %2[br]ECHO Path: %3[br]ECHO Path+Ext: %4[br]ECHO Ext: %5";
        }

        public class File
        {
            public static string FileName = "TexturePacker.ini";
            public static string DefaultFileName = "TexturePacker.ini";
            public static List<string> FolderList = new List<string>();
        }
    }
}
