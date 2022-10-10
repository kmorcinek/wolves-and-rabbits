namespace KMorcinek.WolvesAndRabbits.Configuration
{
    public class FullConfiguration
    {
        public LettuceFieldConfiguration LettuceFieldConfiguration { get; set; }
        public RabbitFieldConfiguration RabbitFieldConfiguration { get; set; }
        public WolfFieldConfiguration WolfFieldConfiguration { get; set; }

        public static FullConfiguration CreateDefault()
        {
            return new FullConfiguration
            {
                LettuceFieldConfiguration = new LettuceFieldConfiguration
                {
                    MaximumFood = 100,
                    StartingFood = 2,
                    FoodGrowingEachTurn = 1,
                },
                RabbitFieldConfiguration = new RabbitFieldConfiguration
                {
                    FoodConsumedForDinner = 6,
                    BirthThreshold = 40,
                    DeathThreshold = 5,
                    MaximumFoodEatenFromLettuce = 10,
                },
                WolfFieldConfiguration = new WolfFieldConfiguration
                {
                    FoodConsumedForDinner = 4,
                    BirthThreshold = 60,
                    DeathThreshold = 5,
                },
            };
        }
    }
}