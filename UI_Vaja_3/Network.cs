using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI_Vaja_3
{
    internal class Network
    {
        private List<Layer> p_layers;
        private double p_error;

        //just to see how our net is doing through time
        public double p_recentAverageError { get; set; }

        private double p_recentAverageSmoothingFactor;

        public Network(List<int> topology)
        {
            p_layers = new List<Layer>();
            int numLayers = topology.Count;
            for (int layerNum = 0; layerNum < numLayers; layerNum++)
            {
                p_layers.Add(new Layer());
                int numOuts = layerNum == topology.Count() - 1 ? 0 : topology[layerNum + 1]; //if equal to layerNum numOuts are 0, else whatever the numLaysers is

                for (int neuronNum = 0; neuronNum <= topology[layerNum]; neuronNum++) // <= because of bais
                {
                    p_layers.Last<Layer>().layer.Add(new Neuron(numOuts, neuronNum));
                }

                //Here we set the bias value
                p_layers.Last<Layer>().layer.Last<Neuron>().setOutValue(1.0);
            }
        }

        public void getResults(List<double> resultVals)
        {
            resultVals.Clear();

            for (int n = 0; n < p_layers.Last<Layer>().layer.Count() - 1; n++)
            {
                resultVals.Add(p_layers.Last<Layer>().layer[n].getOutValue());
            }
        }

        public void backProp(List<double> targetVals)
        {
            //Calculate overall error (RMS of output neuron error) RMS => Root Mean Square Error

            Layer outLayer = p_layers.Last<Layer>();
            p_error = 0.0;

            for (int n = 0; n < outLayer.layer.Count() - 1; n++)
            {
                double delta = targetVals[n] - outLayer.layer[n].getOutValue();
                p_error += delta * delta;
            }
            p_error /= outLayer.layer.Count() - 1;
            p_error = Math.Sqrt(p_error);

            //just calculating an average of the previous runs of this function
            p_recentAverageError = (p_recentAverageError * p_recentAverageSmoothingFactor + p_error) / (p_recentAverageSmoothingFactor + 1.0);

            //Calculate output layer gradients

            for (int n = 0; n < outLayer.layer.Count() - 1; n++)
            {
                outLayer.layer[n].calcOutputGradients(targetVals[n]);
            }
            //Calculate gradients on hidden layers

            for (int layerNum = p_layers.Count() - 2; layerNum > 0; --layerNum)
            {
                Layer hiddenLayer = p_layers[layerNum];
                Layer nextLayer = p_layers[layerNum + 1];

                for (int n = 0; n < hiddenLayer.layer.Count; n++)
                {
                    hiddenLayer.layer[n].calcHiddenGradients(nextLayer);
                }
            }

            //For all layers from outputs to first hidden layer,
            //update connection wight

            for (int layerNum = p_layers.Count() - 1; layerNum > 0; --layerNum)
            {
                Layer layer = p_layers[layerNum];
                Layer prevLayer = p_layers[layerNum - 1];

                for (int n = 0; n < layer.layer.Count() - 1; n++)
                {
                    layer.layer[n].updateInputWeights(prevLayer);
                }
            }
        }

        public void feedFoward(List<double> inputVals)
        {
            if (inputVals.Count() == (p_layers[0].layer.Count) - 1)
            {
                for (int i = 0; i < inputVals.Count; i++)
                {
                    p_layers[0].layer[i].setOutValue(inputVals[i]);
                }

                for (int layerNum = 1; layerNum < p_layers.Count; layerNum++)
                {
                    Layer prevLayer = p_layers[layerNum - 1];
                    for (int n = 0; n < p_layers[layerNum].layer.Count - 1; n++)
                    {
                        p_layers[layerNum].layer[n].feedFoward(prevLayer);
                    }
                }
            }
            else
            {
                MessageBox.Show("Input number is not equal to the number of layers in p_layers");
            }
        }
    }
}