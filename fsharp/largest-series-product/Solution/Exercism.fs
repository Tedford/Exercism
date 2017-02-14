module LargestSeriesProduct

let largestProduct encodedDigits window = 
    let digits = encodedDigits |> Seq.map (fun c-> int (c.ToString())) |> Seq.toArray
    let max = Seq.length digits - window
    [0..max]
    |> List.map (fun i -> 
        let endI = i + window - 1
        digits.[i..endI] |> Array.fold (fun acc digit -> acc * digit) 1
        )
    |> List.max