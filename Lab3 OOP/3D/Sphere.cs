using System;
using System.Drawing;

namespace Lab3_OOP
{
    class Sphere : Figure3D
    {
        public Sphere(Pen p, double x, double y, double z, double r) : base (p, x, y, z, r, r)
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(this.FPen, (float)(this.X - this.Radius), (float)(this.Y - this.Radius), 2 * (float)this.Radius, 2 * (float)this.Radius);
            g.DrawEllipse(this.FPen, (float)(this.X - this.Radius), (float)(this.Y - this.Radius/6), 2 * (float)this.Radius, (float)(this.Radius/2.5));
        }

        public override double Square()
        {
            return 4 * Pi * Pi * Radius * Radius;
        }

        public override double Volume()
        {
            return Square() * Radius / 3; ;
        }

        public override string ToXml()
        {
            return String.Format("<figure><type>{0}</type><x>{1}</x><y>{2}</y><z>{3}</z><rad>{4}</rad></figure>", this.GetType().Name, X, Y, Z, Radius);
        }
    }
}
