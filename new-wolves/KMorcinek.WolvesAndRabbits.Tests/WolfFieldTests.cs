using KMorcinek.WolvesAndRabbits.Configuration;

namespace KMorcinek.WolvesAndRabbits.Tests
{
    public class WolfFieldTests
    {
        readonly WolfField wolfField = new WolfField(new WolfFieldConfiguration
        {
            FoodConsumedForDinner = 2,
        });

        [Fact]
        void GivenOneRabbitInWolfNeighborhood_WolfEatsWholeRabbit()
        {
            List<Rabbit> rabbits = new List<Rabbit>(new[] { new Rabbit(-20, 10) });

            Wolf wolf = new Wolf(0, 10);
            var fieldWithRabbit = wolfField.PredatorMovesAndEatsOnlyBestPrey(rabbits, wolf);

            fieldWithRabbit.Item2.Food.ShouldBe(10 + 10);
        }

        [Fact]
        void GivenOneRabbitInWolfNeighborhood_WolfKillsRabbit()
        {
            List<Rabbit> rabbits = new List<Rabbit>(new[] { new Rabbit(-20, 10) });

            Wolf wolf = new Wolf(0, 10);
            var fieldWithRabbit = wolfField.PredatorMovesAndEatsOnlyBestPrey(rabbits, wolf);

            fieldWithRabbit.Item1.Count().ShouldBe(0);
        }

        [Fact]
        void GivenRabbitsOutsideOfWolfNeighborhood_WolfDoesNotEat()
        {
            List<Rabbit> rabbits = new List<Rabbit>(new[] { new Rabbit(1, 10) });

            Wolf wolf = new Wolf(-1, 10);
            var fieldWithRabbit = wolfField.PredatorMovesAndEatsOnlyBestPrey(rabbits, wolf);

            fieldWithRabbit.Item2.Food.ShouldBe(10);
        }

        [Fact]
        void GivenNoRabbits_WolfDoesNotEat()
        {
            IEnumerable<Rabbit> rabbits = Enumerable.Empty<Rabbit>();

            Wolf wolf = new Wolf(0, 10);
            var fieldWithRabbit = wolfField.PredatorMovesAndEatsOnlyBestPrey(rabbits, wolf);

            fieldWithRabbit.Item2.Food.ShouldBe(10);
        }

        [Fact]
        void GivenNoRabbits_WolfMovesDoesNotMove()
        {
            IEnumerable<Rabbit> rabbits = Enumerable.Empty<Rabbit>();

            int wolfStartingPosition = 22;
            Wolf wolf = new Wolf(wolfStartingPosition, 10);
            var fieldWithRabbit = wolfField.PredatorMovesAndEatsOnlyBestPrey(rabbits, wolf);

            fieldWithRabbit.Item2.Position.ShouldBe(wolfStartingPosition);
        }
    }
}