using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_OOP
{
    public partial class Form1 : Form
    {
        private Bitmap MyBitmap;
        private Graphics g;

        public Form1()
        {
            InitializeComponent();
            this.MyBitmap = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            pictureBox1.Image = MyBitmap;
            this.g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
        }


        Picture pic = new Picture(new Point(0, 0), 900, 600, new List<Figure>());

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "BMP Files (*.bmp)|*.bmp;";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string a = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(a);
                g = Graphics.FromImage(pictureBox1.Image);
            }

            pic.RemoveAllFigures();
            while(listBox1.Items.Count > 0)
            {
                listBox1.Items.RemoveAt(0);
            }

            }

        private void CircleScaleButton_Click(object sender, EventArgs e)
        {
            try
            {
                pic.FigureList[listBox1.SelectedIndex].Scale(double.Parse(CircleScale.Text));
                g.Clear(Color.White);
                pic.DrawAll(g);
                this.pictureBox1.Invalidate();
                label5.Text = pic.FigureList[0].ToString();
                label14.Text = pic.ToString();
            }
            catch
            {
                MessageBox.Show("Wrong input data!");
            }
        }

        private void pictureBox1_Click(object sender, MouseEventArgs e)
        {           }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Circle c = new Circle(new Pen(Color.Black), double.Parse(CircleX.Text), double.Parse(CircleY.Text), double.Parse(CircleR.Text));
                    pic.FigureList.Add(c);
                    listBox1.Items.Add(c.GetType().Name);
                    c.Draw(g);
                    label5.Text = c.ToString();
                    break;
                case 1:
                    Annulus a = new Annulus(new Pen(Color.Black), double.Parse(CircleX.Text), double.Parse(CircleY.Text),
                                            double.Parse(CircleR.Text), double.Parse(textBox6.Text));
                    pic.FigureList.Add(a);
                    listBox1.Items.Add(a.GetType().Name);
                    a.Draw(g);
                    label5.Text = a.ToString();
                    break;
                case 2:
                    FillAnnulus f = new FillAnnulus(new Pen(Color.Black), new SolidBrush(Color.Black), double.Parse(CircleX.Text), double.Parse(CircleY.Text),
                                            double.Parse(CircleR.Text), double.Parse(textBox6.Text));
                    pic.FigureList.Add(f);
                    listBox1.Items.Add(f.GetType().Name);
                    f.Draw(g);
                    label5.Text = f.ToString();
                    break;

            }

            this.pictureBox1.Invalidate();

            label14.Text = pic.ToString();

        }

        private void button6_Click(object sender, EventArgs e)
        {

            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    Cylinder c = new Cylinder(new Pen(Color.Black), double.Parse(textBox1.Text), double.Parse(textBox2.Text), double.Parse(textBox3.Text), double.Parse(textBox4.Text), double.Parse(textBox5.Text));
                    pic.FigureList.Add(c);
                    listBox1.Items.Add(c.GetType().Name);
                    c.Draw(g);
                    label5.Text = c.ToString();
                    break;
                case 1:
                    Torus t = new Torus(new Pen(Color.Black), new SolidBrush(Color.Blue), double.Parse(textBox1.Text), double.Parse(textBox2.Text), double.Parse(textBox3.Text), double.Parse(textBox4.Text), double.Parse(textBox5.Text));
                    pic.FigureList.Add(t);
                    listBox1.Items.Add(t.GetType().Name);
                    t.Draw(g);
                    label5.Text = t.ToString();
                    break;
                case 2:
                    Sphere s = new Sphere(new Pen(Color.Black), double.Parse(textBox1.Text), double.Parse(textBox2.Text), double.Parse(textBox3.Text), double.Parse(textBox4.Text));
                    pic.FigureList.Add(s);
                    listBox1.Items.Add(s.GetType().Name);
                    s.Draw(g);
                    label5.Text = s.ToString();
                    break;

            }
            this.pictureBox1.Invalidate();
            label14.Text = pic.ToString();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.saveFileDialog1.Filter = "Image Files (*.bmp)|*.bmp;";
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image.Save(this.saveFileDialog1.FileName, ImageFormat.Bmp);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                pic.FigureList[listBox1.SelectedIndex].Scale(double.Parse(textBox7.Text));
                g.Clear(Color.White);
                pic.DrawAll(g);
                this.pictureBox1.Invalidate();
                label5.Text = pic.FigureList[0].ToString();
                label14.Text = pic.ToString();
            }
            catch
            {
                MessageBox.Show("Wrong input data!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                pic.Scale(double.Parse(textBox8.Text));
                g.Clear(Color.White);
                pic.DrawAll(g);
                this.pictureBox1.Invalidate();
                label14.Text = pic.ToString();
            }
            catch
            {
                MessageBox.Show("Wrong input data!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                pic.MoveFigures(double.Parse(textBox9.Text), double.Parse(textBox10.Text));
                g.Clear(Color.White);
                pic.DrawAll(g);
                this.pictureBox1.Invalidate();
                label14.Text = pic.ToString();
            }
            catch
            {
                MessageBox.Show("Wrong input data!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pic.RemoveAllFigures();
            this.pictureBox1.Invalidate();
            while (listBox1.Items.Count > 0)
            {
                listBox1.Items.RemoveAt(0);
            }
            label14.Text = pic.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                pic.RemoveFigure(listBox1.SelectedIndex);
                g.Clear(Color.White);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                pic.DrawAll(g);
                this.pictureBox1.Invalidate();
                label14.Text = pic.ToString();
            }
            catch
            {
                MessageBox.Show("No one item is selested");
            }
        }
    
    }
    
}
