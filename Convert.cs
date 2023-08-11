using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TexturePacker
{
    class Convert
    {
        public static int StrToInt(string val)
        {
            int result = 0;

            if (Int32.TryParse(val, out result))
                return result;

            return result;
        }

        public static Single StrToSingle(string val)
        {
            float result = 0;

            if (Single.TryParse(val, out result))
                return result;
            return 0;
        }

        public static byte StrToByte(string val)
        {
            byte result = 0;

            if (Byte.TryParse(val, out result))
                return result;

            return result;
        }

        public static bool StrToBool(string val)
        {
            if (String.IsNullOrEmpty(val))
                return false;

            if (val.Trim().ToLower() == "true" || val.Trim() == "1")
                return true;
            else
                return false;
        }

        public static string SizeToStr(Size size)
        {
            return String.Format("{0},{1}", size.Width, size.Height);
        }

        public static Size StrToSize(string str)
        {
            string[] strSplit = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (strSplit.Length == 2)
                return new Size(StrToInt(strSplit[0]), StrToInt(strSplit[1]));

            return Size.Empty;
        }

        public static string SingleToString(Single val)
        {
            return val.ToString();
        }

        public static string PointToStr(Point point)
        {
            return String.Format("{0},{1}", point.X, point.Y);
        }

        public static Point StrToPoint(string str)
        {
            string[] strSplit = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (strSplit.Length == 2)
                return new Point(StrToInt(strSplit[0]), StrToInt(strSplit[1]));

            return Point.Empty;
        }

        public static string RemoveWhiteSpace(string val)
        {
            if (String.IsNullOrEmpty(val))
                return val;

            return val.Replace(" ", "");
        }

        public static Size ResizeImage(Size oldSize, Size newSize)
        {
            if (oldSize.Width >= oldSize.Height)
            {
                if (oldSize.Width > newSize.Width)
                    return new Size(newSize.Width, (int)((float)oldSize.Height * ((float)newSize.Width / (float)oldSize.Width)));
                else if (oldSize.Height > newSize.Height)
                    return new Size((int)((float)oldSize.Width * ((float)newSize.Height / (float)oldSize.Height)), newSize.Height);
            }
            else
            {
                if (oldSize.Height > newSize.Height)
                    return new Size((int)((float)oldSize.Width * ((float)newSize.Height / (float)oldSize.Height)), newSize.Height);
                else if (oldSize.Width > newSize.Width)
                    return new Size(newSize.Width, (int)((float)oldSize.Height * ((float)newSize.Width / (float)oldSize.Width)));
            }

            return oldSize;
        }

        public static Size GetNearestPower2Size(Size source, Size max)
        {
            Size ret = new Size(1, 1);

            while (ret.Width < source.Width)
                ret.Width <<= 1;
            while (ret.Height < source.Height)
                ret.Height <<= 1;

            if (ret.Width > max.Width)
                ret.Width = max.Width;
            if (ret.Height > max.Height)
                ret.Height = max.Height;

            return ret;
        }

        public static bool IsPowerOfTwo(int x)
        {
            return (x & (x - 1)) == 0;
        }
    }
}
