module IsbnVerifier
open System


let encode c = 
    match Char.IsDigit(c), c with
    | true,_ -> Int32.Parse(c.ToString())
    | false, 'x' ->  10
    | false, _ -> failwith "invalid encoding detected"

let isValid isbn = 
    let isbn'= isbn.ToString().Replace("-","").ToLower()

    match isbn'.Length with
    | 10 ->
        try
            let sum = 
                isbn' 
                |> Seq.mapi (fun index digit -> 
                    if digit = 'x' && index <> 9 then
                        failwith "The check digit must be last"
                    (10 - index) * encode digit) 
                |> Seq.sum
            sum % 11 = 0
        with | _ -> false 
    | _ -> false    
