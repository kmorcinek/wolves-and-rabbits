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
                    new Rabbit(0, 10),
                    new Rabbit(0, 10),
                    new Rabbit(0, 10),
                    new Rabbit(0, 10),
                    new Rabbit(0, 10),
                    new Rabbit(0, 9),
                    new Rabbit(-5, 9),
                    new Rabbit(-6, 9),
                    new Rabbit(-9, 9),
                    new Rabbit(-29, 9),
                    new Rabbit(-29, 9),
                    new Rabbit(-29, 9),
                    new Rabbit(-29, 9),
                    new Rabbit(-29, 9),
                    new Rabbit(-29, 9),
                    new Rabbit(-29, 9),
                    new Rabbit(-29, 9),
                    new Rabbit(-44, 9),
                    new Rabbit(11, 9),
                    new Rabbit(-44, 9),
                    new Rabbit(26, 9),
                    new Rabbit(26, 9),
                    new Rabbit(26, 9),
                    new Rabbit(26, 9),
                    new Rabbit(26, 9),
                    new Rabbit(26, 9),
                    new Rabbit(26, 9),
                    new Rabbit(26, 9),
                    new Rabbit(26, 9),
                    new Rabbit(88, 9),
                    new Rabbit(88, 9),
                    new Rabbit(88, 9),
                    new Rabbit(88, 9),
                    new Rabbit(88, 9),
                    new Rabbit(88, 9),
                    new Rabbit(88, 9),
                    new Rabbit(88, 9),
                    new Rabbit(88, 9),
                    new Rabbit(88, 9),
                    new Rabbit(88, 9),
                }),
                Wolves = new List<Wolf>(
                                        //Enumerable.Empty<Wolf>()
                    new[]
                    {
                        new Wolf(66, 35), 
                        new Wolf(99, 35), 
                        new Wolf(-13, 35), 
                        new Wolf(-19, 35), 
                        new Wolf(-37, 35), 
                        new Wolf(37, 35), 
                        new Wolf(54, 35), 
                        new Wolf(-54, 35), 
                        new Wolf(7, 35), 
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
                Lettuces = rabbitsNextTurn.Item1.ToList(),
                Rabbits = wolvesNextTurn.Item1.ToList(),
                Wolves = wolvesNextTurn.Item2.ToList(),
            };
        }
    }
}