module Rabbit

open Types
open Lettuce

let MaximumFoodEatenFromLettuce = 10.
let RabbitDiesFood = 5.
let RabbitEatsMaxFood = 7.
let RabbitFoodConsumedForDinner = 6.
let RabbitBreedsFood = 40.

let neighbourhoodIndexes = [-22;-21;-20;-1;0;1;20;21;22]

let GetNeighbourhood (position) lettuces = 
    lettuces |> List.filter (fun (n : Rabbit) -> 
       match List.tryFind (fun i ->  n.Position + i = position) neighbourhoodIndexes with
       | None -> false
       | _ -> true
    )

let AddHim (max, position) (lettuce : Rabbit) = 
    if lettuce.Food >= max then (lettuce.Food, lettuce)
    else (max, position)

let ChooseBestPreyPosition (lettuces : Rabbit List) = 
    if lettuces.IsEmpty then None
    else 
        let (maxValue, lettuce) = lettuces |> List.fold AddHim (System.Double.NegativeInfinity, lettuces.Head)
        if maxValue = System.Double.NegativeInfinity then None
        else Some(lettuce.Position)

let eat f (prey : Rabbit) (preys, animal, preyPosition) = 
    if prey.Position = preyPosition then f prey (preys, animal, preyPosition)
    else (prey :: preys, animal, preyPosition)

let EatLettuceInternal (lettuce:Rabbit) (preys, (animal:Rabbit), preyPosition) =
    let foodToEat = min lettuce.Food RabbitEatsMaxFood
    (new Rabbit(lettuce.Position, lettuce.Food - foodToEat) :: preys, 
        new Rabbit(preyPosition, animal.Food + foodToEat), preyPosition)

let EatRabbitInternal (rabbit:Rabbit) (rabbits, (animal:Rabbit), preyPosition) =
    (rabbits, new Rabbit(preyPosition, animal.Food + rabbit.Food), preyPosition)

let PredatorEatsPrey animal preys preyPosition eatPreyF = 
    let (preys, animal, _) = List.foldBack eatPreyF preys ([], animal, preyPosition)
    (animal, preys)

let PredatorMovesAndEatsOnlyBestPrey eatPreyF (rabbit:Rabbit) preys = 
    let best = 
        preys
        |> GetNeighbourhood rabbit.Position
        |> ChooseBestPreyPosition
    match best with
    | Some(preyPosition) -> PredatorEatsPrey rabbit preys preyPosition eatPreyF
    | None -> (rabbit, preys)

let RabbitEatsLettuce = PredatorMovesAndEatsOnlyBestPrey (eat EatLettuceInternal)
let WolfEatsRabbit = PredatorMovesAndEatsOnlyBestPrey (eat EatRabbitInternal)

let GoThroughPredators howToEatF preys predators =
    let temp (lettuces, rabbits) rabbit =
        let (nextRabbit, list) = howToEatF rabbit lettuces
        (list, nextRabbit:: rabbits)
    predators 
    |> List.fold temp (preys, [])

let AfterDinner animals =
    animals
    |> List.map (fun (animal:Rabbit) -> new Rabbit(animal.Position, animal.Food - RabbitFoodConsumedForDinner))

let SurviveNotHungry (preys : Rabbit List) = preys |> List.filter (fun r -> r.Food > RabbitDiesFood)

let Breed previousRabbits (rabbit : Rabbit) = 
    if rabbit.Food > RabbitBreedsFood then 
        (new Rabbit(rabbit.Position, rabbit.Food / 2.)) 
        :: (new Rabbit(rabbit.Position, rabbit.Food / 4.)) :: previousRabbits
    else rabbit :: previousRabbits

let BreedAnimals (preys : Rabbit List) = preys |> List.fold Breed []

let GetNextTurn (lettuces, rabbits, wolves) =
    let nextLettuce = NextTurn lettuces

    let (lettuceAfterRabbits, nextRabbits) = GoThroughPredators RabbitEatsLettuce nextLettuce rabbits 
    let (rabbitsAfterWolves, nextWolves) = GoThroughPredators WolfEatsRabbit nextRabbits wolves 

    let rabbitsWithChildren =
        rabbitsAfterWolves
        |> AfterDinner
        |> SurviveNotHungry
        |> BreedAnimals 

    let wolvesWithChildren = 
        nextWolves
        |> AfterDinner
        |> SurviveNotHungry
        |> BreedAnimals 

    (lettuceAfterRabbits, rabbitsWithChildren, wolvesWithChildren)

let Create =
    let lettuces = Lettuce.createLettuceFieldFromSize 10
    let rabbits = [new Rabbit(1, 52.);
                    new Rabbit(0, 10.);
                    new Rabbit(1, 10.);
                    new Rabbit(2, 10.);
                    new Rabbit(3, 10.);
                    new Rabbit(5, 10.);
                    new Rabbit(0, 9.);
                    new Rabbit(-5, 9.);
                    new Rabbit(-6, 9.);
                    new Rabbit(-9, 9.);
                    new Rabbit(-28, 9.);
                    new Rabbit(-27, 9.);
                    new Rabbit(-26, 9.);
                    new Rabbit(-25, 9.);
                    new Rabbit(-20, 9.);
                    new Rabbit(-33, 9.);
                    new Rabbit(-66, 9.);
                    new Rabbit(-29, 9.);
                    new Rabbit(-44, 9.);
                    new Rabbit(11, 9.);
                    new Rabbit(-49, 9.);
                    new Rabbit(11, 9.);
                    new Rabbit(13, 9.);
                    new Rabbit(19, 9.);
                    new Rabbit(26, 9.);
                    new Rabbit(29, 9.);
                    new Rabbit(33, 9.);
                    new Rabbit(38, 9.);
                    new Rabbit(49, 9.);
                    new Rabbit(55, 9.);
                    new Rabbit(88, 9.);
                    new Rabbit(81, 9.);
                    new Rabbit(82, 9.);
                    new Rabbit(85, 9.);
                    new Rabbit(66, 9.);
                    new Rabbit(60, 9.);
                    new Rabbit(88, 9.);
                    new Rabbit(87, 9.);
                    new Rabbit(86, 9.);
                    new Rabbit(85, 9.);
                    new Rabbit(84, 9.)]
    let wolves = [new Rabbit(8, 52.);
                    new Rabbit(66, 60.); 
                    new Rabbit(99, 60.); 
                    new Rabbit(-13, 60.); 
                    new Rabbit(-19, 60.); 
                    new Rabbit(-45, 60.); 
                    new Rabbit(37, 60.); 
                    new Rabbit(54, 60.); 
                    new Rabbit(-54, 60.); 
                    new Rabbit(-50, 60.)]
    (lettuces, rabbits, wolves)