module Tests
open Xunit
open Xunit.Should
open Types
open Rabbit

type RabbitTestClass() = 

    [<Fact>]
    let ``One Rabbit Eats One Lettuce``() = 
        let rabbit = new Rabbit(1, 10.0)
        let lettuces = [new Rabbit(1, 10.)]

        let (rabbit, _) = 
            lettuces
            |> RabbitEatsLettuce rabbit 

        Assert.Equal(17., rabbit.Food)

    [<Fact>]
    let ``Choose Best Prey``() = 
        let bestLettuce = new Rabbit(1, 10.)

        let lettuces = [new Rabbit(0, 4.); bestLettuce; new Rabbit(2, 4.)]

        let result = 
            ChooseBestPreyPosition lettuces

        Assert.Equal(true, result.IsSome)
        Assert.Equal(1, result.Value)

    [<Fact>]
    let ``When empty Rabbit list Then chooseBestPrey returns None``() = 
        let lettuces = []

        let result = 
            ChooseBestPreyPosition lettuces

        Assert.Equal(true, result.IsNone)
    
    [<Fact>]
    let ``GivenManyLettuces RabbitChoosesBestLettuceAndEats``() = 
        let bestLettuce = new Rabbit(0, 10.)

        let rabbit = new Rabbit(1, 10.)
        let lettuces = [bestLettuce; new Rabbit(1, 4.); new Rabbit(2, 4.)]

        let (resultRabbit, lettucesResult) = 
            lettuces |> RabbitEatsLettuce rabbit

        Assert.Equal(17., resultRabbit.Food)
        Assert.Equal(3., lettucesResult.Head.Food)

    [<Fact>]
    let ``Given parent rabbit Then will have a child``() = 
        let rabbits = [new Rabbit(0, 80.)]

        let nextGeneration = rabbits |> BreedAnimals
        let parent = nextGeneration.Head
        let child = nextGeneration.Tail.Head

        Assert.Equal(40., parent.Food)
        Assert.Equal(20., child.Food)

    [<Fact>]
    let ``Given no pregnant rabbit Then will not have a child``() = 
        let rabbits = [new Rabbit(0, 30.)]

        let nextGeneration = rabbits |> BreedAnimals
        let rabbit = nextGeneration.Head

        Assert.Equal(30., rabbit.Food)
        Assert.Equal(1, nextGeneration.Length)

    [<Fact>]
    let ``GivenOneRabbitInWolfNeighborhood_WolfEatsWholeRabbit``() = 
        let rabbits = [new Rabbit(0, 30.)]
        let wolf = new Rabbit(0, 30.)

        let (nextWolf, rabbitsNextGeneration) = PredatorEatsPrey wolf rabbits 0 (eat EatRabbitInternal)

        Assert.Equal(true, rabbitsNextGeneration.IsEmpty)
        Assert.Equal(60., nextWolf.Food)

        
