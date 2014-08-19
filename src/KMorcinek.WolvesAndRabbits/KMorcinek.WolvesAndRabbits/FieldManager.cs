using System;
using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.WolvesAndRabbits
{
    public class FieldManager
    {
        readonly LettuceField lettuceField;
        readonly RabbitField rabbitField;
        readonly WolfField wolfField;

        public FieldManager(LettuceField lettuceField, RabbitField rabbitField, WolfField wolfField)
        {
            this.lettuceField = lettuceField;
            this.wolfField = wolfField;
            this.rabbitField = rabbitField;
        }

        public Fields Create()
        {
            int size = 10;
            return new Fields
            {
                Size = size,
                IterationCount = 0,
                Lettuces = lettuceField.Create(size),
                Rabbits = new List<Rabbit>(new[]
                {
                    new Rabbit(new Position(0, 0), 10),
                    new Rabbit(new Position(0, 0), 10),
                    new Rabbit(new Position(0, 0), 10),
                    new Rabbit(new Position(0, 0), 10),
                    new Rabbit(new Position(0, 0), 10),
                    new Rabbit(new Position(0, 0), 9),
                    new Rabbit(new Position(-2, -3), 9),
                    new Rabbit(new Position(-1, -4), 9),
                    new Rabbit(new Position(-3, -5), 9),
                    new Rabbit(new Position(-4, -3), 9),
                    new Rabbit(new Position(-4, -3), 9),
                    new Rabbit(new Position(-4, -3), 9),
                    new Rabbit(new Position(-4, -3), 9),
                    new Rabbit(new Position(-4, -3), 9),
                    new Rabbit(new Position(-4, -3), 9),
                    new Rabbit(new Position(-4, -3), 9),
                    new Rabbit(new Position(-4, -3), 9),
                    new Rabbit(new Position(-3, -3), 9),
                    new Rabbit(new Position(3, -3), 9),
                    new Rabbit(new Position(5, -3), 9),
                    new Rabbit(new Position(3, -5), 9),
                    new Rabbit(new Position(3, -5), 9),
                    new Rabbit(new Position(3, -5), 9),
                    new Rabbit(new Position(3, -5), 9),
                    new Rabbit(new Position(3, -5), 9),
                    new Rabbit(new Position(3, -5), 9),
                    new Rabbit(new Position(3, -5), 9),
                    new Rabbit(new Position(3, -5), 9),
                    new Rabbit(new Position(3, -5), 9),
                    new Rabbit(new Position(-7, 7), 9),
                    new Rabbit(new Position(-7, 7), 9),
                    new Rabbit(new Position(-7, 7), 9),
                    new Rabbit(new Position(-7, 7), 9),
                    new Rabbit(new Position(-7, 7), 9),
                    new Rabbit(new Position(-7, 7), 9),
                    new Rabbit(new Position(-7, 7), 9),
                    new Rabbit(new Position(-7, 7), 9),
                    new Rabbit(new Position(-7, 7), 9),
                    new Rabbit(new Position(-7, 7), 9),
                    new Rabbit(new Position(-7, 7), 9),
                }),
                Wolves = new List<Wolf>(
                    //                    Enumerable.Empty<Wolf>()
                    new[]
                    {
                        new Wolf(new Position(-3, 2), 35), 
                        new Wolf(new Position(-3, -2), 35), 
                        new Wolf(new Position(0, -5), 35), 
                        new Wolf(new Position(0, 5), 35), 
                        new Wolf(new Position(7, 0), 35), 
                        new Wolf(new Position(-7, 0), 35), 
                        new Wolf(new Position(-7, 0), 35), 
                        new Wolf(new Position(8, 8), 35), 
                        new Wolf(new Position(-8, 8), 35), 
                    }
                )
            };
        }

        public Fields GetNextTurn(Fields fieldManager)
        {
            IEnumerable<Lettuce> nextTurnLettuces = lettuceField.NextTurn(fieldManager.Lettuces);
            Tuple<IEnumerable<Lettuce>, IEnumerable<Rabbit>> rabbitsNextTurn =
                rabbitField.GetNextTurn(nextTurnLettuces, fieldManager.Rabbits);

            Tuple<IEnumerable<Rabbit>, IEnumerable<Wolf>> wolvesNextTurn =
                wolfField.GetNextTurn(rabbitsNextTurn.Item2, fieldManager.Wolves);

            return new Fields
            {
                Size = fieldManager.Size,
                IterationCount = fieldManager.IterationCount + 1,
                Lettuces = rabbitsNextTurn.Item1,
                Rabbits = wolvesNextTurn.Item1,
                Wolves = wolvesNextTurn.Item2,
            };
        }
    }
}