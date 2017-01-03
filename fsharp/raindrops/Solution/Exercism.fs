module Raindrops
open System

let getFactors number =
    [1..number]
    |> Seq.filter (fun n -> number % n = 0)

let transcribe factor  =
    match factor with
    | 3 -> "Pling"
    | 5 -> "Plang"
    | 7 -> "Plong"
    | _ -> ""

let convert number = 
    let sound = 
        getFactors number
        |> Seq.map transcribe
        |> String.Concat
    
    match sound with
    | "" -> sprintf "%d" number
    | _ -> sound
