module RobotName
open System

let Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
let Digits = "0123456789"
let rand = Random()
let generate = fun () -> rand.Next()

let generateName seed= 
    seq {for i in 1..5 -> 
            let index = generate()
            let source = if i < 3 then Alphabet else Digits
            source.[index % source.Length]
    }
    |> String.Concat


type Robot = {Name:string}
let mkRobot value= {Name = generateName value}
let reset (robot:Robot) = {Name = generateName robot}
let name (robot:Robot) = robot.Name