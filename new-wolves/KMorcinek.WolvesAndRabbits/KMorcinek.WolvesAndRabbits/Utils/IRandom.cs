namespace KMorcinek.WolvesAndRabbits.Utils
{
    public interface IRandom
    {
        double NextDouble();
        int Next(int minValue, int maxValue);
    }
}