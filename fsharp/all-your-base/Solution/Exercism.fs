module AllYourBase

let toBase10 currentBase digits = 
    digits 
    |> List.rev 
    |> List.mapi (fun place value -> (pown currentBase place) * value ) 
    |> List.sum

let toBaseN targetBase value =
    match targetBase with
    | 10 -> (sprintf "%d" value) |> Seq.map (fun c -> int(c.ToString())) |> Seq.toList
    | _ -> 
        List.unfold(fun v->
            if v = 0
            then
                None 
            else 
                let quotient = v / targetBase
                let remainder = v % targetBase
                Some(remainder, quotient)
            )  value
        |> List.rev

let rebase base0 input baseN = 
    match input |> Seq.forall (fun e -> e > -1 && e < base0) && Seq.length input > 0 && base0 > 1 && baseN > 1 with
    | true ->  
        match Seq.sum input with 
        | 0 -> Some([0])
        | _ -> input |> toBase10 base0 |> toBaseN baseN |> Some
    | _ -> None


    