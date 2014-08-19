using System.Diagnostics;

namespace KMorcinek.WolvesAndRabbits
{
    [DebuggerDisplay("{Position}, Food:{Food}")]
    public struct Lettuce
    {
        private readonly Position position;
        private readonly double food;

        public Position Position
        {
            get { return position; }
        }

        public double Food
        {
            get { return food; }
        }

        public Lettuce(Position position, double food)
        {
            this.position = position;
            this.food = food;
        }
    }
}