module Pangram

let isLetter c = System.Text.RegularExpressions.Regex.IsMatch(c.ToString(),"(?i)[a-z]")

let isPangram (message:string) = 
    message.ToLower()
    |> Seq.filter isLetter
    |> Seq.groupBy id
    |> Seq.length = 26