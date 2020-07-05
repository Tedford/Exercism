module Markdown

open System.Text
open System.Text.RegularExpressions

let encodeStyle tag glyph line = Regex.Replace(line, sprintf "%s(.+?)%s" glyph glyph, sprintf "<%s>$1</%s>" tag tag)
    
let rec parse (markdown: string) =

   let html = StringBuilder()

   let append (s:string) = html.Append(s) |> ignore
   
   if markdown.Split('\n') 
      |> Seq.fold ( fun isList line ->  
           match line.[0] with 
           | '*' -> 
               if not isList then  
                   append "<ul>"
           
               line.[2..] |> encodeStyle "strong" "__" |> encodeStyle "em" "_" |> sprintf "<li>%s</li>" |> append
               true
            | '#' ->
               let header = line.IndexOf(' ')
               append (sprintf "<h%d>%s</h%d>" header line.[(header + 1)..] header)
               isList
            | _ ->
               if isList then  
                   append "</ul>"
               
               line |> encodeStyle "strong" "__" |> encodeStyle "em" "_" |> sprintf "<p>%s</p>" |> append
               false
       ) false
    then 
       append "</ul>"

   html.ToString()