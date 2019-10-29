using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace UI_Vaja_3
{
    public partial class Form1 : Form
    {
        private List<Vector> vectors = new List<Vector>();
        private Network myNet;

        private Graphics g;
        private int x = -1;
        private int y = -1;
        private bool drawing = false;
        private bool hasDrawn = false;
        private Pen pen;
        private Training train;
        private bool training = false;
        private bool guessing = false;
        private int symbol;
        private int GlobalDrawingIndex;

        private fPointField points;


        public Form1()
        {
            InitializeComponent();
            GlobalDrawingIndex = 0;
            points = new fPointField(280);
            g = CanvasBoard.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 5);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void MouseDownEvent(object sender, MouseEventArgs e)
        {
            GlobalDrawingIndex = 0;
            if (hasDrawn == false)
            {
                drawing = true;
                x = e.X;
                y = e.Y;
                fPoint nov = new fPoint(x, y, true); //Fixate first point !
                nov.drawingIndex = GlobalDrawingIndex;
                GlobalDrawingIndex++;
                points.ADD(nov);
                nov.output();
            }
        }

        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            if (hasDrawn == false)
            {
                if (drawing && x != -1 && y != -1)
                {
                    g.DrawLine(pen, new Point(x, y), e.Location);
                    x = e.X;
                    y = e.Y;
                    coorX.Text = x.ToString();
                    coorY.Text = y.ToString();
                    fPoint nov = new fPoint(x, y, false); //Do not fixate points inbetween
                    nov.drawingIndex = GlobalDrawingIndex;
                    GlobalDrawingIndex++;
                    points.ADD(nov);
                }
            }
        }

        private void MouseUpEvent(object sender, MouseEventArgs e)
        {
            if(guessing == true)
            {
                lbNetwork.Text = "GUESSING...";
            }


            fPoint nov = new fPoint(x, y, true); // Fixate last point !
            nov.drawingIndex = GlobalDrawingIndex;
            GlobalDrawingIndex++;
            points.ADD(nov);
            nov.output();
            hasDrawn = true;
            drawing = false;
            x = -1;
            y = -1;

            int N = Int32.Parse(vektBox.Text);
            int N2 = N / 2;


            if (points.COUNT() < N || points.COUNT() == N)
            {
                Console.WriteLine("There is not enough points, number of points = " + points.COUNT() + ",  given N = " + N);
                CLEAR();
            }
            else
            {
                Console.WriteLine("Number of points = " + points.COUNT() + ", given N = " + N);

                if (N % 2 != 0) // if N is not even, make it even, by adding 1 to it
                {
                    N++;
                }

                if (training == true)
                {
                    N = Int32.Parse(vektBox.Text);

                    int symbol = Int32.Parse(symBox.Text);

                    VECTORIZE(N2);

                    train.makeExample(vectors, symbol);

                    CLEAR();
                }

                if(guessing == true)
                {
                    string guess = "...";

                    train.GuessingMode();

                    N = train.N;

                    int symbol = Int32.Parse(symBox.Text);

                    VECTORIZE(N2);

                    train.makeGuessingExample(vectors, symbol);

                    List<double> inputVals = new List<double>(), targetVals = new List<double>(), resultVals = new List<double>();

                    train.getTopology();

                    if (train.getNextInputs(inputVals) != train.topology[0])
                    {
                        Console.WriteLine("TOPOLOGY IS NOT EQUAL !!!!");
                    }
                    else
                    {

                        myNet.feedFoward(inputVals);

                        myNet.getResults(resultVals);

                        Console.WriteLine("Pass: " + 1);
                        showValues("Inputs: ", inputVals);
                        showValues("Outputs: ", resultVals);

                        Console.WriteLine();
                    }

                    Console.WriteLine("Done !");

                    guess = getGuess(resultVals);

                    lbNetwork.Text = "MY GUESS IS: " + guess;

                    train.GuessingModeOff();
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            //add the vector to a list and then delete the vector
            CanvasBoard.Invalidate();
            hasDrawn = false;
            points.CLEAR();
            vectors.Clear();
            GlobalDrawingIndex = 0;
        }

        public string getGuess(List<double> v)
        {
            string guess = "UNKNOWN!";

            int biggestIndex = 0;
            double biggest = -100000.0;
            for (int i = 0; i < v.Count; i++)
            {
                if (biggest < v[i])
                {
                    biggest = v[i];
                    biggestIndex = i;
                }
            }
            biggestIndex++;

            guess = biggestIndex.ToString();

            return guess;
        }

        public void CLEAR()
        {
            CanvasBoard.Invalidate();
            hasDrawn = false;
            points.CLEAR();
            vectors.Clear();
            GlobalDrawingIndex = 0;
        }

        public void REMOVE_DEFORMED()
        {
            int average = 0;
            foreach (var v in vectors)
            {
                average += v.getDistance();
            }

            average = (int)(average / vectors.Count);


            int averageTimes2 = 3 * average;

            for (int i = 0; i < vectors.Count; i++)
            {
                if (vectors[i].getDistance() > averageTimes2)
                {
                    vectors.RemoveAt(i);
                    i = 0;
                }
            }
        }

        public void VECTORIZE(int N)
        {
            points.REDUCE(N);

            g.DrawLine(new Pen(Color.White, 500), new Point(0, 0), new Point(280, 280));

            foreach (var p in points.field)
            {
                g.FillEllipse(new SolidBrush(Color.FromArgb(4, 214, 43)), p.x, p.y, 6, 6);
            }

            for (int i = 0; i < points.COUNT(); i = i + 2)
            {
                Vector novA = new Vector(points.findAtIndex(i), points.findAtIndex(i + 1));
                vectors.Add(novA);
            }

            Console.WriteLine("This number has a total of " + getVectorsAmount().ToString() + " vectors, for N = " + N + " before removing deformed");
            //REMOVE_DEFORMED(); // removes to many... Actually should not remove a single one

            //Console.WriteLine("This number has a total of " + getVectorsAmount().ToString() + " vectors, for N = " + N);

            foreach (Vector v in vectors)
            {
                g.DrawLine(pen, new Point(v.a.x, v.a.y), new Point(v.b.x, v.b.y));
            }
        }

        public int getVectorsAmount()
        {
            return vectors.Count;
        }

        private void btnVekt_Click(object sender, EventArgs e)
        {
            int N = Int32.Parse(vektBox.Text);

            int symbol = Int32.Parse(symBox.Text);

            int numSymb = Int32.Parse(symNumBox.Text);

            int hiddenLayer = Int32.Parse(layerBox.Text);

            double alpha = Double.Parse(alphaBox.Text);  // changing the weight or learning border

            double eta = Double.Parse(etaBox.Text);  // learning speed

            VECTORIZE(N/2);

            Console.WriteLine("\n\n\n");
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            training = true;

            int N = Int32.Parse(vektBox.Text);

            int symbol = Int32.Parse(symBox.Text);

            int numSymb = Int32.Parse(symNumBox.Text);

            int hiddenLayer = Int32.Parse(layerBox.Text);

            double alpha = Double.Parse(alphaBox.Text);  // changing the weight or learning border

            double eta = Double.Parse(etaBox.Text);  // learning speed

            train = new Training("newlyTrained.txt", eta, alpha, numSymb, hiddenLayer, N);

            train.createFile();
        }

        public void showValues(string label, List<double> v)
        {
            if (label.Equals("Outputs: ") && v.Count > 1)
            {
                Console.Write(label + " ");
                int biggestIndex = 0;
                double biggest = -100000.0;
                for (int i = 0; i < v.Count; i++)
                {
                    if (biggest < v[i])
                    {
                        biggest = v[i];
                        biggestIndex = i;
                    }
                }

                for (int i = 0; i < v.Count; i++)
                {
                    if (biggestIndex == i)
                    {
                        Console.Write(1 + " ");
                    }
                    else
                    {
                        Console.Write(0 + " ");
                    }
                }

                Console.WriteLine();
            }
            else
            {
                Console.Write(label + " ");
                foreach (double a in v)
                {
                    Console.Write(a + " ");
                }

                Console.WriteLine();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            training = false;
            guessing = false;

            CLEAR();

            lbNetwork.Text = "STOPPED !";
        }

        private void btnDirect_Click(object sender, EventArgs e)
        {
            lbNetwork.Text = "DIRECTLY TRAINING!";

            int N = Int32.Parse(vektBox.Text);

            int symbol = Int32.Parse(symBox.Text);

            int numSymb = Int32.Parse(symNumBox.Text);

            int hiddenLayer = Int32.Parse(layerBox.Text);

            double alpha = Double.Parse(alphaBox.Text);  // changing the weight or learning border

            double eta = Double.Parse(etaBox.Text);  // learning speed 

            string file = fileBox.Text.ToString();

            train = new Training(file, eta, alpha, numSymb, hiddenLayer, N);

            train.ReadFile();

            train.getTopology();

            myNet = new Network(train.topology);

            List<double> inputVals = new List<double>(), targetVals = new List<double>(), resultVals = new List<double>();

            int trainPass = 0;

            while (!train.isEof())
            {
                trainPass++;

                //Console.WriteLine("Pass: " + trainPass);

                if (train.getNextInputs(inputVals) != train.topology[0])
                {
                    Console.WriteLine("TOPOLOGY IS NOT EQUAL !!!!");
                    break;
                }

                myNet.feedFoward(inputVals);

                myNet.getResults(resultVals);

                train.getTargetVals(targetVals);

                myNet.backProp(targetVals);

                //Console.WriteLine("Network recent average error: " + myNet.p_recentAverageError);

                if(trainPass == 0)
                {
                    Console.WriteLine("Pass: " + trainPass);
                    showValues("Inputs: ", inputVals);
                    showValues("Outputs: ", resultVals);
                    showValues("Targets: ", targetVals);
                    Console.WriteLine("Network recent average error: " + myNet.p_recentAverageError);

                    Console.WriteLine();
                }
            }

            Console.WriteLine("Done !");

            lbNetwork.Text = "HERE !";
        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            training = false;
            guessing = true;

            CLEAR();
            lbNetwork.Text = "THINKING...";
        }
    }
}