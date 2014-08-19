using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Should;

namespace KMorcinek.WolvesAndRabbits.Tests
{
    public class LettuceFieldTests
    {
        private readonly LettuceField lettuceField = new LettuceField();

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
    }
}