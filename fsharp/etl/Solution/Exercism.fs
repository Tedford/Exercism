module ETL

let transform (scores: Map<int,string list> )=
    scores
    |> Seq.collect( fun mapping -> mapping.Value |> Seq.map( fun letter-> (letter.ToLower(), mapping.Key) ) )
    |> Map.ofSeq