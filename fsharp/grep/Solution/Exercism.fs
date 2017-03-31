module Grep

open System
open System.IO
open System.Text.RegularExpressions

type flags = 
    | PrintLineNumber
    | PrintFileNameOnly
    | CaseInsensitive
    | ShowCompliment
    | MatchWholeLine

let mapFlags flags = 
    let getOpts = function
    | "-n" -> Some(PrintLineNumber)
    | "-l" -> Some(PrintFileNameOnly)
    | "-i" -> Some(CaseInsensitive)
    | "-v" -> Some(ShowCompliment)
    | "-x" -> Some(MatchWholeLine)
    | _ as x -> None

    flags
    |> Seq.map getOpts
    |> Seq.choose id


let processFile flags pattern lines =

    let checkFlag option = flags |> Seq.contains option

    let re = 
        match checkFlag CaseInsensitive, checkFlag MatchWholeLine with
        | true, true -> sprintf "(?i)^%s$" pattern
        | true, false -> sprintf "(?i)%s" pattern
        | false, true -> sprintf "^%s$" pattern
        | _ -> pattern
        |> Regex
    
    let matcher = if checkFlag ShowCompliment then fun line -> re.IsMatch(line) |> not else fun line -> re.IsMatch(line)

    let filenamePrinter file text = sprintf "%s:%s" file text
    let lineNumberPrinter index text = sprintf "%d:%s" index text
    
    seq  {
        yield! lines
        |> Seq.map (fun (fileCount, file, index, line) -> 
            match matcher line with 
            | true -> 
                match checkFlag PrintFileNameOnly, fileCount > 1 ,checkFlag PrintLineNumber with
                | true, _, _ -> Some(file+ "\n")
                | false, true, true -> Some(line |> lineNumberPrinter index |> filenamePrinter file)
                | false, true, false -> Some( line |> filenamePrinter file)
                | false, false, true -> Some(line |> lineNumberPrinter index)
                | _ -> Some(line)
            | false -> None )
    }
    |> Seq.choose id
    |> Seq.distinct


let grep pattern flags files = 

    let f = mapFlags (flags.ToString().Split([|' '|], StringSplitOptions.RemoveEmptyEntries))
        
    files
    |> List.map ( fun file -> File.ReadAllLines(file) |> Array.mapi (fun index line -> Seq.length files, file, index+1, line+"\n"))
    |> List.map (fun t -> processFile f pattern t)
    |> Seq.concat
    |> String.concat ""

    
