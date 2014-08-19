using System.Collections.Generic;

namespace KMorcinek.WolvesAndRabbits
{
    public class NeighborhoodGenerator
    {
        public IEnumerable<Position> Generate(Position position)
        {
            int x = position.X;
            int y = position.Y;

            yield return new Position(x - 1, y - 1);
            yield return new Position(x - 1, y);
            yield return new Position(x - 1, y + 1);
            yield return new Position(x, y - 1);
            yield return new Position(x, y);
            yield return new Position(x, y + 1);
            yield return new Position(x + 1, y - 1);
            yield return new Position(x + 1, y);
            yield return new Position(x + 1, y + 1);
        }
    }
}