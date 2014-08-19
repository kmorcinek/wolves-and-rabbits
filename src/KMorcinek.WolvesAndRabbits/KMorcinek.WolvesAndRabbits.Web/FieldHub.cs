using Microsoft.AspNet.SignalR;

namespace KMorcinek.WolvesAndRabbits.Web
{
    public class FieldHub : Hub
    {
        private static FieldManager fieldManager = new FieldManager().Create();

        public Cell[][] GetNextTurn()
        {
            Cell[][] cellArrays = fieldManager.GetCellArrays();

            fieldManager = fieldManager.GetNextTurn(fieldManager);

            return cellArrays;
        }
    }
}