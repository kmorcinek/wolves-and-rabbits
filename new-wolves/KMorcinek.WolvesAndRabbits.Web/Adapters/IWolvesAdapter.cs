using KMorcinek.WolvesAndRabbits.Configuration;

namespace KMorcinek.WolvesAndRabbits.Web.Adapters
{
    internal interface IWolvesAdapter
    {
        CellsData GetNextTurn();
        dynamic Reset(FullConfiguration configuration);
    }
}