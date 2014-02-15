using System;
using System.Collections.Generic;
using NUnit.Framework;
using Uncas.Katas.MachineLearning.AccordImpl;
using Uncas.Katas.MachineLearning.Classification;

namespace Uncas.Katas.MachineLearning.Tests
{
    [TestFixture]
    public class BinaryClassifierTests
    {
        private readonly IBinaryClassifier _binaryClassifier;

        public BinaryClassifierTests()
        {
            _binaryClassifier = new AccordBinaryClassifier();
        }

        private static IEnumerable<Feature> GetFeatures(
            int profileAgeInMinutes,
            int numberOfBadWordsInText)
        {
            yield return new Feature
            {
                Name = "ProfileAgeInMinutes",
                Value = profileAgeInMinutes
            };
            yield return new Feature
            {
                Name = "NumberOfBadWordsInText",
                Value = numberOfBadWordsInText
            };
        }

        private static KnownFacts GetKnownFacts()
        {
            return new KnownFacts
            {
                Samples = new[]
                {
                    new KnownSample(GetFeatures(10, 1), false),
                    //new KnownSample(GetFeatures(20, 1), false),
                    //new KnownSample(GetFeatures(30, 1), false),
                    new KnownSample(GetFeatures(3, 7), true)
                }
            };
        }

        [Test]
        public void Classify_NegativeFeatures_LessThanFiftyPercent()
        {
            var unknown = new UnknownSample(GetFeatures(150000, 1));
            Probability result = _binaryClassifier.Classify(GetKnownFacts(), unknown);

            Assert.That(result.Value, Is.LessThan(0.5d));
        }

        [Test]
        public void Classify_PositiveFeatures_GreaterThanFiftyPercent()
        {
            var unknown = new UnknownSample(GetFeatures(3, 7));

            Probability result = _binaryClassifier.Classify(GetKnownFacts(), unknown);

            Assert.That(result.Value, Is.GreaterThan(0.5d));
        }

        [Test]
        public void Classify_PrintResults()
        {
            for (int age = 1; age < 100; age++)
            {
                for (int words = 0; words < 10; words++)
                {
                    var unknown = new UnknownSample(GetFeatures(age, words));
                    Probability result = _binaryClassifier.Classify(GetKnownFacts(),
                        unknown);
                    Console.WriteLine(
                        "Age {0}, Words {1}, Probability {2}",
                        age,
                        words,
                        result);
                }
            }
        }

        [Test]
        public void Classify_TeachAndClassify_Compare()
        {
            var unknown = new UnknownSample(GetFeatures(3, 0));

            double[] learning = _binaryClassifier.Teach(GetKnownFacts());
            Probability indirect = _binaryClassifier.Classify(learning, unknown);
            Probability direct = _binaryClassifier.Classify(GetKnownFacts(), unknown);

            Assert.That(indirect, Is.EqualTo(direct));
        }

        [Test]
        public void TeachAndClassify()
        {
            var unknown = new UnknownSample(GetFeatures(3, 7));

            double[] learning = _binaryClassifier.Teach(GetKnownFacts());
            Probability result = _binaryClassifier.Classify(learning, unknown);

            Assert.That(result.Value, Is.GreaterThan(0.5d));
        }
    }
}