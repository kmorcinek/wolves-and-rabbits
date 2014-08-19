using System;
using System.Collections.Generic;
using System.Linq;
using KMorcinek.WolvesAndRabbits.Configuration;

namespace KMorcinek.WolvesAndRabbits
{
    public class WolfField : FieldBase<Rabbit, Wolf>
    {
        public WolfField(WolfFieldConfiguration configuration)
            : base(configuration)
        {

        }

        public override Tuple<IEnumerable<Rabbit>, Wolf> PredatorMovesAndEatsOnlyBestPrey(IEnumerable<Rabbit> g, Wolf wolf)
        {
            var rabbits = g.ToArray();
            Rabbit bestRabbit;

            Wolf wolfNextTurn;
            if (TryChooseBestPrey(rabbits, wolf, out bestRabbit))
            {
                rabbits = rabbits.Where(p => p.Position != bestRabbit.Position).ToArray();
                wolfNextTurn = new Wolf(bestRabbit.Position, wolf.Food + bestRabbit.Food);
            }
            else
            {
                wolfNextTurn = new Wolf(wolf.Position, wolf.Food);
            }

            var tuple = new Tuple<IEnumerable<Rabbit>, Wolf>(
                rabbits,
                wolfNextTurn);

            return tuple;
        }
    }
}