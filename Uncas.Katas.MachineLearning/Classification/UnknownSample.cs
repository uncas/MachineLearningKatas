using System.Collections.Generic;

namespace Uncas.Katas.MachineLearning.Classification
{
    public class UnknownSample : Sample
    {
        public UnknownSample(IEnumerable<Feature> features) : base(features)
        {
        }
    }
}