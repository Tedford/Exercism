module RunLengthEncoding

open System
open System.Text.RegularExpressions

type Encoding = {
    Char: char;
    Count: int;
}

let encode input = 
    input
    |> Seq.fold (fun acc elem -> 
        match acc with
        | head :: tail when head.Char = elem -> {head with Count = head.Count + 1} :: tail
        | _ -> {Char = elem; Count = 1} :: acc
        ) []
    |> List.rev
    |> List.map (fun encoding ->  sprintf "%s%O"  (if encoding.Count = 1 then String.Empty else encoding.Count.ToString()) encoding.Char)
    |> String.concat String.Empty

let decode input = 
    let regex = Regex("(?<count>\d+)?(?<letter>[^\d])", RegexOptions.Compiled)
    String.Join(String.Empty,
        regex.Matches(input)
        |> Seq.map (fun m ->  
            let (defined, count) = m.Groups.["count"].Value |> Int32.TryParse
            let letter = m.Groups.["letter"].Value.[0]
            String(letter, if defined then count else 1)
        ))
    
