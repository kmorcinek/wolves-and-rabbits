using KMorcinek.WolvesAndRabbits.Configuration;

namespace KMorcinek.WolvesAndRabbits.Web
{
    internal interface IWolvesAdapter
    {
        dynamic GetNextTurn();
        dynamic Reset(FullConfiguration configuration);
    }
}