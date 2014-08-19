using System;
using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.WolvesAndRabbits
{
    public class RabbitField
    {
        public Tuple<IEnumerable<Lettuce>, Rabbit> RabbitMovesAndEatsOnlyBestLettuce(IEnumerable<Lettuce> g, Rabbit rabbit)
        {
            var lettuces = g.ToArray();
            var bestLettuce = ChooseBestLettuce(lettuces, rabbit);
            double eatenFood = Math.Min(7, bestLettuce.Food);
            bestLettuce = new Lettuce(bestLettuce.Position, bestLettuce.Food - eatenFood);
            
            var tuple = new Tuple<IEnumerable<Lettuce>, Rabbit>(
                lettuces.Where(p => p.Position != bestLettuce.Position).Concat(new []{bestLettuce}),
                new Rabbit(bestLettuce.Position, rabbit.Food + eatenFood / 7 * 5));

            return tuple;
        }

        public Lettuce ChooseBestLettuce(IEnumerable<Lettuce> lettuces, Rabbit rabbit)
        {
            NeighborhoodGenerator neighborhoodGenerator = new NeighborhoodGenerator();
            IEnumerable<Position> positions = neighborhoodGenerator.Generate(rabbit.Position);

            IEnumerable<Lettuce> neighborhood = lettuces.Where(p => positions.Contains(p.Position)).ToList();

            Lettuce bestLettuce = neighborhood.First();
            double bestLevel = bestLettuce.Food;

            foreach (var lettuce in neighborhood)
            {
                if (lettuce.Food > bestLevel)
                {
                    bestLettuce = lettuce;
                    bestLevel = lettuce.Food;
                }
            }

            return bestLettuce;
        }

        public Tuple<IEnumerable<Lettuce>, IEnumerable<Rabbit>> GetNextTurn(IEnumerable<Lettuce> lettuces, IEnumerable<Rabbit> rabbits)
        {
            List<Rabbit> nextRabbits = new List<Rabbit>();

            foreach (var rabbit in rabbits)
            {
                var lettucesAndRabbit = RabbitMovesAndEatsOnlyBestLettuce(lettuces, rabbit);
                lettuces = lettucesAndRabbit.Item1;
                nextRabbits.Add(lettucesAndRabbit.Item2);
            }

            return new Tuple<IEnumerable<Lettuce>, IEnumerable<Rabbit>>(
                lettuces,
                GetLivingRabbits(nextRabbits)
                );
        }

        private static IEnumerable<Rabbit> GetLivingRabbits(IEnumerable<Rabbit> nextRabbits)
        {
            return nextRabbits.Where(p => p.Food > 5);
        }
    }
}