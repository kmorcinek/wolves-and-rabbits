using System;
using System.Linq;
using KMorcinek.WolvesAndRabbits.Configuration;
using Microsoft.FSharp.Collections;

namespace KMorcinek.WolvesAndRabbits.Web
{
    class FsharpWolvesAdapter : IWolvesAdapter
    {
        private static Tuple<FSharpList<Types.Rabbit>, FSharpList<Types.Rabbit>, FSharpList<Types.Rabbit>> fields;

        public dynamic GetNextTurn()
        {
            fields = global::Rabbit.GetNextTurn(fields.Item1, fields.Item2, fields.Item3);

            return new FieldsToTableTranslater().GetData(Translate(fields));
        }

        public dynamic Reset(FullConfiguration configuration)
        {
            fields = Runner.Create;

            return new FieldsToTableTranslater().GetData(Translate(fields));
        }

        private static Fields Translate(Tuple<FSharpList<Types.Rabbit>, FSharpList<Types.Rabbit>, FSharpList<Types.Rabbit>> tuple)
        {
            Fields fields1 = new Fields
            {
                IterationCount = 121,
                Size = 10,
                Lettuces = tuple.Item1.ToArray().Select(ToLettuce),
                Rabbits = tuple.Item2.ToArray().Select(ToRabbit),
                Wolves = tuple.Item3.ToArray().Select(ToWolf),
            };

            return fields1;
        }

        private static Rabbit ToRabbit(Types.Rabbit rabbit)
        {
            return new Rabbit(rabbit.Position, rabbit.Food);
        }

        private static Lettuce ToLettuce(Types.Rabbit rabbit)
        {
            return new Lettuce(rabbit.Position, rabbit.Food);
        }

        private static Wolf ToWolf(Types.Rabbit rabbit)
        {
            return new Wolf(rabbit.Position, rabbit.Food);
        }
    }
}