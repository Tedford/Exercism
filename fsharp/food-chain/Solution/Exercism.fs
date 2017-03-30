module FoodChain

let creatures = [|"fly"; "spider"; "bird"; "cat"; "dog"; "goat"; "cow"; "horse"|]

let preamble verse = sprintf "I know an old lady who swallowed a %s." creatures.[verse - 1] |> Some

let surprise = function
    | 2 -> Some("It wriggled and jiggled and tickled inside her.")
    | 3 -> Some("How absurd to swallow a bird!")
    | 4 -> Some("Imagine that, to swallow a cat!")
    | 5 -> Some("What a hog, to swallow a dog!")
    | 6 -> Some("Just opened her throat and swallowed a goat!")
    | 7 -> Some("I don't know how she swallowed a cow!")
    | 8 -> Some("She's dead, of course!")
    | _ as x -> None

let litany verse = 
    let phraseBuilder = function
        | 3 -> "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her."
        | _ as i -> sprintf "She swallowed the %s to catch the %s." creatures.[i-1] creatures.[i-2]

    [2..verse]
    |> List.map (fun n -> phraseBuilder n |> Some)
    |> List.rev

let whileAlive verse =
    seq {
        yield preamble verse
        yield surprise verse
        yield! litany  verse
        yield Some("I don't know why she swallowed the fly. Perhaps she'll die.")
    }
    |> Seq.choose id
    |> String.concat "\n"

let whenDead =
    seq {
        yield preamble 8
        yield Some("She's dead, of course!")
    }
    |> Seq.choose id
    |> String.concat "\n"

let verse number =
    match number with
    | _ as x when x >=1 && x <8 -> whileAlive x
    | 8 -> whenDead
    | _ -> ""
    
let song = ([1..9] |> List.map verse |> String.concat "\n\n").TrimEnd()