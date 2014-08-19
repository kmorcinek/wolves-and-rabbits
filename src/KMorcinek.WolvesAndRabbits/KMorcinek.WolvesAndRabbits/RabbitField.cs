using System;
using System.Collections.Generic;
using System.Linq;
using KMorcinek.WolvesAndRabbits.Configuration;

namespace KMorcinek.WolvesAndRabbits
{
    public class RabbitField : FieldBase<Lettuce, Rabbit>
    {
        private readonly RabbitFieldConfiguration configuration;

        public RabbitField(RabbitFieldConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }

        public override Tuple<IEnumerable<Lettuce>, Rabbit> PredatorMovesAndEatsOnlyBestPrey(IEnumerable<Lettuce> g, Rabbit rabbit)
        {
            var lettuces = g.ToArray();
            
            Lettuce bestLettuce;
            TryChooseBestPrey(lettuces, rabbit, out bestLettuce);

            double eatenFood = Math.Min(configuration.MaximumFoodEatenFromLettuce, bestLettuce.Food);
            bestLettuce = new Lettuce(bestLettuce.Position, bestLettuce.Food - eatenFood);
            
            var tuple = new Tuple<IEnumerable<Lettuce>, Rabbit>(
                lettuces.Where(p => p.Position != bestLettuce.Position).Concat(new []{bestLettuce}),
                new Rabbit(bestLettuce.Position, rabbit.Food + eatenFood));

            return tuple;
        }
    }
}