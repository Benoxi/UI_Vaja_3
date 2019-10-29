using System;

namespace UI_Vaja_3
{
    internal class Connection
    {
        Random rnd = new Random();
        public double weight;
        public double deltaWeight;

        public Connection()
        {
            this.weight = rnd.NextDouble(); ///at creation gives random double from 0.0 - 1.0
        }
    }
}