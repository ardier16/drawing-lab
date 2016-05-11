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
        public override abstract string ToXml();

        public override void Scale(double size, bool p)
        {
            if (p)
            {
                X *= size;
                Y *= size;
                Z *= size;
            }
            this.Radius *= size;
            this.Height *= size;
        }

        public override string ToString()
        {
            return "X: " + this.X +
                   "; Y: " + this.Y + "; Radius:" + this.Radius + "Height: " + this.Height +
                    "; Fill: " + this.isFill + "; Square: " + this.Square() + "; Volume: " + this.Volume() + ".";
        }

        public bool Cross(Figure3D f2)
        {
            double distance = Math.Sqrt(Math.Pow(f2.X - this.X, 2) + Math.Pow(f2.Y - this.Y, 2));

            if (this.Z-this.Height <= f2.Z && this.Z - this.Height >= f2.Z-f2.Height)
            {
                if (distance < this.Radius + f2.Radius)
                    return true;
            }

            else if(f2.Z-f2.Height <= this.Z && f2.Z - f2.Height >= this.Z-this.Height)
            {
                if (distance < this.Radius + f2.Radius)
                    return true;
            }

            return false;
        }
    }
}
