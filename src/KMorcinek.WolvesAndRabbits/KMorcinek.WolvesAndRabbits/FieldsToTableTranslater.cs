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
            }

            foreach (var lettuce in fields.Lettuces)
            {
                Position positionInTable = TranslateToResultMatrix(fields.Size, lettuce.Position);
                cells[positionInTable.X][positionInTable.Y].saturation = (int)lettuce.Food;
            }

            foreach (var rabbit in fields.Rabbits)
            {
                Position positionInTable = TranslateToResultMatrix(fields.Size, rabbit.Position);
                cells[positionInTable.X][positionInTable.Y].l = "R";
            }

            foreach (var wolf in fields.Wolves)
            {
                Position positionInTable = TranslateToResultMatrix(fields.Size, wolf.Position);
                cells[positionInTable.X][positionInTable.Y].l = "W";
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

        private static Position TranslateToResultMatrix(int size, int position)
        {
            int length = 2 * size + 1;
            int range = (length * length - 1) / 2;

            int newPosition = position + range;

            return new Position(newPosition / length, newPosition % length);
        }
    }
}