using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UI_Vaja_3
{
    internal class Training
    {
        public string input { get; set; }
        public string output { get; set; }

        public string pathOut { get; set; }
        public string pathIn { get; set; }

        public double eta { get; set; }
        public double alpha { get; set; }
        public int numSymbol { get; set; }
        public int hiddenLayerNum { get; set; }
        public int N { get; set; }

        private string pathGuess;
        
        private StreamReader reader;

        public List<int> topology { get; set; }
        public string Data { get; set; }

        public Training(string output, double eta, double alpha, int numSymbol, int hiddenLayerNum, int N)
        {
            this.output = output;
            this.input = output;

            //String pather = @"C:\Users\benmi\source\repos\UI_Vaja_3\UI_Vaja_3\"; // Laptop path
            String pather = @"C:\Users\Benjamin\source\repos\UI_Vaja_3\UI_Vaja_3\";


            this.pathGuess = pather + "lastGuess.txt";
            this.pathOut = pather + output;
            this.pathIn = pather + input;

            this.eta = eta;
            this.alpha = alpha;
            this.numSymbol = numSymbol;
            this.hiddenLayerNum = hiddenLayerNum;
            this.N = N; // input size (the number of vector points coordinates)

            this.topology = new List<int>();


        }

        public void ReadFile()
        {
            reader = File.OpenText(pathIn);
        }

        // reads the topology from the start of the given file
        public void getTopology()
        {
            topology.Clear();
            // gets topology fo net

            string read = reader.ReadLine();
            string[] bits = read.Split(' ');


            /* //uncomment for "debugging" purpuses
            N = int.Parse(bits[0]); //gets number of vectors each input consists of... AKA. densety of points
            hiddenLayerNum = int.Parse(bits[1]); // number of neurons in the middle...
            numSymbol = int.Parse(bits[2]); //number of outputs or possible results

            topology.Add(N);
            topology.Add(hiddenLayerNum);
            topology.Add(numSymbol);
            */

            int topologyLayer = 0;
            foreach(var b in bits)
            {
                topologyLayer = int.Parse(b);
                topology.Add(topologyLayer);
                Console.WriteLine(topologyLayer);
            }

            /* //uncomment for "debugging" purpuses
            Console.WriteLine(N);
            Console.WriteLine(hiddenLayerNum);
            Console.WriteLine(numSymbol);
            */

        }

        public int getNextInputs(List<double> inputVals)
        {
            inputVals.Clear();

            string read = reader.ReadLine();
            string[] bits = read.Split(' ');

            double oneValue;
            foreach(var b in bits)
            {
                if (b != "")
                {
                    oneValue = double.Parse(b);
                    inputVals.Add(oneValue);
                }
            }

            /* //uncomment for "debugging" purpuses
            foreach (var input in inputVals)
            {
                Console.Write(input + " ");
            }
            Console.WriteLine();
            Console.WriteLine("END OF INPUT");
            */

            return inputVals.Count;
        }

        public int getTargetVals(List<double> targetVals)
        {
            targetVals.Clear();

            string read = reader.ReadLine();
            string[] bits = read.Split(' ');

            double oneValue;
            foreach (var b in bits)
            {
                if (b != "")
                {
                    oneValue = double.Parse(b);
                    targetVals.Add(oneValue);
                }
            }


            /* //uncomment for "debugging" purpuses
            foreach (var input in targetVals)
            {
                Console.Write(input + " ");
            }
            Console.WriteLine();
            Console.WriteLine("END OF INPUT");
            */
            return targetVals.Count;
        }

        public bool isEof()
        {
            return reader.EndOfStream;
        }

        public void createFile()
        {
            System.IO.File.WriteAllText(pathOut, string.Empty);

            string[] line = { (N + " " + hiddenLayerNum + " " + numSymbol) };

            System.IO.File.WriteAllLines(pathOut, line);
        }

        public string getResult(int result)
        {
            string ret = "";
            for (int i = 1; i < numSymbol + 1; i++)
            {
                if (i == result)
                    ret += 1 + ".0 ";
                else
                    ret += 0 + ".0 ";
            }

            return ret;
        }

        public void makeExample(List<Vector> example, int result)
        {
            string numResult = getResult(result);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathOut, true)) //true is for appending to the file
            {
                for (int i = 0; i < example.Count(); i++)
                {
                    file.Write(example[i].FileWrite());
                    file.Write(" ");
                }
                file.WriteLine();
                file.WriteLine(numResult);
            }
        }

        public void makeGuessingExample(List<Vector> example, int result)
        {
            File.WriteAllText(pathGuess, string.Empty);

            string[] line = { (N + " " + hiddenLayerNum + " " + numSymbol) };

            File.WriteAllLines(pathGuess, line);

            string numResult = getResult(result);

            using (StreamWriter file = new StreamWriter(pathGuess, true)) //true is for appending to the file
            {
                for (int i = 0; i < example.Count(); i++)
                {
                    file.Write(example[i].FileWrite());
                    file.Write(" ");
                }
                file.WriteLine();
                file.WriteLine(numResult);
            }

            reader = File.OpenText(pathGuess);
        }

        public void GuessingMode()
        {

        }

        public void GuessingModeOff()
        {
            reader = File.OpenText(pathIn);
        }
    }
}