module LogLevels

let decompose (s:string) =
    match s.Split(": ") with 
    | [|level; message|] -> (level.Trim([|'[';']'|]).ToLower(), message.Trim())
    | _ -> failwith "unable to split"

let message (logLine: string): string = decompose logLine |> snd
    
let logLevel(logLine: string): string = decompose logLine |> fst

let reformat(logLine: string): string = sprintf "%s (%s)" (message logLine) (logLevel logLine)
