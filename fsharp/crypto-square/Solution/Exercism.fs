module CryptoSquare

open System.Text.RegularExpressions

let normalizePlaintext input = Regex.Replace(input.ToString().ToLower(),"[^a-z0-9]","")

let size input = 
    let normalized = normalizePlaintext input
    let count = Seq.length normalized
    let calculateSize c r = (c, r, abs ((c * r) - count) < 2)
    [1..count]
    |> Seq.map ( fun c -> [calculateSize c c; calculateSize c (c-1)]  )
    |> Seq.collect id
    |> Seq.filter (fun (_,_,valid)-> valid)
    |> Seq.map (fun (c,_,_) -> c)
    |> Seq.head

let plaintextSegments input = 
    let normalized = normalizePlaintext input

    normalized
    |> Seq.chunkBySize (size normalized)
    |> Seq.toList


let ciphertext input = ""

let normalizeCiphertext input = ""