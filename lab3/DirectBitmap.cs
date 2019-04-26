using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class DirectBitmap : IDisposable
    {
        public Bitmap Bitmap { get; set; }
        public bool Disposed { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public Size Size { get { return new Size(Width, Height); } }

        private Int32[] Bits;

        protected GCHandle BitsHandle { get; private set; }

        public static DirectBitmap FromBitmap(Bitmap bitmap)
        {
            DirectBitmap directBitmap = new DirectBitmap(bitmap.Width, bitmap.Height);

            var data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                           ImageLockMode.ReadOnly,
                           PixelFormat.Format32bppPArgb);

            unsafe // This section is needed to quickly load image, over 4x boost
            {
                var pt = (Int32*)data.Scan0;
                for (int row = 0; row < directBitmap.Height; ++row)
                {
                    for (int column = 0; column < directBitmap.Width; ++column)
                    {
                        int pixelCode = *(pt + (row * directBitmap.Width) + column);
                        directBitmap.SetPixel(column, row, Color.FromArgb(pixelCode));
                    }
                }
            }

            bitmap.UnlockBits(data);

            return directBitmap;
        }

        public DirectBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new Int32[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        public void SetPixel(int x, int y, Color colour)
        {
            int index = x + (y * Width);
            Bits[index] = colour.ToArgb();
        }

        public Color GetPixel(int x, int y)
        {
            int index = x + (y * Width);
            int col = Bits[index];

            return Color.FromArgb(col);
        }

        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }
    }
}
