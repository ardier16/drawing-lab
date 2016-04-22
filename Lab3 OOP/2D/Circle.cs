using System;
using System.Drawing;

namespace Lab3_OOP
{
    internal class Circle : Figure2D
    {     

        public Circle(Pen p, double x, double y, double r) : base(p, x, y, r)
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(this.FPen, (float)(this.X - this.Radius), (float)(this.Y - this.Radius), 2 * (float)this.Radius, 2 * (float)this.Radius);
        }

        public override double Square()
        {
            return Pi * Radius * Radius;
        }

        public override double Perimeter()
        {
            return 2 * Pi * Radius;
        }

    }
}
