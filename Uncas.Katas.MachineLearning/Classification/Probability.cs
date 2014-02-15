namespace Uncas.Katas.MachineLearning.Classification
{
    public struct Probability
    {
        public Probability(double probability) : this()
        {
            Value = probability;
        }

        public double Value { get; private set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}