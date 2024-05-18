using System.Collections.Generic;
using System.Linq;
using KMorcinek.WolvesAndRabbits.Configuration;
using Xunit;

namespace KMorcinek.WolvesAndRabbits.Tests
{
    public class WolfFieldTests
    {
        readonly WolfField wolfField = new WolfField(new WolfFieldConfiguration
        {
            FoodConsumedForDinner = 2,
        });

        [Fact]
        public void GivenOneRabbitInWolfNeighborhood_WolfEatsWholeRabbit()
        {
            List<Rabbit> rabbits = new List<Rabbit> { new Rabbit(-20, 10) };

            Wolf wolf = new Wolf(0, 10);
            var fieldWithRabbit = wolfField.PredatorMovesAndEatsOnlyBestPrey(rabbits, wolf);

            Assert.Equal(20, fieldWithRabbit.Item2.Food);
        }

        [Fact]
        public void GivenOneRabbitInWolfNeighborhood_WolfKillsRabbit()
        {
            List<Rabbit> rabbits = new List<Rabbit> { new Rabbit(-20, 10) };

            Wolf wolf = new Wolf(0, 10);
            var fieldWithRabbit = wolfField.PredatorMovesAndEatsOnlyBestPrey(rabbits, wolf);

            Assert.Equal(0, fieldWithRabbit.Item1.Count());
        }

        [Fact]
        public void GivenRabbitsOutsideOfWolfNeighborhood_WolfDoesNotEat()
        {
            List<Rabbit> rabbits = new List<Rabbit> { new Rabbit(1, 10) };

            Wolf wolf = new Wolf(-1, 10);
            var fieldWithRabbit = wolfField.PredatorMovesAndEatsOnlyBestPrey(rabbits, wolf);

            Assert.Equal(10, fieldWithRabbit.Item2.Food);
        }

        [Fact]
        public void GivenNoRabbits_WolfDoesNotEat()
        {
            IEnumerable<Rabbit> rabbits = Enumerable.Empty<Rabbit>();

            Wolf wolf = new Wolf(0, 10);
            var fieldWithRabbit = wolfField.PredatorMovesAndEatsOnlyBestPrey(rabbits, wolf);

            Assert.Equal(10, fieldWithRabbit.Item2.Food);
        }

        [Fact]
        public void GivenNoRabbits_WolfDoesNotMove()
        {
            IEnumerable<Rabbit> rabbits = Enumerable.Empty<Rabbit>();

            int wolfStartingPosition = 22;
            Wolf wolf = new Wolf(wolfStartingPosition, 10);
            var fieldWithRabbit = wolfField.PredatorMovesAndEatsOnlyBestPrey(rabbits, wolf);

            Assert.Equal(wolfStartingPosition, fieldWithRabbit.Item2.Position);
        }
    }
}