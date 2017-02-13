module Matrix


type Matrix = { Rows:int; Cols:int; Elements: int array }

let fromString (encoded:string) = 
    let decodeRow (s:string) = s.Split([|' '|]) |> Array.map int
    let rows = encoded.Split([|'\n'|])
    let rowRank = Array.length rows
    let colRank = Array.head rows |> decodeRow |> Array.length
    let elements = rows |> Array.map decodeRow |> Array.collect id
    { Rows = rowRank; Cols = colRank; Elements= elements}
    
let rows matrix = Array.chunkBySize matrix.Cols matrix.Elements

let cols matrix = 
    let output = 
        [|1..matrix.Cols|]
        |> Array.map (fun i -> Array.init matrix.Rows id)

    let getCoordinates index matrix =
        let column = index  % matrix.Cols
        let row = index / matrix.Cols
        (row, column)

    let updateOutput input (target:int[][]) coordinates index =
        let (row,column) = coordinates
        target.[column].[row] <- input.Elements.[index]

    let processElement element =
        let index = element - 1
        let coordinates = getCoordinates index matrix
        updateOutput matrix output coordinates index

    [1..Array.length matrix.Elements]
    |> List.iter processElement

    output
    
