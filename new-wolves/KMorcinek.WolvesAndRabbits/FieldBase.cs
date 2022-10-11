using KMorcinek.WolvesAndRabbits.Configuration;

namespace KMorcinek.WolvesAndRabbits
{
    public abstract class FieldBase<TPrey, TPredator>
        where TPrey : struct, IFood
        where TPredator : struct, IFood
    {
        private readonly FieldConfigurationBase configuration;

        protected FieldBase(FieldConfigurationBase configuration)
        {
            this.configuration = configuration;
        }

        public bool TryChooseBestPrey(IEnumerable<TPrey> preys, TPredator predator, out TPrey prey)
        {
            NeighborhoodGenerator neighborhoodGenerator = new NeighborhoodGenerator();
            IEnumerable<int> predatorNeighborhood = neighborhoodGenerator.Generate(predator.Position);

            IEnumerable<TPrey> preysInNeighborhood = preys.Where(p => predatorNeighborhood.Contains(p.Position)).ToList();

            if (preysInNeighborhood.Any())
            {
                prey = preysInNeighborhood.Aggregate((agg, next) => next.Food > agg.Food ? next : agg);
                return true;
            }

            prey = default(TPrey);
            return false;
        }

        public abstract Tuple<IEnumerable<TPrey>, TPredator> PredatorMovesAndEatsOnlyBestPrey(
            IEnumerable<TPrey> g, TPredator predator);

        public Tuple<IEnumerable<TPrey>, IEnumerable<TPredator>> GetNextTurn(IEnumerable<TPrey> preys, IEnumerable<TPredator> predators)
        {
            IEnumerable<TPredator> nextPredators = Enumerable.Empty<TPredator>();

            foreach (var predator in predators)
            {
                var preysAndPredators = PredatorMovesAndEatsOnlyBestPrey(preys, predator);
                preys = preysAndPredators.Item1;
                nextPredators = nextPredators.Concat(new[] { preysAndPredators.Item2 });
            }

            nextPredators = GetAfterDinner(nextPredators);
            nextPredators = GetAlive(nextPredators);
            nextPredators = AddNewBorns(nextPredators);

            return new Tuple<IEnumerable<TPrey>, IEnumerable<TPredator>>(
                preys,
                nextPredators);
        }

        private IEnumerable<TPredator> GetAfterDinner(IEnumerable<TPredator> predators)
        {
            return predators
                .Select(p => CreatePredator(p.Position, p.Food - configuration.FoodConsumedForDinner));
        }

        private TPredator CreatePredator(int position, double food)
        {
            return (TPredator)default(TPredator).Create(position, food);
        }

        private IEnumerable<TPredator> AddNewBorns(IEnumerable<TPredator> predators)
        {
            Func<TPredator, bool> isPregnant = p => p.Food > configuration.BirthThreshold;
            IEnumerable<TPredator> pregnant = predators.Where(isPregnant).ToList();
            IEnumerable<TPredator> notPregnant = predators.Where(p => false == isPregnant(p));

            IEnumerable<TPredator> mothers = pregnant.Select(p => CreatePredator(p.Position, p.Food / 2));
            IEnumerable<TPredator> kids = pregnant.Select(p => CreatePredator(p.Position, p.Food / 4));

            return notPregnant
                .Concat(mothers)
                .Concat(kids);
        }

        private IEnumerable<TPredator> GetAlive(IEnumerable<TPredator> predators)
        {
            return predators.Where(p => p.Food > configuration.DeathThreshold);
        }
    }
}