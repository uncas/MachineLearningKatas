using System.Collections.Generic;

namespace Uncas.Katas.MachineLearning.Classification
{
    public class KnownSample : Sample
    {
        public KnownSample(IEnumerable<Feature> features, bool isPositive)
            : base(features)
        {
            IsPositive = isPositive;
        }

        public bool IsPositive { get; private set; }
    }
}