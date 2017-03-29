module ScaleGenerator

open System

type Key = 
| Major
| Minor
| NonDiatnoic

type Interval =
| Whole 
| Half 
| Augmented


let mapInterval = function
    | 'M' -> Whole
    | 'm' -> Half
    | 'A' -> Augmented
    | _ -> failwith "Unknown step detected"


let getMajorWholeStep = function
    | "Ab" -> "Bb"
    | "A" -> "B"
    | "B" -> "C#"
    | "Bb" -> "C"
    | "C" -> "D"
    | "C#" -> "D#"
    | "Db" -> "Eb"
    | "D" -> "E"
    | "D#" -> "F"
    | "Eb" -> "F"
    | "E" -> "F#"
    | "F" -> "G"
    | "F#" -> "G#"
    | "G" -> "A"
    | "G#" -> "Ab"
    | _ as x -> failwith (sprintf "getMajorWholeStep - %A is an unexpected note" x)

let getMajorHalfStep = function
    | "Bb" -> "C"
    | "B" -> "C"
    | "C" -> "Db"
    | "D" -> "D#"
    | "E" -> "F"
    | "F" -> "F#"
    | "F#" -> "G"
    | "G#" -> "A"
    | "G" -> "Ab"
    | _ as x -> failwith (sprintf "getMajorHalfStep - %A is an unexpected note" x)


let getAugmentedStep = function
    | "Bb" -> "Db"
    | "C#" -> "E"
    | "F#" -> "A"
    | "G#" -> "B"
    | _ as x -> failwith (sprintf "getAugmentedStep - %A is an unexpected note" x)


let getMinorWholeStep = function
    | "Ab" -> "Bb"
    | "A" -> "B"
    | "B" -> "C#"
    | "Bb" -> "C"
    | "C" -> "D"
    | "C#" -> "D#"
    | "Db" -> "Eb"
    | "D" -> "E"
    | "Eb" -> "F"
    | "E" -> "F#"
    | "F" -> "G"
    | "F#" -> "G#"
    | "Gb" -> "Ab"
    | "G" -> "A"
    | _ as x -> failwith (sprintf "getMinorWholeStep - %A is an unexpected note" x)

let getMinorHalfStep = function
    | "A" -> "Bb"
    | "B" -> "C"
    | "C" -> "Db"
    | "C#" -> "D"
    | "Db" -> "D"
    | "D#" -> "E"
    | "E" -> "F"
    | "F" -> "Gb"
    | "G" -> "Ab"
    | "G#" -> "A"
    | _ as x -> failwith (sprintf "getMinorHalfStep - %A is an unexpected note" x)


let getNonDiatonicWholeStep = function
    | "A" -> "B"
    | "B" -> "C#"
    | "C#" -> "D#"
    | "D" -> "E"
    | "D#" -> "F"
    | "E" -> "F#"
    | "F" -> "G"
    | "G" -> "A"
    | _ as x -> failwith (sprintf "getNonDiatonicWholeStep - %A is an unexpected note" x)


let getNonDiatonicHalfStep = function
    | "A" -> "Bb"
    | "Db" -> "D"
    | "E" -> "F"
    | "F" -> "F#"
    | "F#" -> "G"
    | "G" -> "G#"
    | _ as x -> failwith (sprintf "getNonDiatonicHalfStep - %A is an unexpected note" x)

let toString = function
    | head :: tail -> head.ToString().ToUpper() + (tail |> Array.ofList |> String)
    | _ -> failwith "Empty string provided"

let determineKey intervals = function
    | x when intervals.ToString().Contains("A") -> toString x, NonDiatnoic
    | x :: xs when Char.IsLower(x) -> toString (x :: xs), Minor
    | _ as x -> toString x, Major

let pitches (startingNote:string) intervals= 

    let note, key = startingNote |> Seq.toList |> determineKey intervals

    let getWholeStep = match key with Major -> getMajorWholeStep | Minor -> getMinorWholeStep | NonDiatnoic -> getNonDiatonicWholeStep
    let getHalfStep =  match key with Major -> getMajorHalfStep | Minor -> getMinorHalfStep | NonDiatnoic -> getNonDiatonicHalfStep

    let scale = 
        intervals 
        |> Seq.map mapInterval
        |> Seq.fold ( fun s step -> 
            let previous = Seq.head s
            let next = 
                previous |> 
                match step with
                | Whole -> getWholeStep 
                | Half -> getHalfStep 
                | Augmented -> getAugmentedStep 
            next :: s
            ) [note]

    // since we are not looping around to the top of the scale drop the last transition
    scale |> Seq.tail |> Seq.rev