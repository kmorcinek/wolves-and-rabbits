using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.WolvesAndRabbits
{
    public class LettuceField
    {
        public IEnumerable<Lettuce> Create(int size)
        {
            for (int i = -size; i < size + 1; i++)
            {
                for (int j = -size; j < size + 1; j++)
                {
                    yield return new Lettuce(new Position(i, j), 10);
                }
            }
        }

        public IEnumerable<Lettuce> NextTurn(IEnumerable<Lettuce> lettuces)
        {
            return lettuces.Select(Grow);
        }

        Lettuce Grow(Lettuce lettuce)
        {
            return new Lettuce(lettuce.Position, lettuce.Food + 2);
        }
    }
}