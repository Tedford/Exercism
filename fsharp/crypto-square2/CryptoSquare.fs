module CryptoSquare

open System

let ciphertext input =
    let normalized = input.ToString().ToLower().Replace(" ", "")
    let count = normalized.Length |> float
    let c = Math.Ceiling(count / 2.0) |> int
    let r = Math.Floor(count / 2.0) |> int

    let pad = r*c - normalized.Length

    let normalized = input + new String(' ',pad)

    let chars = 
        seq { for r' in 0 .. r  -> 
                seq { for c' in 0 .. c -> 
                        normalized.[c' + r' * r]
                }   
        }

    ""
    