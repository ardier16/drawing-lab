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
    public partial class Drawing : Form
    {
        private Graphics g;

        public Drawing()
        {
            InitializeComponent();
        }

        List<Picture> pics = new List<Picture>();
        Picture pic = new Picture(new Point(0, 0), 900, 400, new List<Figure>());

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            

            }

        private void CircleScaleButton_Click(object sender, EventArgs e)
        {
            try
            {
                pic.FigureList[listBox1.SelectedIndex].Scale(double.Parse(textBox7.Text), false);
                g.Clear(Color.White);
                pic.DrawAll(g);
  
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
            g = pictureBox1.CreateGraphics();
            pics.Add(pic);
            listBox3.Items.Add(pic.GetType().Name);
            listBox4.Items.Add(pic.GetType().Name);
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(CircleX.Text) >= 0 && double.Parse(CircleY.Text) >= 0 && double.Parse(CircleR.Text) >= 0)
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        Circle c = new Circle(new Pen(Color.Black), double.Parse(CircleX.Text), double.Parse(CircleY.Text), double.Parse(CircleR.Text));
                        pic.FigureList.Add(c);
                        listBox1.Items.Add(c.GetType().Name);
                        listBox2.Items.Add(c.GetType().Name);
                        c.Draw(g);
                        label5.Text = c.ToString();
                    }

                    else if (comboBox1.SelectedIndex == 1 && double.Parse(textBox6.Text) <= double.Parse(CircleR.Text) && double.Parse(textBox6.Text) >= 0)
                    {
                        Annulus a = new Annulus(new Pen(Color.Black), double.Parse(CircleX.Text), double.Parse(CircleY.Text),
                                                double.Parse(CircleR.Text), double.Parse(textBox6.Text));
                        pic.FigureList.Add(a);
                        listBox1.Items.Add(a.GetType().Name);
                        listBox2.Items.Add(a.GetType().Name);
                        a.Draw(g);
                        label5.Text = a.ToString();
                    }
                    else if (comboBox1.SelectedIndex == 2 && double.Parse(textBox6.Text) <= double.Parse(CircleR.Text) && double.Parse(textBox6.Text) >= 0)
                    {
                        FillAnnulus f = new FillAnnulus(new Pen(Color.Black), new SolidBrush(Color.Black), double.Parse(CircleX.Text), double.Parse(CircleY.Text),
                                                   double.Parse(CircleR.Text), double.Parse(textBox6.Text));
                        pic.FigureList.Add(f);
                        listBox1.Items.Add(f.GetType().Name);
                        listBox2.Items.Add(f.GetType().Name);
                        f.Draw(g);
                        label5.Text = f.ToString();
                    }

                    else
                        MessageBox.Show("Wrong input data");

                    label14.Text = pic.ToString();
                }

                else
                    MessageBox.Show("Wrong input data");

            }
            catch
            {
                MessageBox.Show("Wrong input data");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
               if (double.Parse(textBox1.Text) >= 0 && double.Parse(textBox2.Text) >= 0 && double.Parse(textBox3.Text) >= 0 && double.Parse(textBox4.Text) >= 0)
                {
                    switch (comboBox2.SelectedIndex)
                    {
                        case 0:
                            Cylinder c = new Cylinder(new Pen(Color.Black), double.Parse(textBox1.Text), double.Parse(textBox2.Text), double.Parse(textBox3.Text), double.Parse(textBox4.Text), double.Parse(textBox5.Text));
                            pic.FigureList.Add(c);
                            listBox1.Items.Add(c.GetType().Name);
                            listBox2.Items.Add(c.GetType().Name);
                            c.Draw(g);
                            label5.Text = c.ToString();
                            break;
                        case 1:
                            Torus t = new Torus(new Pen(Color.Black), new SolidBrush(Color.Blue), double.Parse(textBox1.Text), double.Parse(textBox2.Text), double.Parse(textBox3.Text), double.Parse(textBox4.Text), double.Parse(textBox5.Text));
                            pic.FigureList.Add(t);
                            listBox1.Items.Add(t.GetType().Name);
                            listBox2.Items.Add(t.GetType().Name);
                            t.Draw(g);
                            label5.Text = t.ToString();
                            break;
                        case 2:
                            Sphere s = new Sphere(new Pen(Color.Black), double.Parse(textBox1.Text), double.Parse(textBox2.Text), double.Parse(textBox3.Text), double.Parse(textBox4.Text));
                            pic.FigureList.Add(s);
                            listBox1.Items.Add(s.GetType().Name);
                            listBox2.Items.Add(s.GetType().Name);
                            s.Draw(g);
                            label5.Text = s.ToString();
                            break;

                    }
        
                    label14.Text = pic.ToString();
                }
               else
                    MessageBox.Show("Wrong input data");
            }

            catch
            {
                MessageBox.Show("Wrong input data");
            }
            
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.saveFileDialog1.Filter = "XML Files (*.xml)|*.xml;";
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Doc.Save(pic, this.saveFileDialog1.FileName);
                }
                catch { }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                pic.FigureList[listBox1.SelectedIndex].Scale(double.Parse(textBox7.Text), false);
                g.Clear(Color.White);
                pic.DrawAll(g);
       
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
                pictureBox1.Refresh();
                pictureBox1.Height = (int)(pictureBox1.Height*double.Parse(textBox8.Text));
                pictureBox1.Width = (int)(pictureBox1.Width * double.Parse(textBox8.Text));
                pic.DrawAll(g);
      
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
                if (checkBox2.Checked)
                {
                    if (checkBox1.Checked)
                    {
                        pic.FigureList[listBox1.SelectedIndex].Move(new Point(int.Parse(textBox9.Text), int.Parse(textBox10.Text)));
                        g.Clear(Color.White);
                        pictureBox1.Refresh();
                        pic.DrawAll(g);
                    }
                    else
                    {
                        pic.MoveFigures(new Point(int.Parse(textBox9.Text), int.Parse(textBox10.Text)));
                        g.Clear(Color.White);
                        pictureBox1.Refresh();
                        pic.DrawAll(g);

                        label14.Text = pic.ToString();
                    }
                }
                else
                {
                    if (checkBox1.Checked)
                    {
                        pic.FigureList[listBox1.SelectedIndex].Move(double.Parse(textBox9.Text), double.Parse(textBox10.Text));
                        g.Clear(Color.White);
                        pictureBox1.Refresh();
                        pic.DrawAll(g);
                    }
                    else
                    {
                        pic.MoveFigures(double.Parse(textBox9.Text), double.Parse(textBox10.Text));
                        g.Clear(Color.White);
                        pictureBox1.Refresh();
                        pic.DrawAll(g);

                        label14.Text = pic.ToString();
                    }
                }
                
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
      
            while (listBox1.Items.Count > 0)
            {
                listBox1.Items.RemoveAt(0);
                listBox2.Items.RemoveAt(0);
            }
            label14.Text = pic.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                pic.RemoveFigure(listBox1.SelectedIndex);
                g.Clear(Color.White);
                listBox2.Items.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                
                pic.DrawAll(g);
           
                label14.Text = pic.ToString();
            }
            catch
            {
                MessageBox.Show("No one item is selested");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                Figure f1 = pic.FigureList[listBox1.SelectedIndex];
                Figure f2 = pic.FigureList[listBox2.SelectedIndex];
                bool res = f1.Cross(f2);
                label20.Text = res.ToString();
            }

            catch
            {
                MessageBox.Show("Elements not selected");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            pic = new Picture(new Point(0, 0), 900, 400, new List<Figure>());
            pictureBox1.Height = (int)pic.Height;
            pictureBox1.Width = (int)pic.Width;
            pics.Add(pic);
            g.Clear(Color.White);
            pictureBox1.Refresh();
            label14.Text = pic.ToString();
            
            listBox3.Items.Add(pic.GetType().Name);
            listBox4.Items.Add(pic.GetType().Name);
            listBox3.SelectedIndex = listBox3.Items.Count - 1;
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pic = pics[listBox3.SelectedIndex];
                pictureBox1.Top = pic.Point.Y;
                pictureBox1.Left = pic.Point.X;
                pictureBox1.Height = (int)pic.Height;
                pictureBox1.Width = (int)pic.Width;
                g.Clear(Color.White);
                label14.Text = pic.ToString();
                pictureBox1.Refresh();
                pic.DrawAll(g);
                
                listBox1.Items.Clear();
                listBox2.Items.Clear();

                for (int i = 0; i < pic.FigureList.Count; i++)
                {
                    listBox1.Items.Add(pic.FigureList[i].GetType().Name);
                    listBox2.Items.Add(pic.FigureList[i].GetType().Name);
                }
                
            }
            catch { }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                pics.RemoveAt(listBox3.SelectedIndex);
                listBox4.Items.RemoveAt(listBox3.SelectedIndex);
                listBox3.Items.RemoveAt(listBox3.SelectedIndex);
                g.Clear(Color.White);
                pictureBox1.Refresh();
            }
            catch
            {
                MessageBox.Show("Items aren't selected");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                pics[listBox3.SelectedIndex].JoinPictures(pics[listBox4.SelectedIndex]);
                pic = pics[listBox3.SelectedIndex];
                g.Clear(Color.White);
                pictureBox1.Refresh();
                label14.Text = pic.ToString();
                pic.DrawAll(g);

                listBox1.Items.Clear();
                listBox2.Items.Clear();

                for (int i = 0; i < pic.FigureList.Count; i++)
                {
                    listBox1.Items.Add(pic.FigureList[i].GetType().Name);
                    listBox2.Items.Add(pic.FigureList[i].GetType().Name);
                }
            }
            catch
            {
                MessageBox.Show("Items aren't selected");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(textBox11.Text);
                int y = int.Parse(textBox12.Text);
                pic.Move(x, y);
                pictureBox1.Top += y;
                pictureBox1.Left += x;
                g.Clear(Color.White);
                pictureBox1.Refresh();
                label14.Text = pic.ToString();
                pic.DrawAll(g);

            }
            catch
            {
                MessageBox.Show("Wrong data");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "XML Files (*.xml)|*.xml;";

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string a = openFileDialog1.FileName;
                    pic = Doc.Load(a);
                    pics.Add(pic);
                    label14.Text = pic.ToString();

                    listBox3.Items.Add(pic.GetType().Name);
                    listBox4.Items.Add(pic.GetType().Name);
                    listBox3.SelectedIndex = listBox3.Items.Count - 1;
                }

                g.Clear(Color.White);
                pic.DrawAll(g);

                label5.Text = pic.FigureList[0].ToString();
                label14.Text = pic.ToString();

                while (listBox1.Items.Count > 0)
                {
                    listBox1.Items.RemoveAt(0);
                    listBox2.Items.RemoveAt(0);
                }

                for (int i = 0; i < pic.FigureList.Count; i++)
                {
                    listBox1.Items.Add(pic.FigureList[i].GetType().Name);
                    listBox2.Items.Add(pic.FigureList[i].GetType().Name);
                }
            }
            catch
            {
                MessageBox.Show("Error in loading a file");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                label5.Text = pic.FigureList[listBox1.SelectedIndex].ToString();
            }
            catch { }
        }
    }
    
}
