module SpiralMatrix

let spiralMatrix size = 

    let matrix = Array2D.create size size 0

    let mutable pos = 0
    let mutable count = size
    let mutable value = -size
    let mutable sum = -1

    while count > 0 do  
        value <- -1 * value / size
        [|1..count|]
        |> Array.iter (fun _ ->
            sum <- sum + value
            pos  <- pos + 1
            matrix.[sum / size, sum % size] <- pos
            )

        value <- value * size
        count <- count - 1

        [|1..count|]
        |> Array.iter (fun _ ->
            sum <- sum + value
            pos <- pos + 1
            matrix.[sum / size, sum % size] <- pos
        )
    
    [1..size ]
    |> List.map (fun row -> matrix.[row-1,*] |> Array.toList)