namespace KMorcinek.WolvesAndRabbits
{
    public interface IFood
    {
        Position Position { get; }
        double Food { get; }

        IFood Create(Position position, double food);
    }
}