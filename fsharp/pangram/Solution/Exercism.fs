module Pangram

let isLetter c = System.Text.RegularExpressions.Regex.IsMatch(c.ToString(),"(?i)[a-z]")

let isPangram (message:string) = 
    let contents =
        message.ToCharArray()
        |> Seq.filter isLetter
        |> Seq.groupBy (fun c -> c)
    contents |> Seq.length > 25