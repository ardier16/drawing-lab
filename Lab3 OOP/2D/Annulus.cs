using System;
using System.Drawing;

namespace Lab3_OOP
{
    internal class Annulus : Circle
    {
        protected double BigRadius { get; set; }

        public Annulus(Pen p, double x, double y, double r1, double r2) : base(p, x, y, r1)
        {
            this.BigRadius = r2;
        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(this.FPen, (float)(this.X- this.Radius), (float)(this.Y- this.Radius), 2* (float)this.Radius, 2* (float)this.Radius);
            g.DrawEllipse(this.FPen, (float)(this.X - this.BigRadius), (float)(this.Y - this.BigRadius), 2 * (float)this.BigRadius, 2 * (float)this.BigRadius);
        }

        public override void Scale(double size)
        {
            this.Radius *= size;
            this.BigRadius *= size;
        }

        public override string ToString()
        {
            return "Type: Annulus; X: " + this.X + "; Y: " + this.Y + 
                   "; Radius:" + this.Radius + "; Big Radius:" + this.BigRadius + "; Fill: " + this.isFill +
                   "; Square: " + this.Square() + "; Perimeter: " + this.Perimeter() + ".";
        }

        public override double Square()
        {
            return Pi*BigRadius*BigRadius - Pi * Radius * Radius;
        }

        public override double Perimeter()
        {
            return 2 * Pi * (Radius + BigRadius);
        }
    }
}
