using System;
using System.Collections.Generic;
using System.Linq;
using KMorcinek.WolvesAndRabbits.Configuration;
using KMorcinek.WolvesAndRabbits.Utils;
using Moq;
using Xunit;

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
        public void CreateWithSizeOne()
        {
            Lettuce[] lettuces = lettuceField.Create(1).ToArray();
            throw new NotImplementedException();
            
            // lettuces.Count().ShouldBe(9);
            Assert.Equal(9, lettuces.Length);
            
            //lettuces.Count(p => p.int.X == 1 && p.int.Y == 1).ShouldBe(1);
            //lettuces.Count(p => p.int.X == -1 && p.int.Y == -1).ShouldBe(1);
            //lettuces.Count(p => p.int.X == 1 && p.int.Y == -1).ShouldBe(1);
        }

        [Fact]
        public void NextTurnOneLettuceGrows()
        {
            List<Lettuce> lettuces = new List<Lettuce>(new[] { new Lettuce(0, 10) });

            IEnumerable<Lettuce> nextLettuces = lettuceField.NextTurn(lettuces);

            // .ShouldBe(12);
            Assert.Equal(12, nextLettuces.First().Food);
        }

        [Fact]
        public void NextTurnAllLettucesGrow()
        {
            IEnumerable<Lettuce> lettuces = lettuceField.Create(1);

            IEnumerable<Lettuce> nextLettuces = lettuceField.NextTurn(lettuces);

            foreach (var lettuce in nextLettuces)
            {
                // lettuce.Food.ShouldBe(12);
                Assert.Equal(12, lettuce.Food);
            }
        }

        [Fact]
        public void LettuceCannotGrowMoreThanMaximum()
        {
            List<Lettuce> lettuces = new List<Lettuce>(new[] { new Lettuce(0, 100) });

            IEnumerable<Lettuce> nextLettuces = lettuceField.NextTurn(lettuces);

            // nextLettuces.First().Food.ShouldBe(100);
            Assert.Equal(100, nextLettuces.First().Food);
        }
    }
}