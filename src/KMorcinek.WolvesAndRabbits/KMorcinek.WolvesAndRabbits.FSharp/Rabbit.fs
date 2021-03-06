﻿module Rabbit

open FsTypes
open Lettuce

let MaximumFoodEatenFromLettuce = 10.
let RabbitDiesFood = 5.
let RabbitEatsMaxFood = 7.
let RabbitFoodConsumedForDinner = 6.
let RabbitBreedsFood = 40.
let neighbourhoodIndexes = [ -22; -21; -20; -1; 0; 1; 20; 21; 22 ]

let GetNeighbourhood (position) lettuces = 
    lettuces |> List.filter (fun (n : Rabbit) -> 
                    match List.tryFind (fun i -> n.Position + i = position) neighbourhoodIndexes with
                    | None -> false
                    | _ -> true)

let ChooseBestPreyPosition(lettuces : Rabbit List) = 
    if lettuces.IsEmpty then None
    else 
        let bestPrey = lettuces |> List.maxBy(fun prey -> prey.Food)
        Some(bestPrey.Position)

let eat f (prey : Rabbit) (preys, animal, preyPosition) = 
    if prey.Position = preyPosition then f prey (preys, animal, preyPosition)
    else (prey :: preys, animal, preyPosition)

let EatLettuceInternal (lettuce : Rabbit) (preys, (animal : Rabbit), preyPosition) = 
    let foodToEat = min lettuce.Food RabbitEatsMaxFood
    (lettuce.WithUpdatedFood(lettuce.Food - foodToEat) :: preys, new Rabbit(preyPosition, animal.Food + foodToEat), 
     preyPosition)

let EatRabbitInternal (rabbit : Rabbit) (rabbits, (animal : Rabbit), preyPosition) = 
    (rabbits, new Rabbit(preyPosition, animal.Food + rabbit.Food), preyPosition)

let PredatorEatsPrey animal preys preyPosition eatPreyF = 
    let (preys, animal, _) = List.foldBack eatPreyF preys ([], animal, preyPosition)
    (animal, preys)

let PredatorMovesAndEatsOnlyBestPrey eatPreyF (rabbit : Rabbit) preys = 
    let best = 
        preys
        |> GetNeighbourhood rabbit.Position
        |> ChooseBestPreyPosition
    match best with
    | Some(preyPosition) -> PredatorEatsPrey rabbit preys preyPosition eatPreyF
    | None -> (rabbit, preys)

let RabbitEatsLettuce : Rabbit-> Rabbit list -> Rabbit * Rabbit list = PredatorMovesAndEatsOnlyBestPrey(eat EatLettuceInternal)
let WolfEatsRabbit : Rabbit-> Rabbit list -> Rabbit * Rabbit list  = PredatorMovesAndEatsOnlyBestPrey(eat EatRabbitInternal)

let GoThroughPredators howToEatF preys predators = 
    let f (lettuces, rabbits) rabbit = 
        let (nextRabbit, list) = howToEatF rabbit lettuces
        (list, nextRabbit :: rabbits)
    predators |> List.fold f (preys, [])

let AfterDinner animals = 
    animals 
    |> List.map (fun (animal : Rabbit) -> animal.WithUpdatedFood(animal.Food - RabbitFoodConsumedForDinner))
let SurviveNotHungry(preys : Rabbit List) = preys |> List.filter (fun r -> r.Food > RabbitDiesFood)

let Breed previousRabbits (rabbit : Rabbit) = 
    if rabbit.Food > RabbitBreedsFood then 
        rabbit.WithUpdatedFood(rabbit.Food / 2.)
        :: rabbit.WithUpdatedFood(rabbit.Food / 4.) :: previousRabbits
    else rabbit :: previousRabbits

let BreedAnimals(preys : Rabbit List) = preys |> List.fold Breed []
let random = System.Random()

let GetNextTurn(lettuces, rabbits, wolves) = 
    let nextLettuce = NextTurn random.NextDouble lettuces
    let (lettuceAfterRabbits, nextRabbits) = GoThroughPredators RabbitEatsLettuce nextLettuce rabbits
    let (rabbitsAfterWolves, nextWolves) = GoThroughPredators WolfEatsRabbit nextRabbits wolves
    
    let rabbitsWithChildren = 
        rabbitsAfterWolves |> (AfterDinner
                               >> SurviveNotHungry
                               >> BreedAnimals)
    
    let wolvesWithChildren = 
        nextWolves |> (AfterDinner
                       >> SurviveNotHungry
                       >> BreedAnimals)
    
    (lettuceAfterRabbits, rabbitsWithChildren, wolvesWithChildren)
