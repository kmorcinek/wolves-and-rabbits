using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.WolvesAndRabbits
{
    public class FieldsToTableTranslater
    {
        private Cell[][] GetCellArrays(Fields fields)
        {
            int totalSize = fields.Size * 2 + 1;
            Cell[][] cells = new Cell[totalSize][];

            for (int x = 0; x < totalSize; x++)
            {
                cells[x] = new Cell[totalSize];

                for (int y = 0; y < totalSize; y++)
                {
                    Lettuce lettuce = GetLettuce(fields.Lettuces, fields.Size, x, y);
                    cells[x][y] = new Cell
                    {
                        saturation = (int)lettuce.Food
                    };

                    string letter = GetPredatorLetter(fields.Rabbits, fields.Wolves, fields.Size, x, y);
                    if (false == string.IsNullOrWhiteSpace(letter))
                    {
                        cells[x][y].l = letter;
                    }
                }
            }

            return cells;
        }

        public dynamic GetData(Fields fields)
        {
            return new
            {
                cellArrays = GetCellArrays(fields),
                iterationCount = fields.IterationCount,
            };
        }

        private string GetPredatorLetter(IEnumerable<Rabbit> rabbits, IEnumerable<Wolf> wolves, int size, int x, int y)
        {
            Position translatedPosition = GetTranslatedPosition(size, x, y);

            if (wolves.Any(p => p.Position == translatedPosition))
                return "W";

            return rabbits.Any(p => p.Position == translatedPosition) ? "R" : null;
        }

        private Lettuce GetLettuce(IEnumerable<Lettuce> lettuces, int size, int x, int y)
        {
            Position translatedPosition = GetTranslatedPosition(size, x, y);

            return lettuces.Single(p => p.Position == translatedPosition);
        }

        private Position GetTranslatedPosition(int size, int x, int y)
        {
            return new Position(x - size, y - size);
        } 
    }
}