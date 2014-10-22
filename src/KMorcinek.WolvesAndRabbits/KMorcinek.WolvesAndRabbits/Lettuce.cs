using System.Diagnostics;

namespace KMorcinek.WolvesAndRabbits
{
    [DebuggerDisplay("{int}, Food:{Food}")]
    public struct Lettuce : IFood
    {
        private readonly int position;
        private readonly double food;

        public int Position
        {
            get { return position; }
        }

        public double Food
        {
            get { return food; }
        }

        public Lettuce(int position, double food)
        {
            this.position = position;
            this.food = food;
        }

        public IFood Create(int position, double food)
        {
            return new Lettuce(position, food);
        }
    }
}