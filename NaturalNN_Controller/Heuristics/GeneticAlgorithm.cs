using System;
using System.Collections.Generic;
using System.Linq;
using NaturalNN_Engine.Structures;

namespace NaturalNN_Controller.Heuristics
{
    class GeneticAlgorithm
    {
        public int PopulationSize { get; }
        private Random Rnd { get; }
        public double MinWeightValue { get; }
        public double MaxWeightValue { get; }
        public List<double[]> _inputTrainSet { get; set; }
        public List<double[]> _outputTarget { get; set; }
        public List<NeuronNet> PopulationList { get; set; } = new List<NeuronNet>();
        public NeuronNet BestIndividual { get; set; }
        public int[] Shape { get; }
        public double[] InputExample { get; }


        public GeneticAlgorithm(int[] shape,  int populationSize, Random rnd, double minWeightValue, double maxWeightValue, double[] inputExample)
        {
            
            PopulationSize = populationSize;
            Rnd = rnd;
            MinWeightValue = minWeightValue;
            MaxWeightValue = maxWeightValue;
            InputExample = inputExample;
            Shape = shape;

            for (int i = 0; i < populationSize; i++)
            {
                PopulationList.Add(new NeuronNet(shape, Rnd));
            }
            foreach (NeuronNet neuronNet in PopulationList) //randomize individuals
            {
                neuronNet.SetInputLayer(inputExample);
                neuronNet.RandomizeWeights(MinWeightValue, MaxWeightValue);
            }
        }

        public void RunGenerations(int iterations, List<double[]> inputTrainSet, List<double[]> outputTarget, int maxAge)
        {
            _inputTrainSet = inputTrainSet;
            _outputTarget = outputTarget;

            for (int i = 0; i < iterations; i++)
            {
                EvaluatePopulation();
                SortPopulation();
                //CopyRightKill();
                if (PopulationList.First().Error <= 0.1) break;
                PrintBestIndividualError(i);
                SurvivalOfTheFitest(0.01d, PopulationSize, maxAge);
                Mutation(0.05d, 0.1d);
                CrossPopulation();
                DieOfAge(maxAge);
            }
            EvaluatePopulation();
            SortPopulation();
            PrintBestIndividualError(iterations);
            Console.WriteLine("End...");
        }

        private void CopyRightKill()
        {
            List<NeuronNet> deleteList = new List<NeuronNet>();
            foreach (NeuronNet neuronNet in PopulationList)
            {
                if (!deleteList.Any(x => Math.Abs(x.Error - neuronNet.Error) < 0))
                {
                    foreach (NeuronNet deleteNet in PopulationList.FindAll(x => { return Math.Abs(x.Error - neuronNet.Error) < 0.0001; }))
                    {
                        deleteList.Add(deleteNet);
                    }
                    deleteList.Remove(neuronNet);
                }
            }
            foreach (NeuronNet neuronNet in deleteList)
            {
                PopulationList.Remove(neuronNet);
            }
        }

        private void Mutation(double mutationProbability, double mutationRate)
        {
            foreach (NeuronNet neuronNet in PopulationList)
            {
                if (Rnd.NextDouble() < mutationProbability)
                {
                    foreach (NeuronLayer layer in neuronNet.Layers)
                    {
                        foreach (Neuron neuron in layer.Neurons)
                        {
                            foreach (Dendrite dendrite in neuron.Dendrites)
                            {
                                if (Rnd.NextDouble() > 0.5d)
                                {
                                    dendrite.Weight = dendrite.Weight*(1 + mutationRate);
                                }
                                else
                                {
                                    dendrite.Weight = dendrite.Weight * (1 - mutationRate);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void DieOfAge(int maxAge)
        {
            
            if (PopulationList.Exists(x => x.Age > maxAge))
            {
                PopulationList = PopulationList.OrderBy(x => x.Age).ToList();
                NeuronNet firstOld = PopulationList.First(x => x.Age > maxAge);
                int index = PopulationList.IndexOf(firstOld);
                PopulationList.RemoveRange(index, PopulationList.Count - index);
                PopulationList = PopulationList.OrderBy(x => x.Error).ToList();
            }
            
        }

        private void PrintBestIndividualError(int iteration)
        {
            double error = PopulationList.First().Error;
            Console.WriteLine(error + " iteration N°: " + iteration);
        }

        private void CrossPopulation()
        {
            for (int i = 0; i < PopulationList.Count-2; i = i + 2)
            {
                //FastCrossIndividuals(PopulationList[i], PopulationList[i + 1]);
                //NearGenesCrossNoOffspring(PopulationList[i], PopulationList[i + 1]);
                NearGenesCrossWithOffspring(PopulationList[i], PopulationList[i + 1]);
            }
        }

        private void NearGenesCrossWithOffspring(NeuronNet individualA, NeuronNet individualB)
        {
            NeuronNet offspring = new NeuronNet(Shape,Rnd);
            double extraRange = 0.1;
            offspring.SetInputLayer(InputExample);
            if (individualA.Layers.Count != individualB.Layers.Count) throw new Exception("Different layer size. Can not cross");
            for (int i = 0; i < individualA.Layers.Count; i++)
            {
                if (individualA.Layers[i].Neurons.Count != individualB.Layers[i].Neurons.Count) throw new Exception("Different neuron size. Can not cross");
                for (int j = 0; j < individualA.Layers[i].Neurons.Count; j++)
                {
                    double auxBiasA = individualA.Layers[i].Neurons[j].Bias;
                    double auxBiasB = individualB.Layers[i].Neurons[j].Bias;
                    double maximumBias;
                    double minimumBias;

                    if (auxBiasA > auxBiasB)
                    {
                        maximumBias = auxBiasA + (auxBiasA * extraRange);
                        minimumBias = auxBiasB - (auxBiasA * extraRange);
        }
                    else
                    {
                        maximumBias = auxBiasB + (auxBiasA * extraRange);
                        minimumBias = auxBiasA - (auxBiasA * extraRange);
                    }

                    offspring.Layers[i].Neurons[j].Bias = Rnd.NextDouble() * (maximumBias - minimumBias) + minimumBias;

                    if (individualA.Layers[i].Neurons[j].Dendrites.Count != individualB.Layers[i].Neurons[j].Dendrites.Count) throw new Exception("Different dendrite count. Can not cross");
                    for (int k = 0; k < individualA.Layers[i].Neurons[j].Dendrites.Count; k++)
                    {
                        double auxDendriteWeightA = individualA.Layers[i].Neurons[j].Dendrites[k].Weight;
                        double auxDendriteWeightB = individualB.Layers[i].Neurons[j].Dendrites[k].Weight;
                        double maximum;
                        double minimum;

                        if (auxDendriteWeightA > auxDendriteWeightB)
                        {
                            maximum = auxDendriteWeightA + (auxDendriteWeightA * extraRange);
                            minimum = auxDendriteWeightB - (auxDendriteWeightA * extraRange);
                        }
                        else
                        {
                            maximum = auxDendriteWeightB + (auxDendriteWeightA * extraRange);
                            minimum = auxDendriteWeightA - (auxDendriteWeightA * extraRange);
                        }
                        offspring.Layers[i].Neurons[j].Dendrites[k].Weight = Rnd.NextDouble() * (maximum - minimum) + minimum;
                    }
                }
            }
            PopulationList.Add(offspring);
        }

        private void NearGenesCrossNoOffspring(NeuronNet individualA, NeuronNet individualB)
        {
            if (individualA.Layers.Count != individualB.Layers.Count) throw new Exception("Different layer size. Can not cross");
            for (int i = 0; i < individualA.Layers.Count; i++)
            {
                if (individualA.Layers[i].Neurons.Count != individualB.Layers[i].Neurons.Count) throw new Exception("Different neuron size. Can not cross");
                for (int j = 0; j < individualA.Layers[i].Neurons.Count; j++)
                {
                    if (individualA.Layers[i].Neurons[j].Dendrites.Count != individualB.Layers[i].Neurons[j].Dendrites.Count) throw new Exception("Different dendrite count. Can not cross");
                    for (int k = 0; k < individualA.Layers[i].Neurons[j].Dendrites.Count; k++)
                    {
                        double auxDendriteWeightA = individualA.Layers[i].Neurons[j].Dendrites[k].Weight;
                        double auxDendriteWeightB = individualB.Layers[i].Neurons[j].Dendrites[k].Weight;
                        double maximum;
                        double minimum;

                        if (auxDendriteWeightA > auxDendriteWeightB)
                        {
                            maximum = auxDendriteWeightA;
                            minimum = auxDendriteWeightB;
                        }
                        else
                        {
                            maximum = auxDendriteWeightB;
                            minimum = auxDendriteWeightA;
                        }
                        individualA.Layers[i].Neurons[j].Dendrites[k].Weight = Rnd.NextDouble() * (maximum - minimum) + minimum;
                        individualB.Layers[i].Neurons[j].Dendrites[k].Weight = Rnd.NextDouble() * (maximum - minimum) + minimum;
                    }
                }
            }
        }

        private void FastCrossIndividuals(NeuronNet individualA, NeuronNet individualB)
        {
            if(individualA.Layers.Count != individualB.Layers.Count) throw new Exception("Different layer size. Can not cross");
            for (int i = 0; i < individualA.Layers.Count; i++)
            {
                if(individualA.Layers[i].Neurons.Count != individualB.Layers[i].Neurons.Count) throw new Exception("Different neuron size. Can not cross");
                for (int j = 0; j < individualA.Layers[i].Neurons.Count; j++)
                {
                    if(individualA.Layers[i].Neurons[j].Dendrites.Count != individualB.Layers[i].Neurons[j].Dendrites.Count) throw new Exception("Different dendrite count. Can not cross");
                    for (int k = 0; k < individualA.Layers[i].Neurons[j].Dendrites.Count; k++)
                    {
                        double auxDendriteWeightA = individualA.Layers[i].Neurons[j].Dendrites[k].Weight;
                        double auxDendriteWeightB = individualB.Layers[i].Neurons[j].Dendrites[k].Weight;
                        individualA.Layers[i].Neurons[j].Dendrites[k].Weight = auxDendriteWeightB;
                        individualB.Layers[i].Neurons[j].Dendrites[k].Weight = auxDendriteWeightA;
                    }
                }
            }
        }

        private void SurvivalOfTheFitest(double fatality, int populationSize, int maxAge)
        {
            if (PopulationList.Count > populationSize)
            {
                PopulationList.RemoveRange(populationSize, PopulationList.Count - populationSize);
            }
            int casualityNumber = (int) Math.Round(PopulationList.Count*fatality);
            for (int i = PopulationList.Count - 1; i >= PopulationList.Count - casualityNumber; i--)
            {
                PopulationList[i].RandomizeWeights(MinWeightValue,MaxWeightValue);
            }
        }

        private void SortPopulation()
        {
            PopulationList = PopulationList.OrderBy(x => x.Error).ToList();
        }

        private void EvaluatePopulation()
        {
            foreach (NeuronNet neuronNet in PopulationList)
            {
                double oldError = neuronNet.Error;
                double newError = neuronNet.GetError(_inputTrainSet, _outputTarget);
                if (newError >= oldError)
                {
                    neuronNet.Age++;
                }
                else
                {
                    neuronNet.Age = 0;
                }
                
            }
        }
    }
}
