using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_OOP
{
    internal abstract class Figure3D : Figure
    {
        protected double Z { get; set; }
        protected double Height { get; set; }

        public Figure3D(Pen p, double x, double y, double z, double r, double h) :  base(p, x, y, r)
        {
            this.Z = z;
            this.Height = h;
            this.isFill = true;
        }

        public abstract double Volume();

        public override void Scale(double size)
        {
            this.Radius *= size;
            this.Height *= size;
        }

        public override string ToString()
        {
            return "X: " + this.X +
                   "; Y: " + this.Y + "; Radius:" + this.Radius + "Height: " + this.Height +
                    "; Fill: " + this.isFill + "; Square: " + this.Square() + "; Volume: " + this.Volume() + ".";
        }
    }
}
