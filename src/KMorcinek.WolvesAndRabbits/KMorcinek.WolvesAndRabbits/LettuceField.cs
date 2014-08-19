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
            for (int i = -size; i < size + 1; i++)
            {
                for (int j = -size; j < size + 1; j++)
                {
                    yield return new Lettuce(new Position(i, j), configuration.StartingFood);
                }
            }
        }

        public IEnumerable<Lettuce> NextTurn(IEnumerable<Lettuce> lettuces)
        {
            return lettuces.Select(Grow);
        }

        Lettuce Grow(Lettuce lettuce)
        {
            double nextFoodSize = Math.Min(lettuce.Food + configuration.FoodGrowingEachTurn + random.NextDouble(), configuration.MaximumFood);
            return new Lettuce(lettuce.Position, nextFoodSize);
        }
    }
}