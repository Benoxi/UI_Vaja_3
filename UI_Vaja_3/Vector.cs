using System;
using System.Collections.Generic;

namespace UI_Vaja_3
{
    public class Vector
    {
        public fPoint a { get; set; }
        public fPoint b { get; set; }

        public Vector(fPoint a, fPoint b)
        {
            this.a = new fPoint(a);
            this.b = new fPoint(b);
        }

        public Vector(fPoint a)
        {
            this.a = new fPoint(a);
        }

        public int findPoint(List<fPoint> points)
        {
            int minIndex = 0;
            fPoint minPoint = new fPoint(10000, 10000, false);
            for (int i = 0; i < points.Count; i++)
            {
                if (this.a.getDistance(points[i]) < this.a.getDistance(minPoint) && a.getDistance(points[i]) > 0 && a.getDistance(minPoint) > 0)
                {
                    minPoint = new fPoint(points[i]);
                    minIndex = i;
                }
            }

            this.b = new fPoint(minPoint);
            return minIndex;
        }

        public string FileWrite()
        {
            double writeAx = (double)((double)a.x / (double)280);
            double writeAy = (double)((double)a.y / (double)280);
            double writeBx = (double)((double)b.x / (double)280);
            double writeBy = (double)((double)b.y / (double)280);

            return writeAx.ToString() + " " + writeAy.ToString() + " " + writeBx.ToString() + " " + writeBy.ToString();
        }

        public void output()
        {
            Console.WriteLine("\n");
            this.a.output();
            this.b.output();
        }

        public int getDistance()
        {
            int dX = Math.Abs(this.a.x - this.b.x);
            int dY = Math.Abs(this.a.y - this.b.y);

            if (this.a.y == this.b.y)
            {
                return dX;
            }
            else if (this.a.x == this.b.x)
            {
                return dY;
            }
            else
            {
                return ((int)Math.Sqrt((dX * dX) + (dY * dY)));
            }
        }
    }
}