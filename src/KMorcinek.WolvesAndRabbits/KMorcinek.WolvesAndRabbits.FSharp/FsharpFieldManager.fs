module FsharpFieldManager

open Types
open Lettuce
open Rabbit
open System

let GetNextAndPrint (preys, predators, wolves) i =
        printLettuce preys 
        printRabbits predators 
        printRabbits wolves 
        
        let (nextPreys, nextPredators, nextWolves) = GetNextTurn (preys, predators, wolves)
        Console.ReadLine() |> ignore
        (nextPreys, nextPredators, nextWolves)

let lettuces = createLettuceField
let rabbits = [new Rabbit(1, 52.)]
let wolves = [new Rabbit(8, 52.)]
