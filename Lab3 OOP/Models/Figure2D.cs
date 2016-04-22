using System;
using System.Drawing;

namespace Lab3_OOP
{
    public abstract class Figure2D : Figure
    {

        public Figure2D(Pen p, double x, double y, double w) : base(p, x, y, w)
        {
        }

        public Figure2D(SolidBrush s, double x, double y, double w) : base (s, x, y, w)
        {
        }

        public abstract double Perimeter();

        public override void Scale(double size)
        {
            this.Radius *= size;
        }

        public override string ToString()
        {
            return "Type: " + this.GetType().Name +  "; X: " + this.X +
                   "; Y: " + this.Y + "; Radius:" + this.Radius + "; Fill: " + this.isFill +
                   "; Square: " + this.Square() + "; Perimeter: " + this.Perimeter() + ".";
        }

        
    }
}
