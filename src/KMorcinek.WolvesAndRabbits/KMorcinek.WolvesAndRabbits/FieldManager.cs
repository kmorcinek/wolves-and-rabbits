using System;
using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.WolvesAndRabbits
{
    public class FieldManager
    {
        private IEnumerable<Lettuce> lettuces;
        private IEnumerable<Rabbit> rabbits;
        private int size;

        readonly LettuceField lettuceField = new LettuceField();
        readonly RabbitField rabbitField = new RabbitField();

        public FieldManager Create()
        {
            int size = 3;
            return new FieldManager
            {
                size = size,
                lettuces = lettuceField.Create(size),
                rabbits = new List<Rabbit>(new[]
                {
                    new Rabbit(new Position(0, 0), 10),
                    new Rabbit(new Position(0, 0), 9),
                }),
            };
        }

        public FieldManager GetNextTurn(FieldManager fieldManager)
        {
            IEnumerable<Lettuce> nextTurnLettuces = lettuceField.NextTurn(fieldManager.lettuces);
            Tuple<IEnumerable<Lettuce>, IEnumerable<Rabbit>> nextTurn =
                rabbitField.GetNextTurn(nextTurnLettuces, fieldManager.rabbits);

            return new FieldManager
            {
                size = fieldManager.size,
                lettuces = nextTurn.Item1,
                rabbits = nextTurn.Item2,
            };
        }

        public Cell[][] GetCellArrays()
        {
            int totalSize = size * 2 + 1;
            Cell[][] cells = new Cell[totalSize][];

            for (int x = 0; x < totalSize; x++)
            {
                cells[x] = new Cell[totalSize];

                for (int y = 0; y < totalSize; y++)
                {
                    Lettuce lettuce = GetLettuce(x, y);
                    cells[x][y] = new Cell
                    {
                        saturation = (int)lettuce.Food
                    };

                    Rabbit rabbit = GetRabbit(x, y);
                    if(rabbit != null)
                    {
                        cells[x][y].l = "R";
                    }
                }
            }

            return cells;
        }

        private Rabbit GetRabbit(int x, int y)
        {
            Position transletedPosition = GetTranslatedPosition(x, y);

            return rabbits.FirstOrDefault(p => p.Position == transletedPosition);
        }

        private Lettuce GetLettuce(int x, int y)
        {
            Position transletedPosition = GetTranslatedPosition(x, y);

            return lettuces.Single(p => p.Position == transletedPosition);
        }

        private Position GetTranslatedPosition(int x, int y)
        {
            return new Position(x - size, y - size);
        }
    }
}