module Sieve


let primesUpTo limit = 
    let sieve = Array.init limit (fun i -> i+1,true)
    for i in 1 .. limit - 1 do
        for j in i+1 .. limit - 1 do
            if snd sieve.[j] && (j+1) % (i+1)= 0 then
                sieve.[j] <- fst sieve.[j],false

    sieve
    |> Array.filter (fun (value, prime) -> prime && value > 1)
    |> Array.map fst
