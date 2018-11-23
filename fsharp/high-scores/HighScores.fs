module HighScores

let scores (values: int list): int list = values

let latest (values: int list): int = values |> List.rev |> List.head

let highest (values: int list): int = 
    values 
    |> List.sortByDescending id
    |> List.head

let top  (values: int list): int list = values |> List.sortByDescending id |> List.truncate 3

let report (values: int list): string =
    let highScore = highest values
    let latestScore = latest values

    if latestScore >= highScore then
        sprintf "Your latest score was %d. That's your personal best!" highScore
    else 
       sprintf "Your latest score was %d. That's %d short of your personal best!" latestScore (highScore-latestScore)