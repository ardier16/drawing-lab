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
        public abstract void Scale(double size, bool p);
        public abstract override string ToString();
        public abstract double Square();
        public abstract string ToXml();

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

        public bool Cross(Figure f2)
        {
            string n1 = "Cylinder Torus Sphere";
            double distance = Math.Sqrt(Math.Pow(f2.X - this.X, 2) + Math.Pow(f2.Y - this.Y, 2));

            if (n1.Contains(this.GetType().Name) && n1.Contains(f2.GetType().Name))
            {
                Figure3D k1 = (Figure3D)this;
                Figure3D k2 = (Figure3D)f2;

                return k1.Cross(k2);
            }

            #region 2D
            else if (Math.Round(distance) == 0 && this.Square() == f2.Square())
                return true;

            else if (this.Radius >= f2.Radius)
            {
                double r = Math.Round(Math.Sqrt(this.Radius * this.Radius - (this.Square() / Pi)));

                if (this.X + r >= f2.X + f2.Radius && this.X - r <= f2.X - f2.Radius &&
                    this.Y + r >= f2.Y + f2.Radius && this.Y - r <= f2.Y - f2.Radius)
                    return false;
                else if ((this.X + this.Radius >= f2.X + f2.Radius && this.X - this.Radius <= f2.X - f2.Radius &&
                    this.Y + this.Radius >= f2.Y + f2.Radius && this.Y - this.Radius <= f2.Y - f2.Radius) && this.GetType().Name == "Circle")
                    return false;

                else if (distance < this.Radius + f2.Radius)
                    return true;
            }

            else if (this.Radius <= f2.Radius)
            {
                double r = Math.Sqrt(f2.Radius * f2.Radius - (f2.Square() / Pi));

                if (f2.X + r >= this.X + this.Radius && f2.X - r <= this.X - this.Radius &&
                    f2.Y + r >= this.Y + this.Radius && f2.Y - r <= this.Y - this.Radius)
                    return false;
                else if ((f2.X + f2.Radius >= this.X + this.Radius && f2.X - f2.Radius <= this.X - this.Radius &&
                    f2.Y + f2.Radius >= this.Y + this.Radius && f2.Y - f2.Radius <= this.Y - this.Radius) && this.GetType().Name == "Circle")
                    return false;
                else if (distance < this.Radius + f2.Radius)
                    return true;
            }

            else if (distance < this.Radius + f2.Radius)
                return true;
            #endregion

            return false;
        }


    }
}
