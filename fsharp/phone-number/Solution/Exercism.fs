module PhoneNumber

let IsNumber value =
    let isDefined =not( System.String.IsNullOrWhiteSpace(value))  
    let firstDigit = if isDefined then value.[0] else 'z'
    match isDefined, value.Length, firstDigit with
    | true, 10, _-> Some(value)
    | true, 11, '1' -> Some(value.Substring(1))
    | _ -> None

let parsePhoneNumber input =
    input 
    |> Seq.filter (fun c -> System.Char.IsDigit(c))
    |> System.String.Concat
    |> IsNumber
