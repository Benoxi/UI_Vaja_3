using System.Collections.Generic;
using System.Linq;
using System;

namespace UI_Vaja_3
{
    internal class Neuron
    {
        Random rnd = new Random();
        private int p_myIndex;
        private double p_outValue;

        private double p_gradient;

        public List<Connection> p_outWeights { get; set; }

        public double eta { get; set; } //[0.0 -> 1.0] overal network training rate                         0.15
        public double alpha { get; set; } //[0.0 -> n] multiplier of last weight change (momentum)          0.5

        public Neuron(int numOuts, int myIndex)
        {
            p_outWeights = new List<Connection>();
            this.p_myIndex = myIndex;
            for (int c = 0; c < numOuts; c++)
            {
                p_outWeights.Add(new Connection());
                //Weigths are radnomized on creation 0.0-1.0
                p_outWeights.Last<Connection>().weight = randomWeight();
            }

            this.eta = 0.15;
            this.alpha = 0.5;
        }

        private double randomWeight()
        {
            return (rnd.NextDouble());
        }

        private double transformationFun(double x)
        {
            // transformation function this is where we apply a sigmoid function or any kind of that sort
            return Math.Tanh(x);
        }

        private double hipTan(double x)
        {
            /* hiperbolic tangent derivative :
               d
              - tanh x = 1 - tanh^2 x
             dx
             */
            
            
            /*

            THIS FUNCTION CAUSE ALL MY PROBLEMS IN THE BEGINNING, BECAUSE I USED A APROXIMATION FUNCTION SEEN BELOW! 

            */


            double th = Math.Tanh(x);
            return (1.0 - (th * th));

            //return (1.0 - (x * x)); // a very simplified transformation with a aproximation to the derivative of hiperbolic tangent
        }

        private double sumDOW(Layer nextLayer)
        {
            double sum = 0.0;

            //We have to sum our contributions of the errors at the nodes we feed

            for (int n = 0; n < nextLayer.layer.Count() - 1; n++)
            {
                sum += p_outWeights[n].weight * nextLayer.layer[n].p_gradient;
            }
            return sum;
        }

        public void calcHiddenGradients(Layer nextLayer)
        {
            double dow = sumDOW(nextLayer);
            p_gradient = dow * hipTan(p_outValue);
        }

        public void updateInputWeights(Layer prevLayer)
        {
            //the wieghts that are going to be updated in the Connection container ine the neurons from the preceding layer

            for (int n = 0; n < prevLayer.layer.Count(); n++)
            {
                Neuron neuron = prevLayer.layer[n];
                double oldDeltaW = neuron.p_outWeights[p_myIndex].deltaWeight;

                /*
                eta - overal net learning rate
                    0.0 - slow leaner
                    0.2 - medium leaner
                    1.0 - reckless leaner

                alpha - momentum
                    0.0 - no momentum
                    0.5 - moderate momentum
                */

                //individual input, magnified by the gradient and train rate
                double newDeltaW = eta * neuron.getOutValue() * p_gradient + alpha * oldDeltaW;
                //previus neurons multiplied by our neurons (current) gradient + alpha (momentum) times old Delta Weight,
                //this last part with alpha is so tlhat the neural net keeps going in ruffly the same direction

                //this is the new change in weight

                neuron.p_outWeights[p_myIndex].deltaWeight = newDeltaW;
                neuron.p_outWeights[p_myIndex].weight += newDeltaW;
            }
        }

        public void calcOutputGradients(double targetVal)
        {
            double delta = targetVal - p_outValue;
            p_gradient = delta * hipTan(p_outValue);
        }

        public void feedFoward(Layer prevLayer)
        {
            double sum = 0.0;

            for (int n = 0; n < prevLayer.layer.Count; n++)
            {
                sum += prevLayer.layer[n].getOutValue() * prevLayer.layer[n].p_outWeights[p_myIndex].weight;
            }

            p_outValue = transformationFun(sum);
        }

        public void setOutValue(double value)
        {
            this.p_outValue = value;
        }

        public double getOutValue()
        {
            //return Math.Round(this.p_outValue, 10);
            return this.p_outValue;
        }
    }
}