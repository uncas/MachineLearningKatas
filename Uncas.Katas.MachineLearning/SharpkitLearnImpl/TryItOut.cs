using System;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Generic;
using NUnit.Framework;
using Sharpkit.Learn.LinearModel;

namespace Uncas.Katas.MachineLearning.SharpkitLearnImpl
{
    [TestFixture]
    public class TryItOut
    {
        private static LogisticRegression<bool> GetLogisticRegression(double[,] samples,
            bool[] knownOutput)
        {
            var clf = new LogisticRegression<bool>();
            clf.Fit(DenseMatrix.OfArray(samples), knownOutput);
            return clf;
        }

        [Test]
        public void LogisticRegression_Ok()
        {
            double[,] samples = {{1.0, 0.0}, {10.0, 1.0}, {1.0, 3.0}, {3.0, 5.0}};
            bool[] knownOutput = {false, false, true, true};
            LogisticRegression<bool> clf = GetLogisticRegression(samples, knownOutput);
            Console.WriteLine(clf.Coef);
            Console.WriteLine(clf.Intercept);
            for (int age = 1; age < 30; age += 2)
                for (int words = 0; words < 10; words += 2)
                {
                    double[] sample = {age, words};
                    bool prediction = clf.Predict(sample);
                    Console.WriteLine("{0} days, {1} words, {2}", age, words,
                        prediction);

                    double[,] localSample = {{age, words}};
                    Matrix<double> proba =
                        clf.PredictProba(DenseMatrix.OfArray(localSample));
                    foreach (double prob in proba.ToArray())
                    {
                        Console.WriteLine("Prob {0}", prob);
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                }
        }
    }
}