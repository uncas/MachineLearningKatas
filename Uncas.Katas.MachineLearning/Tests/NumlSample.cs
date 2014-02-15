using System;
using numl;
using numl.Model;
using numl.Supervised.DecisionTree;
using NUnit.Framework;
using Uncas.Katas.MachineLearning.NumlImpl.Models;

namespace Uncas.Katas.MachineLearning.Tests
{
    [TestFixture]
    public class NumlSample
    {
        [Test]
        public void Predict()
        {
            Tennis[] data = Tennis.GetData();
            Descriptor descriptor = Descriptor.Create<Tennis>();
            var generator = new DecisionTreeGenerator(descriptor);
            generator.SetHint(0.5d);
            LearningModel model = Learner.Learn(data, 0.8, 1000, generator);
            var input = new Tennis
            {
                Outlook = Outlook.Overcast,
                Temperature = 20,
                Windy = false
            };
            Tennis predict = model.Model.Predict(input);
            Console.WriteLine(predict.Play);
            Console.WriteLine(model);
        }
    }
}