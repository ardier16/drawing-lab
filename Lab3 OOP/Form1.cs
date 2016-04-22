using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Figure> list = new List<Figure>();

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Circle c = new Circle(new Pen(Color.Black), double.Parse(CircleX.Text), double.Parse(CircleY.Text), double.Parse(CircleR.Text));
                    list.Add(c);
                    listBox1.Items.Add(c.GetType().Name);
                    c.Draw(g);
                    label5.Text = c.ToString();
                    break;
                case 1:
                    Annulus a = new Annulus(new Pen(Color.Black), double.Parse(CircleX.Text), double.Parse(CircleY.Text),
                                            double.Parse(CircleR.Text), double.Parse(textBox6.Text));
                    list.Add(a);
                    listBox1.Items.Add(a.GetType().Name);
                    a.Draw(g);
                    label5.Text = a.ToString();
                    break;
                case 2:
                    FillAnnulus f = new FillAnnulus(new Pen(Color.Black), new SolidBrush(Color.Black), double.Parse(CircleX.Text), double.Parse(CircleY.Text),
                                            double.Parse(CircleR.Text), double.Parse(textBox6.Text));
                    list.Add(f);
                    listBox1.Items.Add(f.GetType().Name);
                    f.Draw(g);
                    label5.Text = f.ToString();
                    break;
                
            }


        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            Pen p1 = new Pen(Color.Black);
            Pen p = new Pen(Color.Blue);
            SolidBrush s = new SolidBrush(Color.Blue);

            Torus t = new Torus(p, s, 200, 200, 200, 100, 50);
            t.Draw(g);

            Sphere h = new Sphere(p, 400, 200, 200, 100);
            h.Draw(g);

        }

        private void CircleScaleButton_Click(object sender, EventArgs e)
        {
            try
            {
                Graphics g = pictureBox1.CreateGraphics();
                list[0].Scale(double.Parse(CircleScale.Text));
                list[0].Draw(g);
            }
            catch
            {
                MessageBox.Show("Wrong input data!");
            }
        }

        private void pictureBox1_Click(object sender, MouseEventArgs e)
        {

                this.label7.Text = e.X.ToString();
                this.label8.Text = e.Y.ToString();
            }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Cylinder c = new Cylinder(new Pen(Color.Black), double.Parse(textBox1.Text), double.Parse(textBox2.Text), double.Parse(textBox3.Text), double.Parse(textBox4.Text), double.Parse(textBox4.Text));
                    list.Add(c);
                    listBox1.Items.Add(c.GetType().Name);
                    c.Draw(g);
                    label5.Text = c.ToString();
                    break;
                case 1:
                    Annulus a = new Annulus(new Pen(Color.Black), double.Parse(CircleX.Text), double.Parse(CircleY.Text),
                                            double.Parse(CircleR.Text), double.Parse(textBox6.Text));
                    list.Add(a);
                    listBox1.Items.Add(a.GetType().Name);
                    a.Draw(g);
                    label5.Text = a.ToString();
                    break;
                case 2:
                    FillAnnulus f = new FillAnnulus(new Pen(Color.Black), new SolidBrush(Color.Black), double.Parse(CircleX.Text), double.Parse(CircleY.Text),
                                            double.Parse(CircleR.Text), double.Parse(textBox6.Text));
                    list.Add(f);
                    listBox1.Items.Add(f.GetType().Name);
                    f.Draw(g);
                    label5.Text = f.ToString();
                    break;

            }
        }
    }
    
}
