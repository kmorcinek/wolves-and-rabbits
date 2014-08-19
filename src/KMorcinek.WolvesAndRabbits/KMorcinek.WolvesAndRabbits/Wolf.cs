using System.Diagnostics;

namespace KMorcinek.WolvesAndRabbits
{
    [DebuggerDisplay("{Position}, Food:{Food}")]
    public struct Wolf : IFood
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

        public Wolf(Position position, double food)
        {
            this.position = position;
            this.food = food;
        }

        public IFood Create(Position position, double food)
        {
            return new Wolf(position, food);
        }
    }
}