module Anagram

let reduce (word:string) =
    word.ToLower() 
    |> Seq.groupBy id
    |> Seq.map (fun (letter, occurances)-> (letter, Seq.length occurances))
    |> Map.ofSeq

let anagrams (candidates:string list) (word:string) = 
    let target = reduce word

    candidates
    |> Seq.map (fun w -> (w, reduce w))
    |> Seq.filter (fun (w, token) -> token = target && (System.String.Equals(w, word, System.StringComparison.InvariantCultureIgnoreCase) = false))
    |> Seq.map (fun (word,_)-> word)
    