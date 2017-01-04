module Accumulate

let accumulate op collection= 
    let rec apply result collection'=
        match collection' with
        | [] -> result
        | head :: tail-> apply (op head :: result) tail
    apply [] collection
    |> List.rev