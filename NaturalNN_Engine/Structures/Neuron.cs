using System;
using System.Collections.Generic;
using System.Linq;

namespace NaturalNN_Engine.Structures
{
    public class Neuron
    {
        public List<Dendrite> Dendrites { get; set; } = new List<Dendrite>();
        public double PreActivationOutput { get; private set; }
        public double Output { get; set; }
        public double Bias { get; set; }
        private readonly Random _rnd;

        public Neuron(Random rnd)
        {
            _rnd = rnd;
            PreActivationOutput = 0d;
            Bias = 0;
        }

        public void ConnectoToNeuron(Neuron leftNeuron)
        {
            if (Dendrites.All(d => d.OriginNeuron != leftNeuron))
            {
                Dendrites.Add(new Dendrite(leftNeuron, 0.5d));
            }
            
        }

        public void ProcessOutput()
        {
            //Sigmoid();
            Rectifier();
        }

        public void ProcessOutputRaw()
        {
            foreach (Dendrite dendrite in Dendrites)
            {
                PreActivationOutput += dendrite.Weight * dendrite.OriginNeuron.Output;
            }
            Output = PreActivationOutput + Bias;
        }

        private void Sigmoid()
        {
            PreActivationOutput = 0;
            foreach (Dendrite dendrite in Dendrites)
            {
                PreActivationOutput += dendrite.Weight * dendrite.OriginNeuron.Output;
            }
            Output = 1.0d / (1.0d + Math.Exp(-PreActivationOutput + Bias));
        }

        private void Rectifier()
        {
            PreActivationOutput = 0;
            foreach (Dendrite dendrite in Dendrites)
            {
                PreActivationOutput += dendrite.Weight * dendrite.OriginNeuron.Output;
            }
            if (PreActivationOutput > 0)
            {
                Output = PreActivationOutput + Bias;
            }
            else
            {
                Output = 0;
            }
        }

        public Dendrite GetRandomDendrite()
        {
            return Dendrites[_rnd.Next(Dendrites.Count)];
        }
    }

}
