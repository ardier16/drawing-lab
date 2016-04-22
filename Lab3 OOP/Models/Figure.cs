using System;
using System.Drawing;

namespace Lab3_OOP
{
    public abstract class Figure
    {
        protected bool isFill;
        protected double X { get; set; }
        protected double Y { get; set; }
        protected Pen FPen { get; set; }
        protected SolidBrush FBrush { get; set; }
        protected double Radius { get; set; }
        protected const double Pi = 3.1415926535897931;


        public Figure()
        {
        }

        public Figure(Pen p, double x, double y, double w)
        {
            this.FPen = p;
            this.X = x;
            this.Y = y;
            this.Radius = w;
            this.isFill = false;
        }

        public Figure(SolidBrush s, double x, double y, double w)
        {
            this.X = x;
            this.Y = y;
            this.Radius = w;
            this.isFill = true;
            this.FBrush = s;
        }

        public abstract void Draw(Graphics g);
        public abstract void Scale(double size);
        public abstract override string ToString();
        public abstract double Square();

        public void Move(Point p)
        {
            this.X = p.X;
            this.Y = p.Y;
        }

        public void Move(double distanceX, double distanceY)
        {
            this.X += distanceX;
            this.Y += distanceY;
        }

    }
}
