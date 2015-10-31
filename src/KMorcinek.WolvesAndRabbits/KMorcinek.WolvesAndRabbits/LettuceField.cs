using System;
using System.Collections.Generic;
using System.Linq;
using KMorcinek.WolvesAndRabbits.Configuration;
using KMorcinek.WolvesAndRabbits.Utils;

namespace KMorcinek.WolvesAndRabbits
{
    public class LettuceField
    {
        private readonly IRandom random;
        private readonly LettuceFieldConfiguration configuration;

        public LettuceField(IRandom random, LettuceFieldConfiguration configuration)
        {
            this.random = random;
            this.configuration = configuration;
        }

        public IEnumerable<Lettuce> Create(int size)
        {
            int length = (2 * size) + 1;
            int range = ((length * length) - 1) / 2;
            for (int i = -range; i < range + 1; i++)
            {
                yield return new Lettuce(i, configuration.StartingFood);
            }
        }

        public IEnumerable<Lettuce> NextTurn(IEnumerable<Lettuce> lettuces)
        {
            return lettuces.Select(Grow);
        }

        private Lettuce Grow(Lettuce lettuce)
        {
            double nextFoodSize = Math.Min(lettuce.Food + configuration.FoodGrowingEachTurn + random.NextDouble(), configuration.MaximumFood);
            return new Lettuce(lettuce.Position, nextFoodSize);
        }
    }
}