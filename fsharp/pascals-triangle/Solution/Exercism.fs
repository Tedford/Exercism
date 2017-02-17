module PascalsTriangle


let triangle row = 
    let extractValue values index =
        match index with
        | -1 -> 0
        | _ when index > List.length values - 1 -> 0
        | x -> values.[x]

    let generateRow previous r =
        [0..r - 1] 
        |> List.map( fun i -> extractValue previous (i-1) + extractValue previous i ) 
    
    List.unfold (fun previous -> if List.length previous = row + 1 then None else Some(previous, generateRow previous (List.length previous + 1)) ) [1]