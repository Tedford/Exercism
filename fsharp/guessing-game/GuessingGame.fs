module GuessingGame

let reply = function
    | 42 -> "Correct"
    | 41 | 43 -> "So close"
    | x when x < 41 -> "Too low"
    | _ -> "Too high"    