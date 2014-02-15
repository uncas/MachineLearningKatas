using System.Linq;
using Accord.Statistics.Links;
using Accord.Statistics.Models.Regression;
using Accord.Statistics.Models.Regression.Fitting;
using Uncas.Katas.MachineLearning.Classification;

namespace Uncas.Katas.MachineLearning.AccordImpl
{
    /// <summary>
    ///     http://accord.googlecode.com/svn/docs/html/T_Accord_Statistics_Models_Regression_LogisticRegression.htm
    ///     (http://crsouza.blogspot.dk/2010/02/logistic-regression-in-c.html)
    ///     (http://www.clear-lines.com/blog/post/First-Steps-With-Accord-NET-SVM-in-FSharp.aspx)
    /// </summary>
    public class AccordBinaryClassifier : IBinaryClassifier
    {
        public Probability Classify(KnownFacts known, UnknownSample unknown)
        {
            double probability = GetTaughtRegression(known).Compute(GetInput(unknown));
            return new Probability(probability);
        }

        public double[] Teach(KnownFacts known)
        {
            return GetTaughtRegression(known).Coefficients;
        }

        public Probability Classify(double[] coefficients, UnknownSample unknown)
        {
            double probability = Compute(coefficients, GetInput(unknown));
            return new Probability(probability);
        }

        private LogisticRegression GetTaughtRegression(KnownFacts known)
        {
            double[][] inputs = known.Samples.Select(GetInput).ToArray();
            double[] outputs = known.Samples.Select(GetOutput).ToArray();
            var regression = new LogisticRegression(inputs.Length);
            Teach(regression, inputs, outputs);
            return regression;
        }

        /// <remarks>
        ///     Reverse engineered from GeneralizedLinearRegression.Compute.
        /// </remarks>
        private static double Compute(double[] coefficients, double[] input)
        {
            double x = coefficients[0];
            for (int index = 1; index < coefficients.Length; ++index)
                x += input[index - 1]*coefficients[index];
            return new LogitLinkFunction().Inverse(x);
        }

        private double[] GetInput(Sample sample)
        {
            return sample.Features.Select(x => x.Value).ToArray();
        }

        private static double GetOutput(KnownSample sample)
        {
            return sample.IsPositive ? 1d : 0d;
        }

        private static void Teach(
            LogisticRegression regression,
            double[][] inputs,
            double[] outputs)
        {
            var teacher = new IterativeReweightedLeastSquares(regression);
            const int max = 10;
            int i = 0;
            double delta;
            do
            {
                delta = teacher.Run(inputs, outputs);
                i++;
            } while (delta > 0.001 && i < max);
        }
    }
}