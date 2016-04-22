using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_OOP
{
    class Picture
    {
        private Point Point { get; set; }
        private double Width { get; set; }
        private double Height { get; set; }
        public List<Figure> FigureList { get; set; }

        public Picture(Point p, double w, double h, List<Figure> l)
        {
            this.Point = p;
            this.Width = w;
            this.Height = h;
            this.FigureList = l;
        }

        public Figure this[int i]
        {
            get
            {
                return this.FigureList[i];
            }
        }

        public double Square()
        {
            double s = 0;

            for (int i = 0; i < this.FigureList.Count; i++)
            {
                s += this.FigureList[i].Square();
            }

            return s;
        }

        public void MoveFigures(double distanceX, double distanceY)
        {
            for (int i = 0; i < this.FigureList.Count; i++)
            {
                this.FigureList[i].Move(distanceX, distanceY);
            }
        }

        public override string ToString()
        {
            return "Type: " + this.GetType().Name + "\n X: " + this.Point.X + "; Y: " + this.Point.Y +
                    "\n Width: " + this.Width + "; Height: " + this.Height + "\n Figures count: " + this.FigureList.Count +
                    "\n Summary square: " + this.Square();
        }

        public void DrawAll(Graphics g)
        {
            for (int i = 0; i < this.FigureList.Count; i++)
            {
                this.FigureList[i].Draw(g);
            }
        }

        public void AddFigure(Figure f)
        {
            this.FigureList.Add(f);
        }

        public void RemoveFigure(int i)
        {
            this.FigureList.RemoveAt(i);
        }

        public void RemoveAllFigures()
        {
            this.FigureList.RemoveRange(0, this.FigureList.Count);
        }

        public void Move(int moveX, int moveY)
        {
            this.Point = new Point(this.Point.X + moveX, this.Point.Y + moveY);
            this.MoveFigures(moveX, moveY);
        }

        public void JoinPictures(Picture p)
        {
            for (int i = 0; i < p.FigureList.Count; i++)
            {
                this.AddFigure(p.FigureList[i]);
            }
        }

        public void Scale(double size)
        {
            this.Height *= size;
            this.Width *= size;

            for (int i = 0; i < this.FigureList.Count; i++)
            {
                this.FigureList[i].Scale(size);
            }
        }

        public void Draw(Graphics g)
        {
            Bitmap image = new Bitmap((int)this.Width, (int)this.Height);
            Graphics graphics = Graphics.FromImage(image);
            g.Clear(Color.White);
            this.DrawAll(g);
            g.DrawImageUnscaled(image, 0, 0);
        }

    }
}
