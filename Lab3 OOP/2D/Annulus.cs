using System;
using System.Drawing;

namespace Lab3_OOP
{
    internal class Annulus : Circle
    {
        protected double ShortRadius { get; set; }

        public Annulus(Pen p, double x, double y, double r1, double r2) : base(p, x, y, r1)
        {
            this.ShortRadius = r2;
        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(this.FPen, (float)(this.X- this.Radius), (float)(this.Y- this.Radius), 2* (float)this.Radius, 2* (float)this.Radius);
            g.DrawEllipse(this.FPen, (float)(this.X - this.ShortRadius), (float)(this.Y - this.ShortRadius), 2 * (float)this.ShortRadius, 2 * (float)this.ShortRadius);
        }

        public override void Scale(double size, bool p)
        {
            if (p)
            {
                X *= size;
                Y *= size;
            }
            this.Radius *= size;
            this.ShortRadius *= size;
        }

        public override string ToString()
        {
            return "Type: Annulus; X: " + this.X + "; Y: " + this.Y + 
                   "; Radius:" + this.Radius + "; Short Radius:" + this.ShortRadius + "; Fill: " + this.isFill +
                   "; Square: " + this.Square() + "; Perimeter: " + this.Perimeter() + ".";
        }

        public override double Square()
        {
            return Pi* Radius * Radius - Pi * ShortRadius * ShortRadius;
        }

        public override double Perimeter()
        {
            return 2 * Pi * (Radius + ShortRadius);
        }

        public override string ToXml()
        {
            return String.Format("<figure><type>{0}</type><x>{1}</x><y>{2}</y><rad>{3}</rad><srad>{4}</srad></figure>", this.GetType().Name, X, Y, Radius, ShortRadius);
        }
    }
}
