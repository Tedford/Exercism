module ParallelLetterFrequency

open System


let mergeResults (results:seq<char*int> []) =
    results
    |> Seq.collect id
    |> Seq.groupBy fst
    |> Seq.map (fun (key, counts) -> (key, counts |> Seq.sumBy snd ))
    |> Map.ofSeq


let analyzeText phrase =
    phrase.ToString().ToLowerInvariant()
    |> Seq.filter Char.IsLetter
    |> Seq.groupBy id
    |> Seq.map (fun (key, values)-> (key, Seq.length values))

let asyncAnalyzeText phrase =
    async { return analyzeText phrase }

let frequency phrases =
    phrases
    |> List.map asyncAnalyzeText
    |> Async.Parallel
    |> Async.RunSynchronously
    |> mergeResults