namespace KMorcinek.WolvesAndRabbits
{
    public class Rabbit
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

        public Rabbit(Position position, double food)
        {
            this.position = position;
            this.food = food;
        }
    }
}