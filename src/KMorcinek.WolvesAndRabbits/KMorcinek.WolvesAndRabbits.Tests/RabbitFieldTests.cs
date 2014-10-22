using System.Collections.Generic;
using System.Linq;
using KMorcinek.WolvesAndRabbits.Configuration;
using Xunit;
using Xunit.Should;

namespace KMorcinek.WolvesAndRabbits.Tests
{
    public class RabbitFieldTests
    {
        private readonly RabbitField rabbitField = new RabbitField(new RabbitFieldConfiguration
        {
            FoodConsumedForDinner = 2,
            BirthThreshold = 40,
            MaximumFoodEatenFromLettuce = 7,
            DeathThreshold = 5,
        });

        [Fact]
        void OneRabbitEatsOneLettuce()
        {
            List<Lettuce> lettuces = new List<Lettuce>(new[] { new Lettuce(0, 10) });

            Rabbit rabbit = new Rabbit(0, 10);

            var fieldWithRabbit = rabbitField.PredatorMovesAndEatsOnlyBestPrey(lettuces, rabbit);

            fieldWithRabbit.Item1.First().Food.ShouldBe(3);
            fieldWithRabbit.Item2.Food.ShouldBe(17);
        }

        [Fact]
        void GivenManyLettuces_RabbitChoosesBestLettuceAndEats()
        {
            Lettuce bestLettuce = new Lettuce(20, 15);
            List<Lettuce> lettuces = new List<Lettuce>(new[]
            {
                bestLettuce,
                new Lettuce(0, 10),
                new Lettuce(-20, 12)
            });

            Rabbit rabbit = new Rabbit(0, 10);

            var fieldWithRabbit = rabbitField.PredatorMovesAndEatsOnlyBestPrey(lettuces, rabbit);

            fieldWithRabbit.Item1.Single(p => p.Position == bestLettuce.Position).Food.ShouldBe(8);
            fieldWithRabbit.Item2.Food.ShouldBe(17);
        }

        [Fact]
        void GivenManyLettuces_RabbitChoosesBestLettuceAndMoves()
        {
            Lettuce bestLettuce = new Lettuce(20, 15);
            List<Lettuce> lettuces = new List<Lettuce>(new[]
            {
                new Lettuce(0, 10),
                bestLettuce,
                new Lettuce(-20, 12),
            });

            Rabbit rabbit = new Rabbit(-1, 10);

            var fieldWithRabbit = rabbitField.PredatorMovesAndEatsOnlyBestPrey(lettuces, rabbit);

            fieldWithRabbit.Item2.Position.ShouldBe(bestLettuce.Position);
        }

        [Fact]
        void GivenManyLettuces_RabbitDoesNotEatNotChoosenLettuce()
        {
            Lettuce bestLettuce = new Lettuce(20, 15);
            Lettuce notBestLettuce = new Lettuce(-20, 12);
            List<Lettuce> lettuces = new List<Lettuce>(new[]
            {
                bestLettuce,
                notBestLettuce
            });

            Rabbit rabbit = new Rabbit(0, 10);

            var fieldWithRabbit = rabbitField.PredatorMovesAndEatsOnlyBestPrey(lettuces, rabbit);
            fieldWithRabbit.Item1.Count().ShouldBe(2);
            fieldWithRabbit.Item1.Single(p => p.Position == notBestLettuce.Position).Food.ShouldBe(notBestLettuce.Food);
        }

        [Fact]
        void ManyRabbitsEatManyLettuces()
        {
            List<Lettuce> lettuces = new List<Lettuce>(new[]
            {
                new Lettuce(20, 15),
                new Lettuce(0, 10),
                new Lettuce(-20, 12)
            });

            List<Rabbit> rabbits = new List<Rabbit>(new[]
            {
                new Rabbit(0, 10),
                new Rabbit(0, 9),
            });

            var fieldWithRabbit = rabbitField.GetNextTurn(lettuces, rabbits);

            fieldWithRabbit.Item1.Single(p => p.Position == 20).Food.ShouldBe(8);
            fieldWithRabbit.Item1.Single(p => p.Position == -20).Food.ShouldBe(5);
            List<Rabbit> nextRabbits = fieldWithRabbit.Item2.ToList();
            nextRabbits.Count().ShouldBe(2);
            nextRabbits[0].Food.ShouldBe(15);
            nextRabbits[1].Food.ShouldBe(14);
        }

        [Fact]
        void OneRabbitChoosesBestLettuce()
        {
            List<Lettuce> lettuces = new List<Lettuce>(new[]
            {
                new Lettuce(0, 10),
                new Lettuce(-20, 12)
            });

            Rabbit rabbit = new Rabbit(0, 10);

            Lettuce lettuce;
            rabbitField.TryChooseBestPrey(lettuces, rabbit, out lettuce).ShouldBeTrue();
            lettuce.Position.ShouldBe(-20);
        }

        [Fact]
        void OneRabbitChoosesBestLettuce_2()
        {
            List<Lettuce> lettuces = new List<Lettuce>(new[]
            {
                new Lettuce(20, 15),
                new Lettuce(0, 10),
                new Lettuce(-20, 12)
            });

            Rabbit rabbit = new Rabbit(0, 10);

            Lettuce lettuce;
            rabbitField.TryChooseBestPrey(lettuces, rabbit, out lettuce).ShouldBeTrue();

            lettuce.Position.ShouldBe(20);
        }

        [Fact]
        void GivenNotEnoughLettuce_RabbitEatsEverything()
        {
            List<Lettuce> lettuces = new List<Lettuce>(new[] { new Lettuce(0, 2) });

            Rabbit rabbit = new Rabbit(0, 10);

            var fieldWithRabbit = rabbitField.PredatorMovesAndEatsOnlyBestPrey(lettuces, rabbit);

            fieldWithRabbit.Item1.First().Food.ShouldBe(0);
        }

        [Fact]
        void GivenNotEnoughLettuce_RabbitsFeedsWithPercentageOfEatenFood()
        {
            List<Lettuce> lettuces = new List<Lettuce>(new[] { new Lettuce(0, 2) });

            Rabbit rabbit = new Rabbit(0, 0);

            var fieldWithRabbit = rabbitField.PredatorMovesAndEatsOnlyBestPrey(lettuces, rabbit);

            fieldWithRabbit.Item2.Food.ShouldBe(2);
        }

        [Fact]
        void GivenNotEnoughFood_RabbitDie()
        {
            List<Lettuce> lettuces = new List<Lettuce>(new[] { new Lettuce(0, 2) });

            List<Rabbit> rabbits = new List<Rabbit>(new[]
            {
                new Rabbit(0, 3),
            });

            var fieldWithRabbit = rabbitField.GetNextTurn(lettuces, rabbits);

            fieldWithRabbit.Item2.Count().ShouldBe(0);
        }

        [Fact]
        void GivenALotOfFood_NewRabbitIsBorn()
        {
            List<Lettuce> lettuces = new List<Lettuce>(new[] { new Lettuce(0, 20) });

            List<Rabbit> rabbits = new List<Rabbit>(new[]
            {
                new Rabbit(0, 42),
            });

            var fieldWithRabbit = rabbitField.GetNextTurn(lettuces, rabbits);

            fieldWithRabbit.Item2.Count().ShouldBe(2);
        }

        [Fact]
        void EveryTurnRabitUsesSomeFood()
        {
            List<Lettuce> lettuces = new List<Lettuce>(new[] { new Lettuce(0, 0) });

            List<Rabbit> rabbits = new List<Rabbit>(new[]
            {
                new Rabbit(0, 10),
            });

            var fieldWithRabbit = rabbitField.GetNextTurn(lettuces, rabbits);

            fieldWithRabbit.Item2.First().Food.ShouldBe(8);
        }
    }
}