using numl.Model;

namespace Uncas.Katas.MachineLearning.NumlImpl.Models
{
    public class Tennis
    {
        [Feature]
        public Outlook Outlook { get; set; }

        [Feature]
        public int Temperature { get; set; }

        [Feature]
        public bool Windy { get; set; }

        [Label]
        public double Play { get; set; }

        public static Tennis[] GetData()
        {
            return new[]
            {
                new Tennis
                {
                    Play = 1d,
                    Outlook = Outlook.Sunny,
                    Temperature = 5,
                    Windy = true
                },
                new Tennis
                {
                    Play = 0d,
                    Outlook = Outlook.Sunny,
                    Temperature = 30,
                    Windy = true
                },
                new Tennis
                {
                    Play = 0d,
                    Outlook = Outlook.Sunny,
                    Temperature = 35,
                    Windy = false
                },
                new Tennis
                {
                    Play = 1d,
                    Outlook = Outlook.Overcast,
                    Temperature = 10,
                    Windy = true
                },
                new Tennis
                {
                    Play = 1d,
                    Outlook = Outlook.Overcast,
                    Temperature = 25,
                    Windy = false
                },
                new Tennis
                {
                    Play = 1d,
                    Outlook = Outlook.Overcast,
                    Temperature = 10,
                    Windy = false
                },
                new Tennis
                {
                    Play = 0d,
                    Outlook = Outlook.Rainy,
                    Temperature = 2,
                    Windy = true
                },
                new Tennis
                {
                    Play = 1d,
                    Outlook = Outlook.Rainy,
                    Temperature = 14,
                    Windy = false
                },
                new Tennis
                {
                    Play = 0d,
                    Outlook = Outlook.Rainy,
                    Temperature = 8,
                    Windy = true
                },
                new Tennis
                {
                    Play = 1d,
                    Outlook = Outlook.Rainy,
                    Temperature = 18,
                    Windy = true
                },
                new Tennis
                {
                    Play = 0d,
                    Outlook = Outlook.Rainy,
                    Temperature = 19,
                    Windy = true
                },
                new Tennis
                {
                    Play = 1d,
                    Outlook = Outlook.Rainy,
                    Temperature = 14,
                    Windy = false
                },
                new Tennis
                {
                    Play = 1d,
                    Outlook = Outlook.Rainy,
                    Temperature = 14,
                    Windy = false
                }
            };
        }
    }
}