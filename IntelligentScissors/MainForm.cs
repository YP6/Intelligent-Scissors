using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IntelligentScissors
{
    public partial class MainForm : Form
    {
        public Point start, end;
        public MainForm()
        {
            InitializeComponent();
        }

        RGBPixel[,] ImageMatrix;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the browsed image and display it
                string OpenedFilePath = openFileDialog1.FileName;
                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                ImageOperations.DisplayImage(ImageMatrix, pictureBox1);
            }
            txtWidth.Text = ImageOperations.GetWidth(ImageMatrix).ToString();
            txtHeight.Text = ImageOperations.GetHeight(ImageMatrix).ToString();
        }

        private void btnGaussSmooth_Click(object sender, EventArgs e)
        {
            double sigma = double.Parse(txtGaussSigma.Text);
            int maskSize = (int)nudMaskSize.Value ;
            ImageMatrix = ImageOperations.GaussianFilter1D(ImageMatrix, maskSize, sigma);
            ImageOperations.DisplayImage(ImageMatrix, pictureBox2);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Point pixel = e.Location;
            if (start == null)
                start = pixel;
            else
            {
                if(end != null)
                    start = end;

                end = pixel;
            }

            /*Console.WriteLine(pixel.X + ", " + pixel.Y);
            Console.WriteLine("Top : " + ImageOperations.CalculateTopPixelEnergy(pixel.X, pixel.Y, ImageMatrix));
            Console.WriteLine("Left : " + ImageOperations.CalculateLeftPixelEnergy(pixel.X, pixel.Y, ImageMatrix));
            Console.WriteLine("Right : " + ImageOperations.CalculateRightPixelEnergy(pixel.X, pixel.Y, ImageMatrix));
            Console.WriteLine("Bottom : " + ImageOperations.CalculateBottomPixelEnergy(pixel.X, pixel.Y, ImageMatrix));*/



        }
    }
}