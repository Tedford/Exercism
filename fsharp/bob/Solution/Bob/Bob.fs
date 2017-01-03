module Bob
open System
open System.Text.RegularExpressions

let (|RegexMatch|_|) pattern input =
    match Regex.IsMatch(input, pattern) with
    | true -> Some true
    | false -> None
    
let hey message =
    match message with
    | RegexMatch "!$|^(?:[A-Z]+\s*)+[!.?]?$" message -> "Whoa, chill out!"
    | RegexMatch "\?$" message -> "Sure."
    | RegexMatch "^\s*$" message ->"Fine. Be that way!"
    | _ -> "Whatever." 