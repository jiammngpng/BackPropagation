using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackPropagation
{
    public partial class Form1 : Form
    {
        Bitmap loaded, processed;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void btnRescale_Click(object sender, EventArgs e)
        {
            Scale(ref loaded, ref processed);
            pictureBox2.Image = this.processed;
            newDimBox.Text = Convert.ToString(this.processed.Width) + ", " + Convert.ToString(this.processed.Height);
        }

        public static void Scale(ref Bitmap a, ref Bitmap b)
        {
            int targetSize = 100;
            int width = a.Width, height = a.Height, x, y, xSource, ySource;
            float nPercentW = ((float)targetSize / (float)width);
            float nPercentH = ((float)targetSize / (float)height);

            float nPercent;
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            //new width
            int destWidth = (int)(width * nPercent);
            //new height
            int destHeight = (int)(height * nPercent);
            
            b = new Bitmap(destWidth, destHeight);


            for (x = 0; x < destWidth; x++)
            {
                for (y = 0; y < destHeight; y++)
                {
                    xSource = x * width / destWidth;
                    ySource = y * height / destHeight;
                    b.SetPixel(x, y, a.GetPixel(xSource, ySource));
                }
            }
        }

        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {
            int width, height;
            loaded = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = loaded;
            width = pictureBox1.Image.Width;
            height = pictureBox1.Image.Height;
            dimensionBox.Text = Convert.ToString(width) + "," + Convert.ToString(height);
        }

        private void btnGrayscale_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(processed.Width, processed.Height);
            for (int x = 0; x < processed.Width; x++)
            {
                for (int y = 0; y < processed.Height; y++)
                {
                    Color pixel = processed.GetPixel(x, y);
                    byte grey = (byte)((pixel.R + pixel.G + pixel.B) / 3);
                    bm.SetPixel(x, y, Color.FromArgb(grey, grey, grey));
                }
            }
            pictureBox2.Image = bm;
        }

    

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
