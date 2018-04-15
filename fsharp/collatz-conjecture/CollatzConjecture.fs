module CollatzConjecture

let even(n) = n / 2

let odd(n) = 3 * n + 1

let next(n: int) = if n % 2 = 0 then even(n) else odd(n)

let steps (number: int): int option =
    match number < 1 with
    | true -> None
    | false -> 
        Seq.unfold(fun state -> if state <= 1 then None else Some(state, next state)) number 
        |> Seq.length 
        |> Some
    