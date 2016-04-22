using System;
using System.Drawing;

namespace Lab3_OOP
{
    internal class FillAnnulus : Annulus
    {
        public FillAnnulus(Pen p, SolidBrush s, double x, double y, double r1, double r2) : base(p, x, y, r1, r2)
        {
            this.FBrush = s;
            this.isFill = true;
        }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(this.FBrush, (float)(this.X - this.BigRadius), (float)(this.Y - this.BigRadius), 2 * (float)this.BigRadius, 2 * (float)this.BigRadius);
            g.FillEllipse(new SolidBrush(Color.White), (float)(this.X - this.Radius), (float)(this.Y - this.Radius), 2 * (float)this.Radius, 2 * (float)this.Radius);
        }
    }
}
