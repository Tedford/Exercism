module BeerSong

let verse number = 
    match number with
    | x when x > 2 -> sprintf "%d bottles of beer on the wall, %d bottles of beer.\nTake one down and pass it around, %d bottles of beer on the wall.\n" x x (x-1)
    | x when x = 2  -> "2 bottles of beer on the wall, 2 bottles of beer.\nTake one down and pass it around, 1 bottle of beer on the wall.\n"
    | x when x = 1 -> "1 bottle of beer on the wall, 1 bottle of beer.\nTake it down and pass it around, no more bottles of beer on the wall.\n"
    | x -> "No more bottles of beer on the wall, no more bottles of beer.\nGo to the store and buy some more, 99 bottles of beer on the wall.\n"

let verses start stop = 
    [start..stop]
    |> List.map(fun line -> verse line)
    |> System.String.Join System.String.Empty

let sing = []