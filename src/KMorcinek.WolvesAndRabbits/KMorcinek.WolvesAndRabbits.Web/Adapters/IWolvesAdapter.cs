using KMorcinek.WolvesAndRabbits.Configuration;

namespace KMorcinek.WolvesAndRabbits.Web.Adapters
{
    internal interface IWolvesAdapter
    {
        dynamic GetNextTurn();
        dynamic Reset(FullConfiguration configuration);
    }
}