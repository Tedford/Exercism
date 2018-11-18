module Darts

let score (x: double) (y: double): int =
    match x,y with
    | _ when x <= 1.0 && y <= 1.0 -> 10
    | _ when x <= 5.0 && y <= 5.0 -> 5
    | _ when x <= 10.0 && y <= 10.0 -> 1
    | _ -> 0