using System;
using System.Drawing;


namespace Lab3_OOP
{
    internal class Cylinder : Figure3D
    {

        public Cylinder(Pen p, double x, double y, double z, double r, double h) : base(p, x, y, z, r, h)
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(this.FPen, (float)(this.X - this.Radius), (float)(this.Y - this.Radius/2 - this.Height), 2 * (float)this.Radius, (float)this.Radius);
            g.DrawEllipse(this.FPen, (float)(this.X - this.Radius), (float)(this.Y - this.Radius/2), 2 * (float)this.Radius, (float)this.Radius);
            g.DrawLine(this.FPen, (float)(this.X - this.Radius), (float)(this.Y), (float)(this.X - this.Radius), (float)(this.Y - this.Height));
            g.DrawLine(this.FPen, (float)(this.X + this.Radius), (float)(this.Y), (float)(this.X + this.Radius), (float)(this.Y - this.Height));
        }

        public override string ToString()
        {
            return "Type: Cylinder; " + base.ToString();
        }

        public override double Square()
        {
            return 2 * Pi * Radius * (Radius + Height);
        }

        public override double Volume()
        {
            return Pi * Radius * Radius * Height;
        }

    }
}
