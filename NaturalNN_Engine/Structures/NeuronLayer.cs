using System;
using System.Collections.Generic;

namespace NaturalNN_Engine.Structures
{
    public class NeuronLayer
    {
        public List<Neuron> Neurons { get; set; } = new List<Neuron>();
        public NeuronLayer LeftLayer { get; set; }
        public NeuronLayer RigtLayer { get; set; }
        private readonly Random _rnd;

        public NeuronLayer(int layerSize, Random rnd)
        {
            _rnd = rnd;
            for (int i = 0; i < layerSize; i++)
            {
                Neurons.Add(new Neuron(_rnd));
            }
        }

        public void ConnectoToLeft()
        {
            foreach (Neuron neuron in Neurons)
            {
                foreach (Neuron leftNeuron in LeftLayer.Neurons)
                {
                    neuron.ConnectoToNeuron(leftNeuron);
                }
            }
        }

        public void AddNeuron()
        {
            Neurons.Add(new Neuron(_rnd));
        }

        public void ProcessOutput()
        {
            foreach (Neuron neuron in Neurons)
            {
                if(RigtLayer == null) //if this is the last layer, use the raw output
                {
                    neuron.ProcessOutputRaw();
                }
                else
                {
                    neuron.ProcessOutput();
                }
                
            }
        }

        public Neuron GetRandomNeuron()
        {
            return Neurons[_rnd.Next(Neurons.Count)];
        }
    }
}
