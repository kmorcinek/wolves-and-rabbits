using System.Collections.Generic;
using System.Linq;
using KMorcinek.WolvesAndRabbits.Configuration;
using KMorcinek.WolvesAndRabbits.Utils;
using Moq;
using Xunit;
using Xunit.Should;

namespace KMorcinek.WolvesAndRabbits.Tests
{
    public class LettuceFieldTests
    {
        private readonly LettuceField lettuceField;

        public LettuceFieldTests()
        {
            var mock = new Mock<IRandom>();
            mock.Setup(foo => foo.NextDouble()).Returns(0);

            LettuceFieldConfiguration configuration = new LettuceFieldConfiguration
            {
                MaximumFood = 100,
                StartingFood = 10,
                FoodGrowingEachTurn = 2,
            };

            lettuceField = new LettuceField(mock.Object, configuration);
        }

        [Fact]
        void CreateWithSizeOne()
        {
            Lettuce[] lettuces = lettuceField.Create(1).ToArray();

            lettuces.Count().ShouldBe(9);
            lettuces.Count(p => p.Position.X == 1 && p.Position.Y == 1).ShouldBe(1);
            lettuces.Count(p => p.Position.X == -1 && p.Position.Y == -1).ShouldBe(1);
            lettuces.Count(p => p.Position.X == 1 && p.Position.Y == -1).ShouldBe(1);
        }

        [Fact]
        void NextTurnOneLettuceGrows()
        {
            List<Lettuce> lettuces = new List<Lettuce>(new[] { new Lettuce(new Position(0, 0), 10) });

            IEnumerable<Lettuce> nextLettuces = lettuceField.NextTurn(lettuces);

            nextLettuces.First().Food.ShouldBe(12);
        }

        [Fact]
        void NextTurnAllLettucesGrow()
        {
            IEnumerable<Lettuce> lettuces = lettuceField.Create(1);

            IEnumerable<Lettuce> nextLettuces = lettuceField.NextTurn(lettuces);

            foreach (var lettuce in nextLettuces)
            {
                lettuce.Food.ShouldBe(12);
            }
        }

        [Fact]
        void LettuceCannotGrowMoreThanMaximum()
        {
            List<Lettuce> lettuces = new List<Lettuce>(new[] { new Lettuce(new Position(0, 0), 100) });

            IEnumerable<Lettuce> nextLettuces = lettuceField.NextTurn(lettuces);

            nextLettuces.First().Food.ShouldBe(100);
        }
    }
}