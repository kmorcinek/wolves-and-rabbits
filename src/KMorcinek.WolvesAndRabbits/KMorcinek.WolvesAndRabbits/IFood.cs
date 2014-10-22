namespace KMorcinek.WolvesAndRabbits
{
    public interface IFood
    {
        int Position { get; }
        double Food { get; }

        IFood Create(int position, double food);
    }
}