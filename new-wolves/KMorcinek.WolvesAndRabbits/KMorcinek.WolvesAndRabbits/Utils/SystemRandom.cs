using System;

namespace KMorcinek.WolvesAndRabbits.Utils
{
    public class SystemRandom : IRandom
    {
        private readonly Random random = new Random();

        public double NextDouble()
        {
            return random.NextDouble();
        }

        public int Next(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }
    }
}