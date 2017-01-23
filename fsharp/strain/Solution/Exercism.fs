module Seq

let accumulate predicate sequence = 
    let l = sequence |> Seq.toList
    let rec apply result collection' =
        match collection' with
        | [] -> result
        | head :: tail when predicate head -> apply (head :: result) tail
        | _ :: tail -> apply result tail
    apply [] l
    |> List.rev

let keep predicate (sequence: 'a seq)  = 
    accumulate predicate sequence

let discard predicate (sequence: 'a seq) =
    let negated = predicate >> not
    accumulate negated sequence


