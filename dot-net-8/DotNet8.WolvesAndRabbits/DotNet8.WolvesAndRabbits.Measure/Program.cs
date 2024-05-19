using System.Diagnostics;
using KMorcinek.WolvesAndRabbits.Configuration;
using KMorcinek.WolvesAndRabbits.Utils;

namespace KMorcinek.WolvesAndRabbits.Measure
{
    class Program
    {
        static void Main()
        {
            FullConfiguration configuration = FullConfiguration.CreateDefault();

            IRandom systemRandom = new SystemRandom();
            FieldManager fieldManager = new FieldManager(
                new LettuceField(systemRandom, configuration.LettuceFieldConfiguration),
                new RabbitField(configuration.RabbitFieldConfiguration),
                new WolfField(configuration.WolfFieldConfiguration),
                systemRandom);

            Fields fields = fieldManager.Create();

            Stopwatch stopwatch = Stopwatch.StartNew();

            const int repeatCount = 1000;
            for (int i = 0; i < repeatCount; i++)
            {
                fields = fieldManager.GetNextTurn(fields);
            }

            TimeSpan timeSpan = stopwatch.Elapsed;

            using (StreamWriter streamWriter = File.AppendText("elapsedTimes.txt"))
            {
                streamWriter.WriteLine(timeSpan);
            }
        }
    }
}