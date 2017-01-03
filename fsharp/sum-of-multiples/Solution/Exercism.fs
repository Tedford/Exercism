module SumOfMultiples

let isMultiple factors number =
    let multiples = 
        factors
        |> List.filter ( fun value->number % value = 0)
    multiples.Length > 0

let sumOfMultiples factors limit =
    [1..limit-1]
    |> List.map (fun factor -> if (isMultiple factors factor) then factor else 0) 
    |> List.sum
