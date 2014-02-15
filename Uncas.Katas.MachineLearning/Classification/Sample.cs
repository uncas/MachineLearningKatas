using System.Collections.Generic;

namespace Uncas.Katas.MachineLearning.Classification
{
    public abstract class Sample
    {
        protected Sample(IEnumerable<Feature> features)
        {
            Features = features;
        }

        public IEnumerable<Feature> Features { get; private set; }
    }
}