using System;
using System.Collections.Generic;
using System.Globalization;
using NaturalNN_Engine.Structures;

namespace NaturalNN_Controller.Heuristics
{
    class NaturalDescent
    {
        private NeuronNet _network;
        private readonly Random Rnd = new Random();
        private double weightVariationRate = 0.0001d;

        public NaturalDescent(NeuronNet network)
        {
            _network = network;
        }

        public void TrainNatural(List<double[]> inputTrainSet, List<double[]> outputTarget, int iterationsNumber)
        {
            
            for (int i = 0; i < iterationsNumber; i++)
            {
                _network.ForwardPropagate();
                if (i % 10000 == 0)
                {
                    Console.WriteLine(_network.GetError(inputTrainSet, outputTarget).ToString(CultureInfo.InvariantCulture));
                }
                Dendrite dendrite = _network.GetRandomLayer().GetRandomNeuron().GetRandomDendrite();
                double saveDendriteWeight = dendrite.Weight;  //save dendrite weight
                if (outputTarget[1].Length == _network.GetLastLayer().Neurons.Count) //outputTarget lengh must be the same number as the number of neurons in the last layer
                {
                    TryMoreLess(inputTrainSet, outputTarget, dendrite, saveDendriteWeight);
                }
            }
            _network.ForwardPropagate();
            Console.WriteLine(_network.GetError(inputTrainSet, outputTarget).ToString(CultureInfo.InvariantCulture));

        }

        private void TryMoreLess(List<double[]> inputTrainSet, List<double[]> outputTarget, Dendrite dendrite, double saveDendriteWeight)
        {
            double networkError = _network.GetError(inputTrainSet, outputTarget);
            //try more
            dendrite.Weight = saveDendriteWeight + weightVariationRate;
            _network.ForwardPropagate();
            double tryMoreNetworkError = _network.GetError(inputTrainSet, outputTarget);

            //try less
            dendrite.Weight = saveDendriteWeight - weightVariationRate;
            _network.ForwardPropagate();
            double tryLessNetworkError = _network.GetError(inputTrainSet, outputTarget);

            if (tryLessNetworkError < tryMoreNetworkError) //Less is better
            {
                if (tryLessNetworkError < networkError) //Improve!
                {
                    dendrite.Weight = saveDendriteWeight - weightVariationRate;
                    //weightVariationRate = weightVariationRate * 0.9;
                }
                else //Fuck this shit!
                {
                    dendrite.Weight = saveDendriteWeight;
                    //weightVariationRate = weightVariationRate*1.1;
                }
            }
            else //More is better
            {
                if (tryMoreNetworkError < networkError) //Improve!
                {
                    dendrite.Weight = saveDendriteWeight + weightVariationRate;
                    //weightVariationRate = weightVariationRate * 0.9;
                }
                else //Fuck this shit!
                {
                    dendrite.Weight = saveDendriteWeight;
                    //weightVariationRate = weightVariationRate * 1.1;
                }
            }
        }
    }
}
