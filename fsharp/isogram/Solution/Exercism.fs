module Isogram

let isogram (word:string) =
    word.ToLower().ToCharArray()
    |> Seq.groupBy id
    |> Seq.map(fun (id, occurance)-> (id, Seq.length occurance))
    |> Seq.filter (fun(id, _) -> System.Char.IsLetter(id))
    |> Seq.filter (fun (_,count)-> count > 1)
    |> Seq.length = 0