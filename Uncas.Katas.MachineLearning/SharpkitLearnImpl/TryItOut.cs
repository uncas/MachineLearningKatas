using System;
using NUnit.Framework;
using Sharpkit.Learn.LinearModel;

namespace Uncas.Katas.MachineLearning.SharpkitLearnImpl
{
    [TestFixture]
    public class TryItOut
    {
        [Test]
        public void RidgeClassifier_Ok()
        {
            var clf = new RidgeClassifier<string>(0.5);
            double[,] samples = {{1.0, 3.0}, {3.0, 5.0}, {1.0, 0.0}, {10.0, 1.0}};
            const string nonFraud = "non-fraud";
            const string fraud = "fraud";
            string[] knownOutput = {fraud, fraud, nonFraud, nonFraud};
            clf.Fit(samples, knownOutput);
            Console.WriteLine(clf.Coef);
            Console.WriteLine(clf.Intercept);

            for (int age = 1; age < 30; age++)
                for (int words = 0; words < 10; words++)
                {
                    string prediction = clf.Predict(new double[] {age, words});
                    Console.WriteLine("{0} days, {1} words, {2}", age, words, prediction);
                }
        }

        [Test]
        public void X()
        {
            //var regression = new LogisticRegression<string>();
            //regression.Fit();
            //regression.PredictProba()
        }
    }
}