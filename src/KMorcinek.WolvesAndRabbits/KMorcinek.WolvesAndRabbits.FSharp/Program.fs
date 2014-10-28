module Books

open System
open FsTypes
open Lettuce
open Rabbit
open FsharpFieldManager

[<EntryPoint>]
let main argv = 
    Console.WriteLine("Press any key")

    let iter = [0..49]

    iter
    |> List.fold GetNextAndPrint (lettuces, rabbits, wolves)
    |> ignore

    Console.ReadLine() |> ignore

    // return the exit code
    0 
    
    // Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.


     

