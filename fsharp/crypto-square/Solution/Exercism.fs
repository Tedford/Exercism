module CryptoSquare

open System
open System.Linq
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


let ciphertext input = 
    let normalized = normalizePlaintext input
    let normalizedLength = Seq.length normalized
    let r = size input
    
    let slices = normalizedLength - (pown r 2) + r
    
    [|for i in [0..(slices-1)] do
        for c in [0..r] do
            yield normalized.ElementAtOrDefault(c * r + i)
    |]
    |> Array.filter Char.IsLetter
    |> String

let normalizeCiphertext input =
    let normalized = normalizePlaintext input
    let normalizedLength = Seq.length normalized
    let r = size input
    let remainder = int (normalizedLength - r * r)

    let r2 = r - remainder
    let changepoint = normalizedLength - (pown r2 2)
    
    let code = ciphertext normalized

    let slices = (List.init (changepoint / r) (fun _ -> r)) @ (List.init ((normalizedLength - changepoint) / r2 ) (fun _ -> r2))
    
    Seq.unfold (fun (s:string,lengths) -> 
        match lengths with 
        | [] -> None
        | x::xs -> Some( (s.Substring(0, x), []), (s.Substring(x), xs))
        ) (code, slices)
    |> Seq.map fst
