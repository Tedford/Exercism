module NucleoTideCount

let count nucleotide strand = 
    match nucleotide with
    | 'A' -> ()
    | 'C' -> ()
    | 'G' -> ()
    | 'T' -> ()
    | _ -> raise (System.Exception(sprintf "%A unknown nucleotide detected" nucleotide))

    strand
    |> Seq.filter (fun n-> n =nucleotide ) 
    |> Seq.length

let nucleotideCounts strand = 
    ['A';'C';'G';'T']
    |> Seq.map ( fun nucleotide -> nucleotide, count nucleotide strand )
    |> Map.ofSeq