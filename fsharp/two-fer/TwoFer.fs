module TwoFer

let name (input: string option): string = 
    match input with
    | None -> "One for you, one for me."
    | Some(X) -> sprintf "One for %s, one for me." X
