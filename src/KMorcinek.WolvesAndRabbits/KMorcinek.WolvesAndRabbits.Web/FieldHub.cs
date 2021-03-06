using KMorcinek.WolvesAndRabbits.Configuration;
using KMorcinek.WolvesAndRabbits.Web.Adapters;
using Microsoft.AspNet.SignalR;

namespace KMorcinek.WolvesAndRabbits.Web
{
    public class FieldHub : Hub
    {
        readonly IWolvesAdapter wolvesAdapter = new CsharpWolvesAdapter();

        public dynamic GetNextTurn()
        {
            return wolvesAdapter.GetNextTurn();
        }

        public dynamic Reset(FullConfiguration configuration)
        {
            return wolvesAdapter.Reset(configuration);
        }

        public dynamic GetConfiguration()
        {
            return FullConfiguration.CreateDefault();
        }
    }
}