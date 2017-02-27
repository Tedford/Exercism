module PrimeFactors


let primeFactorsFor number = 
    let rec reduce acc factor remainder =
        match factor > remainder, remainder % factor with
        | true, _ -> acc
        | _, 0L -> reduce (factor :: acc) factor (remainder / factor)
        | _ -> reduce acc (factor + 1L) remainder
    reduce [] 2L number
    |> List.rev