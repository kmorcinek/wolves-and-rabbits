using KMorcinek.WolvesAndRabbits.Configuration;
using KMorcinek.WolvesAndRabbits.Utils;
using Microsoft.AspNet.SignalR;

namespace KMorcinek.WolvesAndRabbits.Web
{
    public class FieldHub : Hub
    {
        private static FieldManager fieldManager;
        private static Fields fields;

        public dynamic GetNextTurn()
        {
            fields = fieldManager.GetNextTurn(fields);

            return new FieldsToTableTranslater().GetData(fields);
        }

        public dynamic Reset(FullConfiguration configuration)
        {
            configuration = configuration ?? FullConfiguration.CreateDefault();

            fieldManager = new FieldManager(
                new LettuceField(new SystemRandom(), configuration.LettuceFieldConfiguration),
                new RabbitField(configuration.RabbitFieldConfiguration),
                new WolfField(configuration.WolfFieldConfiguration));

            fields = fieldManager.Create();

            return new FieldsToTableTranslater().GetData(fields);
        }

        public dynamic GetConfiguration()
        {
            return FullConfiguration.CreateDefault();
        }
    }
}