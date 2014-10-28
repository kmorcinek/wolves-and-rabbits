module Lettuce

open FsTypes

let maxFoodOnLettuce = 100.
let fieldSize = [ 0..8 ]
let createLettuceField = fieldSize |> List.map (fun n -> new Rabbit(n, 2.))

let createLettuceFieldFromSize size = 
    let length = 2 * size + 1
    let range = (length * length - 1) / 2
    [ -range..range ] |> List.map (fun n -> new Rabbit(n, 12.))

let NextTurn howMuchGrow list = 
    let grow howMuchGrow (lettuce : Rabbit) = 
        let updatedFood = lettuce.Food + 1. + howMuchGrow()
        new Rabbit(lettuce.Position, min updatedFood maxFoodOnLettuce)
    list |> List.map (grow howMuchGrow)

let printLettuce (items : Rabbit List) = 
    for item in items do
        printf "\t%d" (int (item.Food))
    printfn ""

let printRabbits (items : Rabbit List) = 
    for i in fieldSize do
        match List.tryFind (fun (n : Rabbit) -> n.Position = i) items with
        | Some(item) -> printf "\t%d" (int (item.Food))
        | None -> printf "\t"
    printfn ""

let printRabbitsWithPositions (items : Rabbit List) = 
    for item in items do
        printf "\t%d(%d)" (int (item.Food)) item.Position
    printfn ""
