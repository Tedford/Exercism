module DifferenceOfSquares

let square num = num ** 2.0

let squareOfSums (num:int) = 
    let max = float num 
    [1.0..max]  
    |> List.sum
    |> square

let sumOfSquares num = 
    let max = float num
    [1.0..max]
    |> List.sumBy square

let difference num = (squareOfSums num)- (sumOfSquares num)
