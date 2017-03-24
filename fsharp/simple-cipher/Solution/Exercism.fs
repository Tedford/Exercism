module SimpleCipher

open System

let Alphabet = "abcdefghijklmnopqrstuvwxyz"
let rand = Random()

let validateKey key =
    if key.ToString().ToLowerInvariant() <> key then failwith "The key must be lowercase"
    if (<) 0 <| (Seq.filter Char.IsNumber key |> Seq.length) then failwith "the key must be all characters"
    if key.ToString().Trim().Length = 0 then failwith "A key must be defined"
    key

let getDistance (c:char) = Alphabet.IndexOf(c) |> int 

let charDistanceFrom (pair:char*char) =
    let (k, x) = pair
    (getDistance x - getDistance k + 26) % 26

let charDistanceTo (pair:char*char) =
    let (k, x) = pair
    (getDistance k + getDistance x) % 26

let lookupByPosition index = Alphabet.[index]

let charToCipher = charDistanceTo >> lookupByPosition
let cipherToChar = charDistanceFrom >> lookupByPosition

let generateKey length =
    let generate = fun () -> rand.Next()
    seq { for i in 1..length -> Alphabet.[generate() % Alphabet.Length] }
    |> String.Concat

let cipherKernel converter text key =
    Seq.zip key text
    |> Seq.map converter
    |> Seq.toArray
    |> String 

let encode key plaintext =  validateKey key |> cipherKernel charToCipher plaintext 

let decode key cipherText = validateKey key |> cipherKernel cipherToChar cipherText 

let encodeRandom text = 
    let key = generateKey 100
    (key, encode key text)