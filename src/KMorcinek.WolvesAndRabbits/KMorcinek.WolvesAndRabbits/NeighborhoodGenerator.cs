using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.WolvesAndRabbits
{
    public class NeighborhoodGenerator
    {
        public List<Position> Generate(Position position)
        {
            return GenerateLazy(position).ToList();
        }

        private IEnumerable<Position> GenerateLazy(Position position)
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