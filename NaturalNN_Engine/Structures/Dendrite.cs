namespace NaturalNN_Engine.Structures
{
    public class Dendrite
    {
        public double Weight { get; set; }
        public Neuron OriginNeuron { get; set; }
        public int ModCounter { get; set; } = 0;

        public Dendrite() { }

        public Dendrite(Neuron originNeuron, double weight)
        {
            OriginNeuron = originNeuron;
            Weight = weight;
        }
    }
}
