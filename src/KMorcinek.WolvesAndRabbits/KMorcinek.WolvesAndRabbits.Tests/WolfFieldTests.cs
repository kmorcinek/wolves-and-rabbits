using System.Collections.Generic;
using System.Linq;
using KMorcinek.WolvesAndRabbits.Configuration;
using Xunit;
using Xunit.Should;

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
            List<Rabbit> rabbits = new List<Rabbit>(new[] { new Rabbit(new Position(0, 1), 10) });

            Wolf wolf = new Wolf(new Position(0, 0), 10);
            var fieldWithRabbit = wolfField.PredatorMovesAndEatsOnlyBestPrey(rabbits, wolf);

            fieldWithRabbit.Item2.Food.ShouldBe(10 + 10);
        }

        [Fact]
        void GivenOneRabbitInWolfNeighborhood_WolfKillsRabbit()
        {
            List<Rabbit> rabbits = new List<Rabbit>(new[] { new Rabbit(new Position(0, 1), 10) });

            Wolf wolf = new Wolf(new Position(0, 0), 10);
            var fieldWithRabbit = wolfField.PredatorMovesAndEatsOnlyBestPrey(rabbits, wolf);

            fieldWithRabbit.Item1.Count().ShouldBe(0);
        }

        [Fact]
        void GivenRabbitsOutsideOfWolfNeighborhood_WolfDoesNotEat()
        {
            List<Rabbit> rabbits = new List<Rabbit>(new[] { new Rabbit(new Position(0, 2), 10) });

            Wolf wolf = new Wolf(new Position(0, 0), 10);
            var fieldWithRabbit = wolfField.PredatorMovesAndEatsOnlyBestPrey(rabbits, wolf);

            fieldWithRabbit.Item2.Food.ShouldBe(10);
        }

        [Fact]
        void GivenNoRabbits_WolfDoesNotEat()
        {
            IEnumerable<Rabbit> rabbits = Enumerable.Empty<Rabbit>();

            Wolf wolf = new Wolf(new Position(0, 0), 10);
            var fieldWithRabbit = wolfField.PredatorMovesAndEatsOnlyBestPrey(rabbits, wolf);

            fieldWithRabbit.Item2.Food.ShouldBe(10);
        }

        [Fact]
        void GivenNoRabbits_WolfMovesDoesNotMove()
        {
            IEnumerable<Rabbit> rabbits = Enumerable.Empty<Rabbit>();

            Position wolfStartingPosition = new Position(1, -1);
            Wolf wolf = new Wolf(wolfStartingPosition, 10);
            var fieldWithRabbit = wolfField.PredatorMovesAndEatsOnlyBestPrey(rabbits, wolf);

            fieldWithRabbit.Item2.Position.ShouldBe(wolfStartingPosition);
        }
    }
}