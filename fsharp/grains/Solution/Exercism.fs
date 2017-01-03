module Grains

let square number = 2I ** (number - 1)

let total = 
    [1..64]
    |> List.sumBy square
    