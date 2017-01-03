module RNATranscription

let complement =
    function
    | 'G' -> 'C'
    | 'C' -> 'G'
    | 'A' -> 'U'
    | 'T' -> 'A'
    | _ -> invalidOp "Not a supported nucleotide"

let toRna = String.map complement
