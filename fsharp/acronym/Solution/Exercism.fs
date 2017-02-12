module Acronym

open System.Text.RegularExpressions

let acronym phrase = 
    let regex = Regex(@"\b[A-Z]+\b|\w[a-z]+")
    regex.Matches(phrase)
    |> Seq.cast<Match>
    |> Seq.map (fun m-> m.Value.ToUpper().[0])
