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

            IRandom systemRandom = new SystemRandom();
            fieldManager = new FieldManager(
                new LettuceField(systemRandom, configuration.LettuceFieldConfiguration),
                new RabbitField(configuration.RabbitFieldConfiguration),
                new WolfField(configuration.WolfFieldConfiguration),
                systemRandom);

            fields = fieldManager.CreateRandom();

            return new FieldsToTableTranslater().GetData(fields);
        }
    }
}