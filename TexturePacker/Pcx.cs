using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace System.Drawing
{
    public class Pcx
    {
        private class PCXHEAD
        {
            public byte[] m_Data = new byte[128];
            public byte Manufacturer { get { return m_Data[0]; } }
            public byte Version { get { return m_Data[1]; } set { m_Data[1] = value; } }
            public byte Encoding { get { return m_Data[2]; } set { m_Data[2] = value; } }
            public byte Bits_Per_Pixel { get { return m_Data[3]; } set { m_Data[3] = value; } }

            public ushort Xmin { get { return BitConverter.ToUInt16(m_Data, 4); } set { SetUshort(4, value); } }
            public ushort Ymin { get { return BitConverter.ToUInt16(m_Data, 6); } set { SetUshort(6, value); } }
            public ushort Xmax { get { return BitConverter.ToUInt16(m_Data, 8); } set { SetUshort(8, value); } }
            public ushort Ymax { get { return BitConverter.ToUInt16(m_Data, 10); } set { SetUshort(10, value); } }
            public ushort Hres1 { get { return BitConverter.ToUInt16(m_Data, 12); } set { SetUshort(12, value); } }
            public ushort Vres1 { get { return BitConverter.ToUInt16(m_Data, 14); } set { SetUshort(14, value); } }

            public byte[] Palette
            {
                get
                {
                    byte[] _Palette = new byte[48];

                    Array.Copy(m_Data, 16, _Palette, 0, 48);

                    return _Palette;
                }
                set
                {
                    if (value.Length != 48)
                        throw new Exception("PCX: byte[] Length != 48");

                    Array.Copy(value, 0, m_Data, 16, 48);
                }
            }

            public byte Reserved { get { return m_Data[64]; } set { m_Data[64] = value; } }
            public byte Colour_Planes { get { return m_Data[65]; } set { m_Data[65] = value; } }
            public ushort Bytes_Per_Line { get { return BitConverter.ToUInt16(m_Data, 66); } set { SetUshort(66, value); } }
            public ushort Palette_Type { get { return BitConverter.ToUInt16(m_Data, 68); } set { SetUshort(68, value); } }

            public byte[] Filler
            {
                get
                {
                    byte[] m_Bytes = new byte[58];

                    Array.Copy(m_Data, 70, m_Bytes, 0, 58);

                    return m_Bytes;
                }
            }

            public PCXHEAD(byte[] p_Data)
            {
                Array.Copy(p_Data, m_Data, 128);
            }

            public PCXHEAD()
            {
                m_Data[0] = 0xA;
                Version = 0x5;
                Encoding = 0x1;
                Bits_Per_Pixel = 0x8;
                Palette = new byte[] { 0x00, 0x00, 0xCD, 0x00, 0x90, 0xE7, 0x37, 0x01, 0x80, 0xF6, 0x95, 0x7C, 0x28, 0xFB, 0x95, 0x7C, 0xFF, 0xFF, 0xFF, 0xFF, 0x23, 0xFB, 0x95, 0x7C, 0xB3, 0x16, 0x34, 0x7C, 0x00, 0x00, 0xCD, 0x00, 0x00, 0x00, 0x00, 0x00, 0xB8, 0x16, 0x34, 0x7C, 0x64, 0xF3, 0x37, 0x01, 0xD8, 0x54, 0xB8, 0x00 };
                Reserved = 0x01;
                Colour_Planes = 0x03;
                Palette_Type = 1;
            }

            public int Width { get { return Xmax - Xmin + 1; } }
            public int Height { get { return Ymax - Ymin + 1; } }

            private void SetUshort(int p_Index, ushort p_Data)
            {
                byte[] _ValueBytes = BitConverter.GetBytes(p_Data);
                m_Data[p_Index] = _ValueBytes[0];
                m_Data[p_Index + 1] = _ValueBytes[1];
            }
        }

        private PCXHEAD m_Head = new PCXHEAD();

        private Bitmap m_Image;

        public Bitmap PcxImage { get { return m_Image; } set { m_Image = value; } }

        public Pcx(string p_FileFullName)
        {
            if (!File.Exists(p_FileFullName))
                return;

            Load(File.ReadAllBytes(p_FileFullName));
        }

        public Pcx(byte[] p_Data)
        {
            Load(p_Data);
        }

        public Pcx()
        {
        }

        private void Load(byte[] p_Bytes)
        {
            byte[] _Bytes = p_Bytes;

            if (_Bytes[0] != 0x0A)
                return;

            m_Head = new PCXHEAD(_Bytes);
            m_ReadIndex = 128;
            PixelFormat _PixFormate = PixelFormat.Format24bppRgb;

            if (m_Head.Colour_Planes == 1)
            {
                switch (m_Head.Bits_Per_Pixel)
                {
                    case 8:
                        _PixFormate = PixelFormat.Format8bppIndexed;
                        break;
                    case 1:
                        _PixFormate = PixelFormat.Format1bppIndexed;
                        break;
                }
            }

            m_Image = new Bitmap(m_Head.Width, m_Head.Height, _PixFormate);
            BitmapData _Data = m_Image.LockBits(new Rectangle(0, 0, m_Image.Width, m_Image.Height), ImageLockMode.ReadWrite, _PixFormate);
            byte[] _BmpData = new byte[_Data.Stride * _Data.Height];

            for (int i = 0; i != m_Head.Height; i++)
            {
                byte[] _RowColorValue = new byte[0];

                switch (m_Head.Colour_Planes)
                {
                    case 3: //24?
                        _RowColorValue = LoadPCXLine24(_Bytes);
                        break;
                    case 1: //256?
                        switch (m_Head.Bits_Per_Pixel)
                        {
                            case 8:
                                _RowColorValue = LoadPCXLine8(_Bytes);
                                break;
                            case 1:
                                _RowColorValue = LoadPCXLine1(_Bytes);
                                break;
                        }

                        break;
                }
                int _Count = _RowColorValue.Length;
                Array.Copy(_RowColorValue, 0, _BmpData, i * _Data.Stride, _Count);
            }
            Marshal.Copy(_BmpData, 0, _Data.Scan0, _BmpData.Length);
            m_Image.UnlockBits(_Data);

            switch (m_Head.Colour_Planes)
            {
                case 1:
                    if (m_Head.Bits_Per_Pixel == 8)
                    {
                        ColorPalette _Palette = m_Image.Palette;
                        m_ReadIndex = p_Bytes.Length - 256 * 3;
                        for (int i = 0; i != 256; i++)
                        {
                            _Palette.Entries[i] = Color.FromArgb(p_Bytes[m_ReadIndex], p_Bytes[m_ReadIndex + 1], p_Bytes[m_ReadIndex + 2]);
                            m_ReadIndex += 3;
                        }
                        m_Image.Palette = _Palette;
                    }
                    break;
            }
        }

        public void Save(string p_FileFullName)
        {
            if (m_Image == null) return;
            m_Head.Xmax = (ushort)(m_Image.Width - 1);
            m_Head.Ymax = (ushort)(m_Image.Height - 1);
            m_Head.Vres1 = (ushort)(m_Head.Xmax + 1);
            m_Head.Hres1 = (ushort)(m_Head.Ymax + 1);
            m_Head.Bytes_Per_Line = (ushort)m_Head.Width;

            MemoryStream _SaveData = new MemoryStream();

            switch (m_Image.PixelFormat)
            {
                case PixelFormat.Format8bppIndexed:
                    m_Head.Colour_Planes = 1;
                    BitmapData _ImageData = m_Image.LockBits(new Rectangle(0, 0, m_Head.Width, m_Head.Height), ImageLockMode.ReadOnly, m_Image.PixelFormat);
                    byte[] _ImageByte = new byte[_ImageData.Stride * _ImageData.Height];
                    Marshal.Copy(_ImageData.Scan0, _ImageByte, 0, _ImageByte.Length);
                    m_Image.UnlockBits(_ImageData);

                    m_SaveIndex = 0;
                    byte[] _RowBytes = SavePCXLine8(_ImageByte);
                    _SaveData.Write(_RowBytes, 0, _RowBytes.Length);

                    _SaveData.WriteByte(0x0C);
                    for (int i = 0; i != 256; i++)
                    {
                        _SaveData.WriteByte((byte)m_Image.Palette.Entries[i].R);
                        _SaveData.WriteByte((byte)m_Image.Palette.Entries[i].G);
                        _SaveData.WriteByte((byte)m_Image.Palette.Entries[i].B);
                    }
                    break;
                default:
                    m_Head.Colour_Planes = 3;
                    Bitmap _Bitamp24 = new Bitmap(m_Head.Width, m_Head.Height, PixelFormat.Format24bppRgb);
                    Graphics _Graphics = Graphics.FromImage(_Bitamp24);
                    _Graphics.DrawImage(m_Image, 0, 0, m_Head.Width, m_Head.Height);
                    _Graphics.Dispose();
                    BitmapData _ImageData24 = _Bitamp24.LockBits(new Rectangle(0, 0, m_Head.Width, m_Head.Height), ImageLockMode.ReadOnly, _Bitamp24.PixelFormat);
                    byte[] _ImageByte24 = new byte[_ImageData24.Stride * _ImageData24.Height];
                    Marshal.Copy(_ImageData24.Scan0, _ImageByte24, 0, _ImageByte24.Length);
                    _Bitamp24.UnlockBits(_ImageData24);
                    m_SaveIndex = 0;
                    for (int i = 0; i != _ImageData24.Height; i++)
                    {
                        m_SaveIndex = i * _ImageData24.Stride;  //2009-10-11 ?? PCX????
                        byte[] _RowBytes24 = SavePCXLine24(_ImageByte24);
                        _SaveData.Write(_RowBytes24, 0, _RowBytes24.Length);
                    }
                    _SaveData.WriteByte(0x0C);
                    _SaveData.Write(new byte[768], 0, 768);

                    break;
            }
            FileStream _FileStream = new FileStream(p_FileFullName, FileMode.Create, FileAccess.Write);
            _FileStream.Write(m_Head.m_Data, 0, 128);
            byte[] _FileData = _SaveData.ToArray();
            _FileStream.Write(_FileData, 0, _FileData.Length);
            _FileStream.Close();
        }

        private int m_ReadIndex = 0;

        private byte[] LoadPCXLine24(byte[] p_Data)
        {
            int _LineWidth = m_Head.Bytes_Per_Line;
            byte[] _ReturnBytes = new byte[_LineWidth * 3];
            int _EndBytesLength = p_Data.Length - 1;
            int _WriteIndex = 2;
            int _ReadIndex = 0;
            while (true)
            {
                if (m_ReadIndex > _EndBytesLength) break;
                byte _Data = p_Data[m_ReadIndex];

                if (_Data > 0xC0)
                {
                    int _Count = _Data - 0xC0;
                    m_ReadIndex++;
                    for (int i = 0; i != _Count; i++)
                    {
                        if (i + _ReadIndex >= _LineWidth)
                        {
                            _WriteIndex--;
                            _ReadIndex = 0;
                            _Count = _Count - i;
                            i = 0;
                        }
                        int _RVA = ((i + _ReadIndex) * 3) + _WriteIndex;
                        _ReturnBytes[_RVA] = p_Data[m_ReadIndex];
                    }
                    _ReadIndex += _Count;
                    m_ReadIndex++;
                }
                else
                {
                    int _RVA = (_ReadIndex * 3) + _WriteIndex;
                    _ReturnBytes[_RVA] = _Data;
                    m_ReadIndex++;
                    _ReadIndex++;
                }
                if (_ReadIndex >= _LineWidth)
                {
                    _WriteIndex--;
                    _ReadIndex = 0;
                }

                if (_WriteIndex == -1) break;
            }
            return _ReturnBytes;
        }

        private byte[] LoadPCXLine8(byte[] p_Data)
        {
            int _LineWidth = m_Head.Bytes_Per_Line;
            byte[] _ReturnBytes = new byte[_LineWidth];
            int _EndBytesLength = p_Data.Length - 1 - (256 * 3);
            int _ReadIndex = 0;

            while (true)
            {
                if (m_ReadIndex > _EndBytesLength)
                    break;

                byte _Data = p_Data[m_ReadIndex];

                if (_Data > 0xC0)
                {
                    int _Count = _Data - 0xC0;
                    m_ReadIndex++;
                    for (int i = 0; i != _Count; i++)
                    {
                        _ReturnBytes[i + _ReadIndex] = p_Data[m_ReadIndex];
                    }
                    _ReadIndex += _Count;
                    m_ReadIndex++;
                }
                else
                {
                    _ReturnBytes[_ReadIndex] = _Data;
                    m_ReadIndex++;
                    _ReadIndex++;
                }

                if (_ReadIndex >= _LineWidth)
                    break;
            }
            return _ReturnBytes;
        }

        private byte[] LoadPCXLine1(byte[] p_Data)
        {
            int _LineWidth = m_Head.Bytes_Per_Line;
            byte[] _ReturnBytes = new byte[_LineWidth];
            int _ReadIndex = 0;
            while (true)
            {
                byte _Data = p_Data[m_ReadIndex];
                if (_Data > 0xC0)
                {
                    int _Count = _Data - 0xC0;
                    m_ReadIndex++;
                    for (int i = 0; i != _Count; i++)
                    {
                        _ReturnBytes[i + _ReadIndex] = p_Data[m_ReadIndex];
                    }
                    _ReadIndex += _Count;
                    m_ReadIndex++;
                }
                else
                {
                    _ReturnBytes[_ReadIndex] = _Data;
                    m_ReadIndex++;
                    _ReadIndex++;
                }
                if (_ReadIndex >= _LineWidth)
                    break;
            }
            return _ReturnBytes;
        }

        private int m_SaveIndex = 0;

        private byte[] SavePCXLine8(byte[] p_Data)
        {
            MemoryStream _Memory = new MemoryStream();
            byte _Value = p_Data[m_SaveIndex];
            byte _Count = 1;
            for (int i = 1; i != p_Data.Length; i++)
            {
                byte _Temp = p_Data[m_SaveIndex + i];
                if (_Temp == _Value)
                {
                    _Count++;
                    if (_Count == 63)
                    {
                        _Memory.WriteByte(0xFF);
                        _Memory.WriteByte(_Value);
                        _Count = 0;
                    }
                }
                else
                {
                    if (_Count == 1 && _Value < 0xC0 && _Value != 0x00)
                    {
                        _Memory.WriteByte(_Value);
                    }
                    else
                    {
                        _Memory.WriteByte((byte)(0xC0 + _Count));
                        _Memory.WriteByte(_Value);
                    }
                    _Count = 1;
                    _Value = _Temp;
                }
            }
            if (_Count == 1 && _Value < 0xC0 && _Value != 0x00)
            {
                _Memory.WriteByte(_Value);
            }
            else
            {
                _Memory.WriteByte((byte)(0xC0 + _Count));
                _Memory.WriteByte(_Value);
            }
            return _Memory.ToArray();
        }

        private byte[] SavePCXLine24(byte[] p_Data)
        {
            MemoryStream _Read = new MemoryStream();
            MemoryStream _Green = new MemoryStream();
            MemoryStream _Blue = new MemoryStream();

            for (int i = 0; i != m_Head.Width; i++)
            {
                _Read.WriteByte(p_Data[m_SaveIndex + 2]);
                _Green.WriteByte(p_Data[m_SaveIndex + 1]);
                _Blue.WriteByte(p_Data[m_SaveIndex]);
                m_SaveIndex += 3;
            }

            MemoryStream _All = new MemoryStream();
            int _OleIndex = m_SaveIndex;
            m_SaveIndex = 0;
            byte[] _Bytes = SavePCXLine8(_Read.ToArray());
            _All.Write(_Bytes, 0, _Bytes.Length);
            m_SaveIndex = 0;
            _Bytes = SavePCXLine8(_Green.ToArray());
            _All.Write(_Bytes, 0, _Bytes.Length);
            m_SaveIndex = 0;
            _Bytes = SavePCXLine8(_Blue.ToArray());
            _All.Write(_Bytes, 0, _Bytes.Length);
            m_SaveIndex = _OleIndex;

            return _All.ToArray();
        }
    }
}