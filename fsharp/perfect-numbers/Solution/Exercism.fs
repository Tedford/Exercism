module PerfectNumbers

type NumberType = Perfect | Deficient | Abundant

let classifySum number sum=
    match sum,number with
    | _ when sum = number-> Perfect
    | _ when sum > number-> Abundant
    | _ -> Deficient

let getDivisors number = 
    [1..number - 1]
    |> List.filter ( fun i-> number % i = 0 )

let classify number = 
    getDivisors number
    |> List.sum
    |> classifySum number