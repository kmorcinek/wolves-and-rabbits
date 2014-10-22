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
    }
}