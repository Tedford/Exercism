module Atbash
open System

let encode plaintext = 
    let cipherAlphabet = [0..25] |> List.map (fun i-> int 'z' - i |> char) |> Array.ofList

    let encodeChar = function
        | d when Char.IsDigit d -> d
        | l when Char.IsLetter l -> cipherAlphabet.[int l - int 'a']
        | _ -> failwith "Invalid input"

    plaintext.ToString().ToLower()
    |> Seq.filter Char.IsLetterOrDigit
    |> Seq.map encodeChar
    |> Seq.chunkBySize 5
    |> Seq.map String
    |> String.concat " "