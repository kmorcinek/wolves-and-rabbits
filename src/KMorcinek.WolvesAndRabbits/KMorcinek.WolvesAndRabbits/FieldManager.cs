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
                    new Rabbit(10, 10),
                    new Rabbit(20, 10),
                    new Rabbit(30, 10),
                    new Rabbit(40, 10),
                    new Rabbit(50, 10),
                    new Rabbit(60, 9),
                    new Rabbit(-5, 9),
                    new Rabbit(-6, 9),
                    new Rabbit(-9, 9),
                    new Rabbit(-21, 9),
                    new Rabbit(-22, 9),
                    new Rabbit(-23, 9),
                    new Rabbit(-24, 9),
                    new Rabbit(-25, 9),
                    new Rabbit(-26, 9),
                    new Rabbit(-27, 9),
                    new Rabbit(-29, 9),
                    new Rabbit(-44, 9),
                    new Rabbit(11, 9),
                    new Rabbit(-44, 9),
                    new Rabbit(20, 9),
                    new Rabbit(21, 9),
                    new Rabbit(22, 9),
                    new Rabbit(23, 9),
                    new Rabbit(24, 9),
                    new Rabbit(25, 9),
                    new Rabbit(26, 9),
                    new Rabbit(30, 9),
                    new Rabbit(31, 9),
                    new Rabbit(71, 9),
                    new Rabbit(72, 9),
                    new Rabbit(73, 9),
                    new Rabbit(74, 9),
                    new Rabbit(75, 9),
                    new Rabbit(77, 9),
                    new Rabbit(84, 9),
                    new Rabbit(85, 9),
                    new Rabbit(86, 9),
                    new Rabbit(87, 9),
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