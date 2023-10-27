module TisburyTreasureHunt

let getCoordinate (line: string * string): string = snd line

let convertCoordinate (coordinate: string): int * char = (coordinate[0] |> string |> int, coordinate[1] )
    
let projectLocation (data: string * (int * char) * string) =
    let _, t, _ = data
    sprintf "%d%c" (fst t) (snd t)

let compareRecords (azarasData: string * string) (ruisData: string * (int * char) * string) : bool = 
    let loc1 = snd azarasData
    let loc2 = projectLocation ruisData
    loc1 = loc2

let createRecord (azarasData: string * string) (ruisData: string * (int * char) * string) : (string * string * string * string) =
    let loc2 = projectLocation ruisData
    let loc2Name, _, loc2treasure = ruisData
    match snd azarasData = loc2 with
    | true ->(loc2,loc2Name,loc2treasure,fst azarasData)
    | false -> ("","","","")

