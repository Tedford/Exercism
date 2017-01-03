module Accumulate

let accumulate op collection= 
    let rec apply collection'=
        match collection' with
        | [] -> []
        | head :: tail-> (op head) :: apply tail
    apply collection