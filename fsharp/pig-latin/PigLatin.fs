module PigLatin

let suffix = "ay"

let (|Prefix|_|) (prefix:string) (word:string) = if word.StartsWith(prefix) then Some(word.Substring(prefix.Length)) else None

let rule1 (word:string) = word + suffix

let rule2 (word:string) =
    match word with
    | Prefix "b" rest -> rest + "b" + suffix
    | Prefix "ch" rest -> rest + "ch" + suffix
    | Prefix "c" rest -> rest + "c" + suffix
    | Prefix "d" rest -> rest + "d" + suffix
    | Prefix "f" rest -> rest + "f" + suffix
    | Prefix "g" rest -> rest + "g" + suffix
    | Prefix "h" rest -> rest + "h" + suffix
    | Prefix "j" rest -> rest + "j" + suffix
    | Prefix "k" rest -> rest + "k" + suffix
    | Prefix "l" rest -> rest + "l" + suffix
    | Prefix "m" rest -> rest + "m" + suffix
    | Prefix "n" rest -> rest + "n" + suffix
    | Prefix "p" rest -> rest + "p" + suffix
    | Prefix "qu" rest -> rest + "qu" + suffix
    | Prefix "q" rest -> rest + "q" + suffix
    | Prefix "rh" rest -> rest + "rh" + suffix
    | Prefix "r" rest -> rest + "r" + suffix
    | Prefix "sch" rest -> rest + "sch" + suffix
    | Prefix "squ" rest -> rest + "squ" + suffix
    | Prefix "s" rest -> rest + "s" + suffix
    | Prefix "thr" rest -> rest + "thr" + suffix
    | Prefix "th" rest -> rest + "th" + suffix
    | Prefix "t" rest -> rest + "t" + suffix
    | Prefix "v" rest -> rest + "v" + suffix
    | Prefix "w" rest -> rest + "w" + suffix
    | Prefix "x" rest -> rest + "x" + suffix
    | Prefix "y" rest -> rest + "y" + suffix
    | Prefix "z" rest -> rest + "z" + suffix
    | _ -> word

let toPigLatin (word:string) =
    match word  with
    | Prefix "a" _-> rule1 word
    | Prefix "e" _-> rule1 word
    | Prefix "i" _-> rule1 word
    | Prefix "o" _-> rule1 word
    | Prefix "u" _-> rule1 word
    | Prefix "yt" _-> rule1 word
    | Prefix "xr" _-> rule1 word
    | _ -> rule2 word

let translate (input:string) = 
    input.ToLower().Split(" ")
    |> Seq.map toPigLatin
    |> String.concat " "