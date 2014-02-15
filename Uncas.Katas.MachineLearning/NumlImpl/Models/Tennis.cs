using numl.Model;

namespace Uncas.Katas.MachineLearning.NumlImpl.Models
{
    public class Tennis
    {
        [Feature]
        public Outlook Outlook { get; set; }

        [Feature]
        public Temperature Temperature { get; set; }

        [Feature]
        public bool Windy { get; set; }

        [Label]
        public bool Play { get; set; }

        public static Tennis[] GetData()
        {
            return new[]
            {
                new Tennis
                {
                    Play = true,
                    Outlook = Outlook.Sunny,
                    Temperature = Temperature.Low,
                    Windy = true
                },
                new Tennis
                {
                    Play = false,
                    Outlook = Outlook.Sunny,
                    Temperature = Temperature.High,
                    Windy = true
                },
                new Tennis
                {
                    Play = false,
                    Outlook = Outlook.Sunny,
                    Temperature = Temperature.High,
                    Windy = false
                },
                new Tennis
                {
                    Play = true,
                    Outlook = Outlook.Overcast,
                    Temperature = Temperature.Low,
                    Windy = true
                },
                new Tennis
                {
                    Play = true,
                    Outlook = Outlook.Overcast,
                    Temperature = Temperature.High,
                    Windy = false
                },
                new Tennis
                {
                    Play = true,
                    Outlook = Outlook.Overcast,
                    Temperature = Temperature.Low,
                    Windy = false
                },
                new Tennis
                {
                    Play = false,
                    Outlook = Outlook.Rainy,
                    Temperature = Temperature.Low,
                    Windy = true
                },
                new Tennis
                {
                    Play = true,
                    Outlook = Outlook.Rainy,
                    Temperature = Temperature.Low,
                    Windy = false
                }
            };
        }
    }
}