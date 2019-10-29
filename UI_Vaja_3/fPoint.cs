using System;

namespace UI_Vaja_3
{
    public class fPoint
    {
        public int x { get; set; }
        public int y { get; set; }
        public bool fixate { get; set; }
        public int index { get; set; }
        public int drawingIndex { get; set; }

        public fPoint(int x, int y, bool fixate)
        {
            this.x = x;
            this.y = y;
            this.fixate = fixate;
        }

        public fPoint(fPoint a)
        {
            this.x = a.x;
            this.y = a.y;
            this.fixate = a.fixate;
            this.index = a.index;
        }

        public int getDistance(fPoint a)
        {
            int fX = Math.Abs((this.x - a.x));
            int fY = Math.Abs((this.y - a.y));

            return ((int)Math.Sqrt((fX * fX) + (fY * fY)));
        }

        public string toString()
        {
            return ("(" + x + "," + y + ")");
        }

        public void output()
        {
            Console.WriteLine("(" + x + "," + y + ")");
        }
    }
}