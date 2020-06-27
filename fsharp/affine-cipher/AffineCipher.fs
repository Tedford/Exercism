module AffineCipher
open System

let m = 26
let alphabet = [|'a'..'z'|]
let letterIndex c = (int c) - (int 'a')

let getMMI a m =
    [|1 .. m|] 
    |> Array.filter (fun x -> (a * x) % m = 1) 
    |> Array.tryHead 
    |> function Some(x) -> x | _ -> 1


let assertCoprime a =
    let rec gcd x y =
        if y = 0 then x
        else gcd y (x % y)
    
    if ( (gcd a m) <> 1 ) then raise (ArgumentException("ERROR: a and m must be coprime")) 

let decode a b cipheredText = 
    assertCoprime a
    let mmi = getMMI a m

    let decipher y =
        match Char.IsLetter y with
        | true -> 
            let yIndex = letterIndex y
            let index = 
                match mmi * ( yIndex - b) % m with
                | x when x <  0 -> m + x
                | x -> x
            alphabet.[index]
        | false -> y

    cipheredText
    |> Seq.filter Char.IsLetterOrDigit
    |> Seq.map decipher
    |> String.Concat

let encode a b (plainText:string) = 
    assertCoprime a
    let encipher x = 
        match Char.IsLetter x with
        | true -> alphabet.[(a * (letterIndex x) + b) % m]
        | false -> x

    String.Join( " ", 
        plainText.ToLower()
        |> Seq.filter Char.IsLetterOrDigit
        |> Seq.map encipher
        |> Seq.chunkBySize 5
        |> Seq.map String.Concat
    )