module RotationalCipher
open System
let buildCipher offset initial =
    [0..25]
    |> List.map (fun n -> char ((n + offset) % 26  + int initial))
    |> List.map char
let charToIndex initial c = int c - int initial 
let capIndex = charToIndex 'A'
let lowerIndex = charToIndex 'a'
let rotate shiftKey text = 
    let lowerCipher = buildCipher shiftKey 'a'
    let capCipher = buildCipher shiftKey 'A'
    
    text
    |> Seq.map (fun c -> 
        match Char.IsLetter(c), Char.IsUpper(c) with
        | true, true -> capCipher.[capIndex c]
        | true, false -> lowerCipher.[lowerIndex c]
        | false, _ -> c
        )
    |> Seq.toList
    |> String.Concat