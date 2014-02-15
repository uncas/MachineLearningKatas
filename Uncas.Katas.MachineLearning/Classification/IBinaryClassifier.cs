namespace Uncas.Katas.MachineLearning.Classification
{
    public interface IBinaryClassifier
    {
        Probability Classify(KnownFacts known, UnknownSample unknown);
        double[] Teach(KnownFacts known);
        Probability Classify(double[] coefficients, UnknownSample unknown);
    }
}