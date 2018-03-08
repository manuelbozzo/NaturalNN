using System;
using System.Collections.Generic;
using System.Linq;

namespace NaturalNN_Engine.Structures
{
    public class NeuronNet
    {
        public List<NeuronLayer> Layers { get; } = new List<NeuronLayer>();
        public NeuronLayer InputLayer { get; set; }
        public int[] Shape { get; }
        public double Error { get; set; }
        private readonly Random _rnd;
        public int Age { get; set; } = 0;

        public NeuronNet(int[] shape, Random rnd)
        {
            Shape = shape;
            _rnd = rnd;
            CreateLayers(shape);
            ConnectLayers();
        }

        private void ConnectInputLayer()
        {
            Layers.First().ConnectoToLeft();
        }

        public void SetInputLayer(double[] inputArray)
        {
            //comment for simple input
            //inputArray = AddSinSquareInput(inputArray);
            if (InputLayer == null)
            {
                InputLayer = new NeuronLayer(inputArray.Length, _rnd) { RigtLayer = Layers.First() };
                Layers.First().LeftLayer = InputLayer;
                ConnectInputLayer();
            }
            for (int i = 0; i < inputArray.Length; i++)
            {
                InputLayer.Neurons[i].Output = inputArray[i];
            }
        }

        private double[] AddSinSquareInput(double[] inputArray)
        {
            double[] newInputArray = new double[inputArray.Length * 3];
            for (int i = 0; i < inputArray.Length; i++)
            {
                newInputArray[i] = inputArray[i];
                newInputArray[i + inputArray.Length] = inputArray[i] * inputArray[i];
                newInputArray[i + inputArray.Length*2] = Math.Sin(inputArray[i]);
            }

            return newInputArray;
        }

        private double[] AddSquareinput(double[] inputArray)
        {
            double[] newInputArray = new double[inputArray.Length * 2];
            for (int i = 0; i < inputArray.Length; i++)
            {
                newInputArray[i] = inputArray[i];
                newInputArray[i + inputArray.Length] = inputArray[i]*inputArray[i];
            }

            return newInputArray;
        }


        private void CreateLayers(int[] shape)
        {
            foreach (int layerSize in shape)
            {
                if (Layers.Count > 0)
                {
                    NeuronLayer lastLayer = Layers.Last();
                    NeuronLayer newLayer = new NeuronLayer(layerSize, _rnd);
                    lastLayer.RigtLayer = newLayer;
                    newLayer.LeftLayer = lastLayer;
                    Layers.Add(newLayer);
                }
                else
                {
                    Layers.Add(new NeuronLayer(layerSize, _rnd));
                }
            }
        }

        private void ConnectLayers()
        {
            foreach (NeuronLayer neuronLayer in Layers)
            {
                if (neuronLayer.LeftLayer != null)
                {
                    neuronLayer.ConnectoToLeft();
                }
            }
        }

        public void ForwardPropagate()
        {
            foreach (NeuronLayer neuronLayer in Layers)
            {
                neuronLayer.ProcessOutput();
            }
        }

        public double[] GetOutputValues()
        {
            double[] result = new double[Layers.Last().Neurons.Count];
            for (int i = 0; i < Layers.Last().Neurons.Count; i++)
            {
                result[i] = Layers.Last().Neurons[i].Output;
            }

            return result;

        }

        public NeuronLayer GetRandomLayer()
        {
            return Layers[_rnd.Next(Layers.Count)];
        }

        public NeuronLayer GetLastLayer()
        {
            return Layers.Last();
        }

        public double GetError(List<double[]> inputTrainSet, List<double[]> outputTarget)
        {
            double getError = 0;
            bool monoResponse = true;
            double[] lastOutput = null;
            double[] thisOutput = new double[Layers.Last().Neurons.Count];
            for (int inputIndex = 0; inputIndex < inputTrainSet.Count; inputIndex++)
            {
                double[] inputTrain = inputTrainSet[inputIndex];
                SetInputLayer(inputTrain);
                ForwardPropagate();

                for (int index = 0; index < Layers.Last().Neurons.Count; index++)
                {
                    getError += Math.Abs(outputTarget[inputIndex][index] - Layers.Last().Neurons[index].Output);
                    thisOutput[index] = Layers.Last().Neurons[index].Output;
                    if (thisOutput[index] > 0.5) thisOutput[index] = 1;
                    if (thisOutput[index] < 0.5) thisOutput[index] = 0;
                }
                if(lastOutput == null)
                {
                    lastOutput = new double[Layers.Last().Neurons.Count];
                    for (int i = 0; i < Layers.Last().Neurons.Count; i++)
                    {
                        lastOutput[i] = thisOutput[i];
                    }
                }else if (!lastOutput.SequenceEqual(thisOutput)) //not equal, mark as not monoResponse
                {
                    monoResponse = false;
                }
            }
            Error = getError;
            return getError;
        }

        public string GetOutputStringValues()
        {
            string result = string.Empty;
            for (int i = 0; i < Layers.Last().Neurons.Count; i++)
            {
                result += Layers.Last().Neurons[i].Output.ToString();
            }

            return result;
        }

        public void RandomizeWeights(double minWeightValue, double maxWeightValue)
        {
            foreach (NeuronLayer layer in Layers)
            {
                foreach (Neuron neuron in layer.Neurons)
                {
                    neuron.Bias = (_rnd.NextDouble() * (maxWeightValue - minWeightValue) + minWeightValue) * 10;
                    foreach (Dendrite dendrite in neuron.Dendrites)
                    {
                        dendrite.Weight = _rnd.NextDouble() * (maxWeightValue - minWeightValue) + minWeightValue;
                    }
                }
            }
        }

        public int GetDendriteCount()
        {
            return Layers.Sum(layer => layer.Neurons.Sum(neuron => neuron.Dendrites.Count));
        }

        public double GetDendriteWeightAt(int index)
        {
            int localIndex = 0;
            foreach (NeuronLayer layer in Layers)
            {
                foreach (Neuron neuron in layer.Neurons)
                {
                    foreach (Dendrite dendrite in neuron.Dendrites)
                    {
                        if (localIndex == index)
                        {
                            return dendrite.Weight;
                        }
                        localIndex++;
                    }
                }
            }
            return -1;
        }

        public void SetDendriteWeightAt(int index, double weight)
        {
            int localIndex = 0;
            foreach (NeuronLayer layer in Layers)
            {
                foreach (Neuron neuron in layer.Neurons)
                {
                    foreach (Dendrite dendrite in neuron.Dendrites)
                    {
                        if (localIndex == index)
                        {
                            dendrite.Weight = weight;
                        }
                        localIndex++;
                    }
                }
            }
        }

        public NeuronNet CopyNet()
        {
            NeuronNet newNet = new NeuronNet(Shape,_rnd);
            int dendriteCount = GetDendriteCount();
            for (int i = 0; i < dendriteCount; i++)
            {
                newNet.SetDendriteWeightAt(i,GetDendriteWeightAt(i));
            }
            return newNet;
        }

    }
}
