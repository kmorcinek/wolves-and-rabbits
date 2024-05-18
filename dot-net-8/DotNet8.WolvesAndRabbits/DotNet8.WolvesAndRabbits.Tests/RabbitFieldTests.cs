using System.Collections.Generic;
using System.Linq;
using KMorcinek.WolvesAndRabbits.Configuration;
using Xunit;

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
        public void OneRabbitEatsOneLettuce()
        {
            List<Lettuce> lettuces = new List<Lettuce> { new Lettuce(0, 10) };
            Rabbit rabbit = new Rabbit(0, 10);

            var fieldWithRabbit = rabbitField.PredatorMovesAndEatsOnlyBestPrey(lettuces, rabbit);

            Assert.Equal(3, fieldWithRabbit.Item1.First().Food);
            Assert.Equal(17, fieldWithRabbit.Item2.Food);
        }

        [Fact]
        public void GivenManyLettuces_RabbitChoosesBestLettuceAndEats()
        {
            Lettuce bestLettuce = new Lettuce(20, 15);
            List<Lettuce> lettuces = new List<Lettuce>
            {
                bestLettuce,
                new Lettuce(0, 10),
                new Lettuce(-20, 12)
            };

            Rabbit rabbit = new Rabbit(0, 10);

            var fieldWithRabbit = rabbitField.PredatorMovesAndEatsOnlyBestPrey(lettuces, rabbit);

            Assert.Equal(8, fieldWithRabbit.Item1.Single(p => p.Position == bestLettuce.Position).Food);
            Assert.Equal(17, fieldWithRabbit.Item2.Food);
        }

        [Fact]
        public void GivenManyLettuces_RabbitChoosesBestLettuceAndMoves()
        {
            Lettuce bestLettuce = new Lettuce(20, 15);
            List<Lettuce> lettuces = new List<Lettuce>
            {
                new Lettuce(0, 10),
                bestLettuce,
                new Lettuce(-20, 12),
            };

            Rabbit rabbit = new Rabbit(-1, 10);

            var fieldWithRabbit = rabbitField.PredatorMovesAndEatsOnlyBestPrey(lettuces, rabbit);

            Assert.Equal(bestLettuce.Position, fieldWithRabbit.Item2.Position);
        }

        [Fact]
        public void GivenManyLettuces_RabbitDoesNotEatNotChoosenLettuce()
        {
            Lettuce bestLettuce = new Lettuce(20, 15);
            Lettuce notBestLettuce = new Lettuce(-20, 12);
            List<Lettuce> lettuces = new List<Lettuce>
            {
                bestLettuce,
                notBestLettuce
            };

            Rabbit rabbit = new Rabbit(0, 10);

            var fieldWithRabbit = rabbitField.PredatorMovesAndEatsOnlyBestPrey(lettuces, rabbit);
            Assert.Equal(2, fieldWithRabbit.Item1.Count());
            Assert.Equal(notBestLettuce.Food, fieldWithRabbit.Item1.Single(p => p.Position == notBestLettuce.Position).Food);
        }

        [Fact]
        public void ManyRabbitsEatManyLettuces()
        {
            List<Lettuce> lettuces = new List<Lettuce>
            {
                new Lettuce(20, 15),
                new Lettuce(0, 10),
                new Lettuce(-20, 12)
            };

            List<Rabbit> rabbits = new List<Rabbit>
            {
                new Rabbit(0, 10),
                new Rabbit(0, 9),
            };

            var fieldWithRabbit = rabbitField.GetNextTurn(lettuces, rabbits);

            Assert.Equal(8, fieldWithRabbit.Item1.Single(p => p.Position == 20).Food);
            Assert.Equal(5, fieldWithRabbit.Item1.Single(p => p.Position == -20).Food);
            List<Rabbit> nextRabbits = fieldWithRabbit.Item2.ToList();
            Assert.Equal(2, nextRabbits.Count);
            Assert.Equal(15, nextRabbits[0].Food);
            Assert.Equal(14, nextRabbits[1].Food);
        }

        [Fact]
        public void OneRabbitChoosesBestLettuce()
        {
            List<Lettuce> lettuces = new List<Lettuce>
            {
                new Lettuce(0, 10),
                new Lettuce(-20, 12)
            };

            Rabbit rabbit = new Rabbit(0, 10);

            Lettuce lettuce;
            Assert.True(rabbitField.TryChooseBestPrey(lettuces, rabbit, out lettuce));
            Assert.Equal(-20, lettuce.Position);
        }

        [Fact]
        public void OneRabbitChoosesBestLettuce_2()
        {
            List<Lettuce> lettuces = new List<Lettuce>
            {
                new Lettuce(20, 15),
                new Lettuce(0, 10),
                new Lettuce(-20, 12)
            };

            Rabbit rabbit = new Rabbit(0, 10);

            Lettuce lettuce;
            Assert.True(rabbitField.TryChooseBestPrey(lettuces, rabbit, out lettuce));

            Assert.Equal(20, lettuce.Position);
        }

        [Fact]
        public void GivenNotEnoughLettuce_RabbitEatsEverything()
        {
            List<Lettuce> lettuces = new List<Lettuce> { new Lettuce(0, 2) };

            Rabbit rabbit = new Rabbit(0, 10);

            var fieldWithRabbit = rabbitField.PredatorMovesAndEatsOnlyBestPrey(lettuces, rabbit);

            Assert.Equal(0, fieldWithRabbit.Item1.First().Food);
        }

        [Fact]
        public void GivenNotEnoughLettuce_RabbitsFeedsWithPercentageOfEatenFood()
        {
            List<Lettuce> lettuces = new List<Lettuce> { new Lettuce(0, 2) };

            Rabbit rabbit = new Rabbit(0, 0);

            var fieldWithRabbit = rabbitField.PredatorMovesAndEatsOnlyBestPrey(lettuces, rabbit);

            Assert.Equal(2, fieldWithRabbit.Item2.Food);
        }

        [Fact]
        public void GivenNotEnoughFood_RabbitDie()
        {
            List<Lettuce> lettuces = new List<Lettuce> { new Lettuce(0, 2) };

            List<Rabbit> rabbits = new List<Rabbit>
            {
                new Rabbit(0, 3),
            };

            var fieldWithRabbit = rabbitField.GetNextTurn(lettuces, rabbits);

            Assert.Equal(0, fieldWithRabbit.Item2.Count());
        }

        [Fact]
        public void GivenALotOfFood_NewRabbitIsBorn()
        {
            List<Lettuce> lettuces = new List<Lettuce> { new Lettuce(0, 20) };

            List<Rabbit> rabbits = new List<Rabbit>
            {
                new Rabbit(0, 42),
            };

            var fieldWithRabbit = rabbitField.GetNextTurn(lettuces, rabbits);

            Assert.Equal(2, fieldWithRabbit.Item2.Count());
        }

        [Fact]
        public void EveryTurnRabitUsesSomeFood()
        {
            List<Lettuce> lettuces = new List<Lettuce> { new Lettuce(0, 0) };

            List<Rabbit> rabbits = new List<Rabbit>
            {
                new Rabbit(0, 10),
            };

            var fieldWithRabbit = rabbitField.GetNextTurn(lettuces, rabbits);

            Assert.Equal(8, fieldWithRabbit.Item2.First().Food);
        }
    }
}
