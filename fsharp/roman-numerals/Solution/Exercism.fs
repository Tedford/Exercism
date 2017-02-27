module RomanNumeral


let toRomanDigit valueSet digit =
    let i,v,x = valueSet
    match digit with
    | '1' -> i
    | '2' -> sprintf "%s%s" i i
    | '3' -> sprintf "%s%s%s" i i i
    | '4' -> sprintf "%s%s" i v
    | '5' -> v
    | '6' -> sprintf "%s%s" v i
    | '7' -> sprintf "%s%s%s" v i i
    | '8' -> sprintf "%s%s%s%s" v i i i
    | '9' -> sprintf "%s%s" i x
    | _ -> ""


let toRoman arabic =
    let asWord = sprintf "%d" arabic
    let length = Seq.length asWord    
    asWord
    |> Seq.mapi (fun index digit ->  
        let place = length - index - 1
        match place with
        | 0 -> toRomanDigit ("I","V","X") digit
        | 1 -> toRomanDigit ("X","L","C") digit
        | 2 -> toRomanDigit ("C","D","M") digit
        | _ -> toRomanDigit ("M","M","M") digit
        )
    |> String.concat ""
    
        
    