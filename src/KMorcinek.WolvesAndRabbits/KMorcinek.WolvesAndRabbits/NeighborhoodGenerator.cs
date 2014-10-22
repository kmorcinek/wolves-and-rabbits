using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.WolvesAndRabbits
{
    public class NeighborhoodGenerator
    {
        public List<int> Generate(int position)
        {
            return GenerateLazy(position).ToList();
        }

        private IEnumerable<int> GenerateLazy(int position)
        {
            int[] array = {-22, -21, -20, -1, 0, 1, 20, 21, 22};
            return array.Select( n => n + position);
        }
    }
}