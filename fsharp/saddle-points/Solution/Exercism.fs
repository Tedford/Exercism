module SaddlePoints


let saddlePoints (matrix: int list list) = 
    let rowRank =  (List.length matrix) - 1
    let colRank = (matrix |> List.head |> List.length) - 1
    let rowMax = matrix |> List.map List.max 
    let colMin= [0 .. colRank] |> List.map( fun c -> [for r in 0 .. rowRank -> matrix.[r].[c]] |> List.min)

    [for r in [0..rowRank] do
        for c in [0..colRank] do
            if matrix.[r].[c] = rowMax.[r] && matrix.[r].[c] = colMin.[c] then yield (r,c)]

