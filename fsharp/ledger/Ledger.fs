module Ledger

open System
open System.Globalization
open System.Text

let currencyFormat ="#,#0.00"
let enUS = CultureInfo("en-US")
let nlNL = CultureInfo("nl-NL")

type Entry = { dat: DateTime; des: string; chg: int }

let mkEntry date description change = { dat = DateTime.Parse(date, CultureInfo.InvariantCulture); des = description; chg = change }

let formatLedger currency locale entries =

    let dateFormat = match locale with "en-US" -> "MM\/dd\/yyyy" | "nl-NL" -> "dd-MM-yyyy" | x -> failwithf "Unrecognized locale %s specified" x
    let symbol = match currency with "USD" -> "$" | "EUR" -> "€" | x -> failwithf "Unrecognized currency %s specified" x
    let header = match locale with "en-US" -> "Date       | Description               | Change       " | "nl-NL" -> "Datum      | Omschrijving              | Verandering  " | x -> failwithf "Recognized locale %s specified" x
    
    let sb = StringBuilder()

    let positiveEntry (c:float) = 
        match locale with 
        | "en-US" -> sb.Append((sprintf "%s%s " symbol (c.ToString(currencyFormat, enUS))).PadLeft(13)) |> ignore
        | "nl-NL" -> sb.Append((sprintf "%s %s " symbol (c.ToString(currencyFormat, nlNL))).PadLeft(13)) |> ignore
        | x -> failwithf "Unexpected locale %s specified" x

    let negativeEntry (c:float) = 
        match locale with
        | "en-US" -> sb.Append((sprintf "(%s%s)" symbol (c.ToString(currencyFormat, enUS).Substring(1))).PadLeft(13)) |> ignore
        | "nl-NL"-> sb.Append((sprintf "%s %s" symbol (c.ToString(currencyFormat, nlNL))).PadLeft(13)) |> ignore
        | x -> failwithf "Unexpected locale %s specified" x

    sb.Append(header) |> ignore

    for x in List.sortBy (fun x -> x.dat, x.des, x.chg) entries do
        
        sb.AppendFormat("\n{0} | {1} | ", x.dat.ToString(dateFormat),  if x.des.Length > 25 then x.des.[0..21] + "..." else x.des.PadRight(25) ) |> ignore

        let c = float x.chg / 100.0

        if c < 0.0 then
            negativeEntry c
        else
            positiveEntry c

    sb.ToString()
