using System;
using System.Drawing;

namespace Lab3_OOP
{
    class Torus : Figure3D
    {
        public Torus(Pen p, SolidBrush s, double x, double y, double z, double r, double h) : base(p, x, y, z, r, h) 
        {
            this.FBrush = s;
        }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(this.FBrush, (float)(this.X - this.Radius), (float)(this.Y - this.Radius), 2 * (float)this.Radius, (float)(1.5 * this.Radius));
            g.FillEllipse(new SolidBrush(Color.White), (float)(this.X - this.Radius + this.Height), (float)(this.Y - this.Radius +  this.Height), 
                          (float)(2*this.Radius - 2*this.Height), (float)(1.5 * this.Radius - 2*this.Height));
            g.DrawEllipse(this.FPen, (float)(this.X - this.Radius + this.Height/2), (float)(this.Y - this.Radius + this.Height*0.15),
                          (float)(2 * this.Radius -  this.Height), (float)(1.5*this.Radius - this.Height));
        }

        public override double Square()
        {
            return 4 * Pi * Pi * Radius * Height;
        }

        public override double Volume()
        {
            return 2 * Pi * Pi * Radius * Height * Height;
        }

        public override string ToXml()
        {
            return String.Format("<figure><type>{0}</type><x>{1}</x><y>{2}</y><z>{3}</z><rad>{4}</rad><h>{5}</h></figure>", this.GetType().Name, X, Y, Z, Radius, Height);
        }

    }
}
