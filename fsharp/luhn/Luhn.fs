module Luhn

open System

let valid number = 

    let doubleDigit element ``double``=
        match ``double``, element * 2 > 9 with
        | true, true -> element * 2 - 9
        | true, false -> element * 2
        | _ -> element

    let sum,_ = 
        number
        |> Seq.filter Char.IsDigit
        |> Seq.map (fun c -> Int32.Parse(c.ToString()))
        |> Seq.rev
        |> Seq.fold (fun (total,``double``) elem -> ( (total + doubleDigit elem ``double``), not ``double``)) (0,false)

    let allowable, count = 
        number |> Seq.fold(fun (valid,count) elem -> (valid && (Char.IsDigit(elem) || Char.IsWhiteSpace(elem)), count + if Char.IsDigit(elem) then 1 else 0)) (true,0)        

    sum % 10 = 0 && allowable && count > 1
    