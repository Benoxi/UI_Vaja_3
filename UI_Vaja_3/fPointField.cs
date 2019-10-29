using System;
using System.Collections.Generic;

namespace UI_Vaja_3
{
    internal class fPointField
    {
        public List<fPoint> field { get; set; }
        private int bitmapSize;
        private fPoint[] ClosestPair;

        public fPointField(int BmapSize)
        {
            this.field = new List<fPoint>();
            this.bitmapSize = BmapSize;
            this.ClosestPair = new fPoint[2];
        }

        public void ADD(fPoint point)
        {
            field.Add(point);
        }

        public int COUNT()
        {
            return field.Count;
        }

        public void CLEAR()
        {
            field.Clear();
        }

        public fPoint findAtIndex(int index)
        {
            for (int i = 0; i < field.Count; i++)
            {
                if (field[i].drawingIndex == index)
                {
                    return field[i];
                }
            }
            Console.WriteLine("Not found index was: " + index);
            return null;
        }

        public fPoint MEDIAN(fPoint a, fPoint b)
        {
            int fX = (a.x + b.x) / 2;
            int fY = (a.y + b.y) / 2;

            return new fPoint(fX, fY, false);
        }

        public int getMinXPoint()
        {
            int Minimal = 1000000;
            foreach (var p in field)
            {
                if (p.x < Minimal)
                {
                    Minimal = p.x;
                }
            }
            return Minimal;
        }

        public int getMinYPoint()
        {
            int Minimal = 1000000;
            foreach (var p in field)
            {
                if (p.y < Minimal)
                {
                    Minimal = p.y;
                }
            }
            return Minimal;
        }

        public int getMaxXPoint()
        {
            int Maximum = -10000;
            foreach (var p in field)
            {
                if (p.x > Maximum)
                {
                    Maximum = p.x;
                }
            }
            return Maximum;
        }

        public int getMaxYPoint()
        {
            int Maximum = -10000;
            foreach (var p in field)
            {
                if (p.y > Maximum)
                {
                    Maximum = p.y;
                }
            }
            return Maximum;
        }

        public double getScale(int scale)
        {
            return (double)((double)(bitmapSize - 10) / (double)scale);
        }

        public int getMiddleX(int N)
        {
            int averageX = 0;
            foreach (var p in field)
            {
                averageX += p.x;
            }

            averageX = (int)(averageX / N);

            return (averageX);
        }

        public int getMiddleY(int N)
        {
            int averageY = 0;
            foreach (var p in field)
            {
                averageY += p.y;
            }

            averageY = (int)(averageY / N);

            return (averageY);
        }

        public void IndexTheField()
        {
            for (int i = 0; i < field.Count; i++)
            {
                field[i].index = i;
            }
        }

        public void RemoveClosestPair()
        {
            int indexOne = ClosestPair[0].index;
            int indexTwo = ClosestPair[1].index;

            for (int i = 0; i < field.Count; i++)
            {
                if (field[i].index == indexOne || field[i].index == indexTwo)
                {
                    field.RemoveAt(i);
                    i = 0;
                }
            }
        }

        public List<fPoint> COPY(List<fPoint> newList)
        {
            field.Clear();
            for (int i = 0; i < newList.Count; i++)
            {
                field.Add(newList[i]);
            }

            return field;
        }

        public fPoint getNextSmallestDrawingIndex(int index)
        {
            int indexOfSmallest = 10000;
            int drawingIndexOfSmallest = 10000;

            for (int i = 0; i < field.Count; i++)
            {
                if (field[i].drawingIndex >= index)
                {
                    if (field[i].drawingIndex < drawingIndexOfSmallest)
                    {
                        drawingIndexOfSmallest = field[i].drawingIndex;
                        indexOfSmallest = i;
                    }
                }
            }

            return field[indexOfSmallest];
        }

        public void ReorderDrawingIndexes()
        {
            int k = 0;
            List<fPoint> newList = new List<fPoint>();
            for (int i = 0; i < field.Count; i++)
            {
                newList.Add(getNextSmallestDrawingIndex(i));
                newList[i].drawingIndex = k;
                k++;
            }

            field = COPY(newList);
        }

        public void Closest()
        {
            int minGlobalDistance = 1000000;

            for (int j = 0; j < field.Count; j++)
            {
                if (field[j].fixate == false)
                {
                    fPoint minPoint = new fPoint(10000, 10000, false);
                    int minDistance = 1000000;
                    for (int i = 0; i < field.Count; i++)
                    {
                        if (field[j].getDistance(field[i]) < field[j].getDistance(minPoint) && field[j].getDistance(field[i]) > 0 && field[j].getDistance(minPoint) > 0 && field[i].fixate == false)
                        {
                            minPoint = new fPoint(field[i]);
                            minDistance = field[j].getDistance(field[i]);
                        }
                    }

                    if (minGlobalDistance > minDistance)
                    {
                        minGlobalDistance = minDistance;
                        ClosestPair[0] = field[j];
                        ClosestPair[1] = minPoint;
                    }
                }
            }
        }

        public void movePoints(int X, int Y)
        {
            X -= 2;
            Y -= 2;

            for (int i = 0; i < field.Count; i++)
            {
                field[i].x -= X;
                field[i].y -= Y;
            }
        }

        public void movePointsToXMiddle(int midX)
        {
            int differenceX = 140 - midX;

            for (int i = 0; i < field.Count; i++)
            {
                field[i].x += differenceX;
            }
        }

        public void AddMedian()
        {
            int index = ClosestPair[0].drawingIndex;
            fPoint median = MEDIAN(ClosestPair[0], ClosestPair[1]);

            median.drawingIndex = index;

            ADD(median);
        }

        public void RemoveRandom(int N)
        {
            Random rnd = new Random();

            int rndIndex = rnd.Next(1, N);

            field.RemoveAt(rndIndex);
        }

        public void SCALE_INPUT(int N)
        {
            int minX = getMinXPoint();
            int minY = getMinYPoint();

            movePoints(minX, minY);

            int xScale = Math.Abs(getMaxXPoint() - getMinXPoint());
            int yScale = Math.Abs(getMaxYPoint() - getMinYPoint());

            double scale = 0;

            if (yScale > xScale)
            {
                // Y scale is bigger, scale for Y.
                scale = getScale(yScale);
                SCALE(scale);
            }
            else
            {
                // X scale is bigger, scale for X.
                scale = getScale(xScale);
                SCALE(scale);
            }

            movePointsToXMiddle(getMiddleX(N));
        }

        public void SCALE(double scale)
        {
            for (int i = 0; i < field.Count; i++)
            {
                field[i].x = (int)((double)field[i].x * (double)scale);
                field[i].y = (int)((double)field[i].y * (double)scale);
            }
        }

        public void REDUCE(int N)
        {
            int rounds = field.Count - N;

            Console.WriteLine("Number of all points = " + field.Count + ", N = " + N + ", calculated difference = " + rounds);

            if (rounds % 2 != 0)
            {
                RemoveRandom(N);
                rounds = field.Count - N;
            }

            for (int i = 0; i < rounds; i++)
            {
                IndexTheField();

                Closest();

                AddMedian();

                RemoveClosestPair();
            }

            ReorderDrawingIndexes();

            SCALE_INPUT(N);

            if (field.Count != N)
            {
                Console.WriteLine("This number has a total of " + field.Count.ToString() + " points, for N = " + N + "\n THERE IS AN ERROR !!! ");
            }
        }
    }
}