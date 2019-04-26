using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// An array which contains red colors to create the histogram
        /// </summary>
        public int[] histRed;
        /// <summary>
        /// Deep copy of array histRed
        /// </summary>
        public int[] chistRed;
        /// <summary>
        /// An array which contains blue colors to create the histogram
        /// </summary>
        public int[] histBlue;
        /// <summary>
        /// Deep copy of array histBlue
        /// </summary>
        public int[] chistBlue;
        /// <summary>
        /// An array which contains green colors to create the histogram
        /// </summary>
        public int[] histGreen;
        /// <summary>
        /// Deep copy of array histGreen
        /// </summary>
        public int[] chistGreen;
        /// <summary>
        /// Index matrix for Ordered Dithering
        /// </summary>
        public int[][,] indexArr;
        /// <summary>
        /// Variables from the user for algorithms
        /// </summary>
        public int Kr, Kg, Kb, K;
        /// <summary>
        /// A texture path
        /// </summary>
        public string texture_path;
        /// <summary>
        /// An original image
        /// </summary>
        public DirectBitmap original_texture;
        /// <summary>
        /// A dithered image
        /// </summary>
        public DirectBitmap dithering_texture;
        /// <summary>
        /// Default texture path
        /// </summary>
        public string default_texture_path;
        /// <summary>
        /// Initializing fields
        /// </summary>
        public void InitializeDefault()
        {
            Kr = 2;
            Kg = 2;
            Kb = 2;
            K = 40;

            histRed = new int[256];
            histBlue = new int[256];
            histGreen = new int[256];

            chistRed = new int[256];
            chistBlue = new int[256];
            chistGreen = new int[256];

            indexArr = new int[17][,];
            indexArr[2] = new int[2, 2] { { 3, 2 },
                                          { 1, 0 } };

            indexArr[3] = new int[3, 3] { { 8, 5, 2 },
                                          { 6, 3, 0 },
                                          { 7, 4, 1 } };

            indexArr[4] = new int[4, 4] { { 0, 8, 2, 10 },
                                          { 12, 4, 14, 6 },
                                          { 3, 11, 1, 9 },
                                          { 15, 7, 13, 5 } };

            indexArr[6] = new int[6, 6] { { 21, 30, 9, 18, 33, 6 },
                                          { 1, 16, 25, 4, 13, 28 },
                                          { 23, 32, 11, 20, 35, 8 },
                                          { 3, 12, 27, 0, 15, 24 },
                                          { 19, 34, 7, 22, 31, 10 },
                                          { 5, 14, 29, 2, 17, 26} };

            indexArr[8] = new int[8, 8] { { 0, 48, 12, 60, 3, 51, 15, 63 },
                                          { 32, 16, 44, 28, 35, 19, 47, 31 },
                                          { 8, 56, 4, 52, 11, 59, 7, 55 },
                                          { 40, 24, 36, 20, 43, 27, 39, 23 },
                                          { 2, 50, 14, 62, 1, 49, 13, 61 },
                                          { 34, 18, 46, 30, 33, 17, 45, 29 },
                                          { 10, 58, 6, 54, 9, 57, 5, 53 },
                                          { 42, 26, 38, 22, 41, 25, 37, 21 } };

            indexArr[12] = new int[12, 12] { { 78, 105, 120, 3, 30, 57, 72, 99, 126, 9, 24, 51 },
                                             { 118, 133, 16, 43, 70, 85, 112, 139, 22, 37, 64, 91 },
                                             { 2, 29, 56, 83, 98, 125, 8, 35, 50, 77, 104, 131 },
                                             { 42, 69, 84, 111, 138, 21, 36, 63, 90, 117, 132, 15 },
                                             { 82, 97, 124, 7, 34, 49, 76, 103, 130, 1, 28, 55 },
                                             { 110, 137, 20, 47, 62, 89, 116, 143, 14, 41, 68, 95 },
                                             { 6, 33, 48, 75, 102, 129, 0, 27, 54, 81, 96, 123 },
                                             { 46, 61, 88, 115, 142, 13, 40, 67, 94, 109, 136, 19 },
                                             { 74, 101, 128, 11, 26, 53, 80, 107, 122, 5, 32, 59 },
                                             { 114, 141, 12, 39, 66, 93, 108, 135, 18, 45, 60, 87 },
                                             { 10, 25, 52, 79, 106, 121, 4, 31, 58, 73, 100, 127 },
                                             { 38, 65, 92, 119, 134, 17, 44, 71, 86, 113, 140, 23 } };

            indexArr[16] = new int[16, 16] { { 0, 192, 48, 240, 12, 204, 60, 252, 2, 194, 50, 242, 14, 206, 62, 254 },
                                             { 128, 64, 176, 112, 140, 76, 188, 124, 130, 66, 178, 114, 142, 78, 190, 126 },
                                             { 32, 224, 16, 208, 44, 236, 28, 220, 34, 226, 18, 210, 46, 238, 30, 222 },
                                             { 160, 96, 144, 80, 172, 108, 156, 92, 162, 98, 146, 82, 174, 110, 158, 94 },
                                             { 8, 200, 56, 248, 4, 196, 52, 244, 10, 202, 58, 250, 6, 198, 54, 246 },
                                             { 136, 72, 184, 120, 132, 68, 180, 116, 138, 74, 186, 122, 134, 70, 182, 118 },
                                             { 40, 232, 24, 216, 36, 228, 20, 212, 42, 234, 26, 218, 38, 230, 22, 214 },
                                             { 168, 104, 152, 88, 164, 100, 148, 84, 170, 106, 154, 90, 166, 102, 150, 86 },
                                             { 3, 195, 51, 243, 15, 207, 63, 255, 1, 193, 49, 241, 13, 205, 61, 253 },
                                             { 131, 67, 179, 115, 143, 79, 191, 127, 129, 65, 177, 113, 141, 77, 189, 125 },
                                             { 35, 227, 19, 211, 47, 239, 31, 223, 33, 225, 17, 209, 45, 237, 29, 221 },
                                             { 163, 99, 147, 83, 175, 111, 159, 95, 161, 97, 145, 81, 173, 109, 157, 93 },
                                             { 11, 203, 59, 251, 7, 199, 55, 247, 9, 201, 57, 249, 5, 197, 53, 245 },
                                             { 139, 75, 187, 123, 135, 71, 183, 119, 137, 73, 185, 121, 133, 69, 181, 117 },
                                             { 43, 235, 27, 219, 39, 231, 23, 215, 41, 233, 25, 217, 37, 229, 21, 213 },
                                             { 171, 107, 155, 91, 167, 103, 151, 87, 169, 105, 153, 89, 165, 101, 149, 85 } };
        }

        public Form1()
        {
            InitializeDefault();
            InitializeComponent();
            default_texture_path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Textures\\lena.jpg";
            original_texture = DirectBitmap.FromBitmap(new Bitmap(default_texture_path));
            dithering_texture = DirectBitmap.FromBitmap(new Bitmap(default_texture_path));
        }
        /// <summary>
        /// Drawing an original image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void original_picturebox_Paint(object sender, PaintEventArgs e)
        {
            if (original_texture != null)
            {
                var dest = new Bitmap(original_picturebox.Width, original_picturebox.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                e.Graphics.DrawImage(original_texture.Bitmap, new Rectangle(Point.Empty, dest.Size));
            }
        }
        /// <summary>
        /// Drawing a dithered image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dithering_picturebox_Paint(object sender, PaintEventArgs e)
        {
            if (dithering_texture != null)
            {
                var dest = new Bitmap(dithering_picturebox.Width, dithering_picturebox.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                e.Graphics.DrawImage(dithering_texture.Bitmap, new Rectangle(Point.Empty, dest.Size));
            }
        }
        /// <summary>
        /// Loading an image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.bmp, *.png, *.jpg) | *.bmp; *.png; *.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string pathname = Path.GetFullPath(ofd.FileName);
                Bitmap bm;

                try
                {
                    bm = new Bitmap(pathname);
                    original_texture = DirectBitmap.FromBitmap(bm);
                    dithering_texture = DirectBitmap.FromBitmap(bm);
                    texture_path = pathname;
                }
                catch
                {
                    bm = new Bitmap(default_texture_path);
                    original_texture = DirectBitmap.FromBitmap(bm);
                    dithering_texture = DirectBitmap.FromBitmap(bm);
                    texture_path = default_texture_path;
                }

                RestartAlgorithms();
                original_picturebox.Invalidate();
            }
        }
        /// <summary>
        /// Closing the app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }   
        /// <summary>
        /// Choosing an average dithering
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void averageDitheringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (original_texture == null)
                MessageBox.Show("An image is not loaded yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                errorDiffusionToolStripMenuItem.Checked = false;
                averageDitheringToolStripMenuItem.Checked = true;
                orderedDitheringToolStripMenuItem.Checked = false;
                orderedDitheringToolStripMenuItem1.Checked = false;
                popularityAlgorithmToolStripMenuItem.Checked = false;

                kr_scrollbar.Visible = true;
                kg_scrollbar.Visible = true;
                kb_scrollbar.Visible = true;
                k_scrollbar.Visible = false;

                kb_label.Visible = true;
                kr_label.Visible = true;
                kg_label.Visible = true;
                k_label.Visible = false;

                AverageDithering();
                dithering_picturebox.Invalidate();
            }
        }
        /// <summary>
        /// Choosing an ordered dithering which chooses (x, y) at random
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orderedDitheringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (original_texture == null)
                MessageBox.Show("An image is not loaded yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                errorDiffusionToolStripMenuItem.Checked = false;
                averageDitheringToolStripMenuItem.Checked = false;
                orderedDitheringToolStripMenuItem.Checked = true;
                orderedDitheringToolStripMenuItem1.Checked = false;
                popularityAlgorithmToolStripMenuItem.Checked = false;

                kr_scrollbar.Visible = true;
                kg_scrollbar.Visible = true;
                kb_scrollbar.Visible = true;
                k_scrollbar.Visible = false;

                kb_label.Visible = true;
                kr_label.Visible = true;
                kg_label.Visible = true;
                k_label.Visible = false;

                OrderedDitheringRandom();
                dithering_picturebox.Invalidate();
            }
        }
        /// <summary>
        /// Choosing an ordered dithering which chooses (x, y) by position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orderedDitheringToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (original_texture == null)
                MessageBox.Show("An image is not loaded yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                errorDiffusionToolStripMenuItem.Checked = false;
                averageDitheringToolStripMenuItem.Checked = false;
                orderedDitheringToolStripMenuItem.Checked = false;
                orderedDitheringToolStripMenuItem1.Checked = true;
                popularityAlgorithmToolStripMenuItem.Checked = false;

                kr_scrollbar.Visible = true;
                kg_scrollbar.Visible = true;
                kb_scrollbar.Visible = true;
                k_scrollbar.Visible = false;

                kb_label.Visible = true;
                kr_label.Visible = true;
                kg_label.Visible = true;
                k_label.Visible = false;

                OrderedDitheringOnPosition();
                dithering_picturebox.Invalidate();
            }
        }
        /// <summary>
        /// Choosing an error diffision
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void errorDiffusionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (original_texture == null)
                MessageBox.Show("An image is not loaded yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                errorDiffusionToolStripMenuItem.Checked = true;
                averageDitheringToolStripMenuItem.Checked = false;
                orderedDitheringToolStripMenuItem.Checked = false;
                orderedDitheringToolStripMenuItem1.Checked = false;
                popularityAlgorithmToolStripMenuItem.Checked = false;

                kr_scrollbar.Visible = true;
                kg_scrollbar.Visible = true;
                kb_scrollbar.Visible = true;
                k_scrollbar.Visible = false;

                kb_label.Visible = true;
                kr_label.Visible = true;
                kg_label.Visible = true;
                k_label.Visible = false;

                ErrorDiffusion();
                dithering_picturebox.Invalidate();
            }
        }
        /// <summary>
        /// Choosing the popularity algorithm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popularityAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (original_texture == null)
                MessageBox.Show("An image is not loaded yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                errorDiffusionToolStripMenuItem.Checked = false;
                averageDitheringToolStripMenuItem.Checked = false;
                orderedDitheringToolStripMenuItem.Checked = false;
                orderedDitheringToolStripMenuItem1.Checked = false;
                popularityAlgorithmToolStripMenuItem.Checked = true;

                k_scrollbar.Visible = true;
                kr_scrollbar.Visible = false;
                kg_scrollbar.Visible = false;
                kb_scrollbar.Visible = false;

                k_label.Visible = true;
                kb_label.Visible = false;
                kr_label.Visible = false;
                kg_label.Visible = false;

                CreateHistogram();
                PopularityAlgorithm();
                dithering_picturebox.Invalidate();
            }
        }
        /// <summary>
        /// Taking a value of Kr for dithering algorithms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kr_scrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            Kr = kr_scrollbar.Value;
            kr_label.Text = "Kr : " + kr_scrollbar.Value.ToString();
            if (original_texture != null) 
            {
                if (averageDitheringToolStripMenuItem.Checked)
                    AverageDithering();

                else if (orderedDitheringToolStripMenuItem.Checked)
                    OrderedDitheringRandom();

                else if (orderedDitheringToolStripMenuItem1.Checked)
                    OrderedDitheringOnPosition();

                else if (errorDiffusionToolStripMenuItem.Checked)
                    ErrorDiffusion();

                dithering_picturebox.Invalidate();
            }
        }
        /// <summary>
        /// Taking a value of Kg for dithering algorithms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kg_scrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            Kg = kg_scrollbar.Value;
            kg_label.Text = "Kg : " + kg_scrollbar.Value.ToString();
            if (original_texture != null)
            {
                if (averageDitheringToolStripMenuItem.Checked)
                    AverageDithering();
 
                else if (orderedDitheringToolStripMenuItem.Checked)
                    OrderedDitheringRandom();
               
                else if (orderedDitheringToolStripMenuItem1.Checked)
                    OrderedDitheringOnPosition();

                else if (errorDiffusionToolStripMenuItem.Checked)
                    ErrorDiffusion();
                    
                dithering_picturebox.Invalidate();
            }
        }
        /// <summary>
        /// Taking a value of Kb for dithering algorithms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kb_scrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            Kb = kb_scrollbar.Value;
            kb_label.Text = "Kb : " + kb_scrollbar.Value.ToString();
            if (original_texture != null)
            {
                if (averageDitheringToolStripMenuItem.Checked)
                    AverageDithering();

                else if (orderedDitheringToolStripMenuItem.Checked)
                    OrderedDitheringRandom();

                else if (orderedDitheringToolStripMenuItem1.Checked)
                    OrderedDitheringOnPosition();

                else if (errorDiffusionToolStripMenuItem.Checked)
                    ErrorDiffusion();

                dithering_picturebox.Invalidate();
            }
        }
        /// <summary>
        /// Taking a value of K for popularity algorithm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void k_scrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            K = k_scrollbar.Value;
            k_label.Text = "K : " + k_scrollbar.Value.ToString();
            if (original_texture != null)
            {
                PopularityAlgorithm();

                dithering_picturebox.Invalidate();
            }
        }
        /// <summary>
        /// An average dithering algorithm
        /// </summary>
        private void AverageDithering()
        {
            int width = original_texture.Width;
            int height = original_texture.Height;

            int R, G, B;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color px = original_texture.GetPixel(x, y);

                    R = FindClosestColor(px.R, Kr);
                    G = FindClosestColor(px.G, Kg);
                    B = FindClosestColor(px.B, Kb);

                    dithering_texture.SetPixel(x, y, Color.FromArgb(R, G, B));
                }
            }
        }
        /// <summary>
        /// Floyd-Steinberg error diffusion algorithm
        /// </summary>
        private void ErrorDiffusion()
        {
            dithering_texture = DirectBitmap.FromBitmap(original_texture.Bitmap);
            int width = original_texture.Width;
            int height = original_texture.Height;

            int R, G, B;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color px = dithering_texture.GetPixel(x, y);

                    R = FindClosestColor(px.R, Kr);
                    G = FindClosestColor(px.G, Kg);
                    B = FindClosestColor(px.B, Kb);

                    dithering_texture.SetPixel(x, y, Color.FromArgb(R, G, B));

                    float errr, errg, errb;

                    errr = (float)px.R - R;
                    errg = (float)px.G - G;
                    errb = (float)px.B - B;

                    if (x + 1 < width)
                    {
                        Color cx = dithering_texture.GetPixel(x + 1, y);

                        int r = cx.R + (int)errr * 7 / 16;
                        r = CorrectValue(r);

                        int g = cx.G + (int)errg * 7 / 16;
                        g = CorrectValue(g);

                        int b = cx.B + (int)errb * 7 / 16;
                        b = CorrectValue(b);

                        dithering_texture.SetPixel(x + 1, y, Color.FromArgb(r, g, b));
                    }

                    if (x - 1 >= 0 && y + 1 < height)
                    {
                        Color cx = dithering_texture.GetPixel(x - 1, y + 1);

                        int r = cx.R + (int)errr * 3 / 16;
                        r = CorrectValue(r);

                        int g = cx.G + (int)errg * 3 / 16;
                        g = CorrectValue(g);

                        int b = cx.B + (int)errb * 3 / 16;
                        b = CorrectValue(b);

                        dithering_texture.SetPixel(x - 1, y + 1, Color.FromArgb(r, g, b));
                    }

                    if (y + 1 < height)
                    {
                        Color cx = dithering_texture.GetPixel(x, y + 1);

                        int r = cx.R + (int)errr * 5 / 16;
                        r = CorrectValue(r);

                        int g = cx.G + (int)errg * 5 / 16;
                        g = CorrectValue(g);

                        int b = cx.B + (int)errb * 5 / 16;
                        b = CorrectValue(b);

                        dithering_texture.SetPixel(x, y + 1, Color.FromArgb(r, g, b));
                    }

                    if (x + 1 < width && y + 1 < height)
                    {
                        Color cx = dithering_texture.GetPixel(x + 1, y + 1);

                        int r = cx.R + (int)errr * 1 / 16;
                        r = CorrectValue(r);

                        int g = cx.G + (int)errg * 1 / 16;
                        g = CorrectValue(g);

                        int b = cx.B + (int)errb * 1 / 16;
                        b = CorrectValue(b);

                        dithering_texture.SetPixel(x + 1, y + 1, Color.FromArgb(r, g, b));
                    }
                }
            }
        }
        /// <summary>
        /// Ordered dithering algorithm which chooses (i, j) at random
        /// </summary>
        private void OrderedDitheringRandom()
        {
            int nr = (int)Math.Sqrt(256 / (Kr - 1));
            int ng = (int)Math.Sqrt(256 / (Kg - 1));
            int nb = (int)Math.Sqrt(256 / (Kb - 1));

            nr = RoundUp(nr);
            ng = RoundUp(ng);
            nb = RoundUp(nb);

            double factorRed = 256.0 / (Kr - 1);
            double factorBlue = 256.0 / (Kb - 1);
            double factorGreen = 256.0 / (Kg - 1);

            int width = original_texture.Width;
            int height = original_texture.Height;

            double tmp;
            Random rnd = new Random();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color px = original_texture.GetPixel(x, y);

                    tmp = factorRed * (indexArr[nr][rnd.Next(nr), rnd.Next(nr)] - 0.5);
                    int R = px.R + (int)tmp;
                    R = FindClosestColor(R, Kr);

                    tmp = factorGreen * (indexArr[ng][rnd.Next(ng), rnd.Next(ng)] - 0.5);
                    int G = px.G + (int)tmp;
                    G = FindClosestColor(G, Kg);

                    tmp = factorBlue * (indexArr[nb][rnd.Next(nb), rnd.Next(nb)] - 0.5);
                    int B = px.B + (int)tmp;
                    B = FindClosestColor(B, Kb);

                    dithering_texture.SetPixel(x, y, Color.FromArgb(R, G, B));
                }
            }
        }
        /// <summary>
        /// Ordered dithering algorithm which chooses (i, j) by position
        /// </summary>
        private void OrderedDitheringOnPosition()
        {
            int nr = (int)Math.Sqrt(256 / (Kr - 1));
            int ng = (int)Math.Sqrt(256 / (Kg - 1));
            int nb = (int)Math.Sqrt(256 / (Kb - 1));

            nr = RoundUp(nr);
            ng = RoundUp(ng);
            nb = RoundUp(nb);

            double factorRed = 256.0 / (Kr - 1);
            double factorBlue = 256.0 / (Kb - 1);
            double factorGreen = 256.0 / (Kg - 1);

            int width = original_texture.Width;
            int height = original_texture.Height;

            double tmp;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color px = original_texture.GetPixel(x, y);

                    tmp = factorRed * (indexArr[nr][x % nr, y % nr] - 0.5);
                    int R = px.R + (int)tmp;
                    R = FindClosestColor(R, Kr);

                    tmp = factorGreen * (indexArr[ng][x % ng, y % ng] - 0.5);
                    int G = px.G + (int)tmp;
                    G = FindClosestColor(G, Kg);

                    tmp = factorBlue * (indexArr[nb][x % nb, y % nb] - 0.5);
                    int B = px.B + (int)tmp;
                    B = FindClosestColor(B, Kb);

                    dithering_texture.SetPixel(x, y, Color.FromArgb(R, G, B));
                }
            }
        }
        /// <summary>
        /// Rounding up the size of the index array
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private int RoundUp(int x)
        {
            if (x <= 2) x = 2;
            if (2 < x && x <= 3) x = 3;
            if (3 < x && x <= 4) x = 4;
            if (4 < x && x <= 6) x = 6;
            if (6 < x && x <= 8) x = 8;
            if (8 < x && x <= 12) x = 12;
            if (12 < x && x <= 16) x = 16;

            return x;
        }
        /// <summary>
        /// Popularity algorithm
        /// </summary>
        private void PopularityAlgorithm()
        {
            int width = original_texture.Width;
            int height = original_texture.Height;

            int[] red = new int[K];
            int[] blue = new int[K];
            int[] green = new int[K];

            int size = 0;
            for (int i = 255; i > 255 - K; i--)
                for (int j = 0; j < 256; j++)
                    if (chistRed[j] == histRed[i])
                        if (size < K)
                            red[size++] = j;

            size = 0;
            for (int i = 255; i > 255 - K && size < K; i--)
                for (int j = 0; j < 256; j++)
                    if (chistGreen[j] == histGreen[i])
                        if (size < K)
                            green[size++] = j;

            size = 0;
            for (int i = 255; i > 255 - K && size < K; i--)
                for (int j = 0; j < 256; j++)
                    if (chistBlue[j] == histBlue[i])
                        if (size < K)
                            blue[size++] = j;

            Array.Sort(red);
            Array.Sort(blue);
            Array.Sort(green);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color px = original_texture.GetPixel(x, y);

                    int R = FindClosestColor(red, K, px.R);
                    int B = FindClosestColor(blue, K, px.B);
                    int G = FindClosestColor(green, K, px.G);

                    dithering_texture.SetPixel(x, y, Color.FromArgb(R, G, B));
                }
            }
        }
        /// <summary>
        /// Find the closest element to the target in sorted array using binary search
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private int FindClosestColor(int[] arr, int n, int target)
        {
            if (target >= arr[n - 1])
                return arr[n - 1];

            if (target <= arr[0])
                return arr[0];

            int l = 0, r = n, mid = 0;

            while (l < r)
            {
                mid = (l + r) / 2;

                if (arr[mid] == target)
                    return arr[mid];

                if (target < arr[mid])
                {
                    if (mid > 0 && target > arr[mid - 1])
                        return GetClosest(arr[mid - 1], arr[mid], target);

                    r = mid;
                }
                else
                {
                    if (mid < n - 1 && target < arr[mid + 1])
                        return GetClosest(arr[mid], arr[mid + 1], target);

                    l = mid + 1;
                }
            }

            return arr[mid];
        }
        /// <summary>
        /// Find which one is more closest to the target among v1, v2
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="tar"></param>
        /// <returns></returns>
        private int GetClosest(int v1, int v2, int tar)
        {
            if (tar - v1 >= v2 - tar) return v2;
            else return v1;
        }
        /// <summary>
        /// Restaring algorithms when the user loads an image
        /// </summary>
        private void RestartAlgorithms()
        {
            errorDiffusionToolStripMenuItem.Checked = false;
            averageDitheringToolStripMenuItem.Checked = false;
            orderedDitheringToolStripMenuItem.Checked = false;
            orderedDitheringToolStripMenuItem1.Checked = false;   
            popularityAlgorithmToolStripMenuItem.Checked = false;

            kr_scrollbar.Visible = false;
            kg_scrollbar.Visible = false;
            kb_scrollbar.Visible = false;
            k_scrollbar.Visible = false;

            kb_label.Visible = false;
            kr_label.Visible = false;
            kg_label.Visible = false;
            k_label.Visible = false;

            for (int i = 0; i < 256; i++)
            {
                histRed[i] = 0;
                histBlue[i] = 0;
                histGreen[i] = 0;
            }
        }
        /// <summary>
        /// Find the closest to the given color
        /// </summary>
        /// <param name="color"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private int FindClosestColor(int color, int k)
        {
            int closest = color;
            int min = 256;
           
            int intr = 255 / (k - 1);
            int nr = color / intr;

            if (Math.Abs(color - (nr * 255) / (k - 1)) < min)
            {
                min = Math.Abs(color - nr * 255 / (k - 1));
                closest = nr * 255 / (k - 1);
            }
            if (nr + 1 <= k - 1 && Math.Abs(color - (255 * nr + 255) / (k - 1)) < min)
            {
                min = Math.Abs(color - (255 * nr + 255) / (k - 1));
                closest = (255 * nr + 255) / (k - 1);
            }

            closest = CorrectValue(closest);
            return closest;
        }
        /// <summary>
        /// Correcting a value
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private int CorrectValue(int color)
        {
            if (color < 0) color = 0;
            if (color > 255) color = 255;

            return color;
        }
        /// <summary>
        /// Creating histogram for popularity algorithm
        /// </summary>
        private void CreateHistogram()
        {
            int width = original_picturebox.Width;
            int height = original_picturebox.Height;

            for (int i = 0; i < 256; i++)
            {
                histRed[i] = 0;
                histBlue[i] = 0;
                histGreen[i] = 0;
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color px = original_texture.GetPixel(x, y);

                    histRed[px.R]++;
                    histBlue[px.B]++;
                    histGreen[px.G]++;
                }
            }

            for (int i = 0; i < 256; i++)
            {
                chistRed[i] = histRed[i];
                chistBlue[i] = histBlue[i];
                chistGreen[i] = histGreen[i];
            }

            Array.Sort(histRed);
            Array.Sort(histBlue);
            Array.Sort(histGreen);
        }
    }
}
