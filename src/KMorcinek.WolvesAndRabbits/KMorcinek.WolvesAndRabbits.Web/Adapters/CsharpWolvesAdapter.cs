using KMorcinek.WolvesAndRabbits.Configuration;
using KMorcinek.WolvesAndRabbits.Utils;

namespace KMorcinek.WolvesAndRabbits.Web.Adapters
{
    class CsharpWolvesAdapter : IWolvesAdapter
    {
        static FieldManager fieldManager;
        static Fields fields;

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
    }
}