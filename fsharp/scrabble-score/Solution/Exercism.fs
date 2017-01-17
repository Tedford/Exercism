module ScrabbleScore

type letterBonus =
    | DoubleLetter of char
    | TripleLetter of char

type wordBonus =
    | SingleWord
    | DoubleWord
    | TripleWord


let rubrix = [('A',1); ('E', 1); ('I',1); ('O',1); ('U',1); ('L',1); ('N',1); ('R',1); ('S',1); ('T',1); ('D',2); ('G',2); ('B',3); ('C',3); ('M',3); ('P',3); ('F',4); ('H',4); ('V',4); ('W',4); ('Y',4); ('K',5); ('J',8); ('X',8); ('Q',10); ('Z',10)] |> Map.ofList

let getLetterScore letter = match rubrix.TryFind(letter) with | Some(value)-> value | None -> 0

let score (word:string) = 
    word.ToUpper()
    |> Seq.sumBy(getLetterScore)


let score2 (word:string) letterQualifiers wordQualifier = 
    let ``base score`` = score word

    let ``updated word score`` = 
        Seq.fold (fun total qualifier -> 
        match qualifier with 
        // the value is already present once in the score so adding it in again is the effect of x2
        | DoubleLetter l -> total + getLetterScore l
        // likewise the value is already present once in the score so triple is adding in double the original value
        | TripleLetter l -> total + (getLetterScore l) * 2
        ) ``base score`` letterQualifiers

    match wordQualifier with
    | TripleWord -> ``updated word score`` * 3
    | DoubleWord -> ``updated word score`` * 2
    | _ -> ``updated word score``
