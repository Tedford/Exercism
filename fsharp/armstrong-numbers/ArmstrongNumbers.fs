module ArmstrongNumbers
let toFloat c = c.ToString() |> float

let isArmstrongNumber (number: int): bool = 
    let s:string = sprintf "%d" number
    let power = s.Length |> float
    
    let sum = s |> Seq.sumBy (fun c -> System.Math.Pow(toFloat c, power))
    
    number = (sum |> int)

