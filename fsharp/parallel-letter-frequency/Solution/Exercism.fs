module ParallelLetterFrequency

open System


let mergeResults (results:seq<char> []) =
    results
    |> Seq.collect id
    |> Seq.groupBy id
    |> Seq.map (fun (key, occurances) -> (key, Seq.length occurances))
    |> Map.ofSeq


let analyzeText phrase =
    phrase.ToString().ToLowerInvariant()
    |> Seq.filter Char.IsLetter

let asyncAnalyzeText phrase =
    async { return analyzeText phrase }

let frequency phrases =
    phrases
    |> List.map asyncAnalyzeText
    |> Async.Parallel
    |> Async.RunSynchronously
    |> mergeResults