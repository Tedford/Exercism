module Series

let slices (data:string) length = 
    let digits = data.ToCharArray() |> Array.toList |>  List.map (fun c->System.Int32.Parse(c.ToString()))
    match length > data.Length with
    | true -> failwith "The window must be larger than the data stream"
    | false ->  [0 .. Seq.length digits - length] |> List.map (fun index -> digits |> List.skip index |> List.take length)