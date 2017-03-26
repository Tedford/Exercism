module TreeBuilding

type Record = { RecordId: int; ParentId: int }
type Tree = 
    | Branch of int * Tree list
    | Leaf of int

let recordId t = 
    match t with
    | Branch (id, c) -> id
    | Leaf id -> id

let isBranch t = 
    match t with
    | Branch (id, c) -> true
    | Leaf id -> false

let children t = 
    match t with
    | Branch (id, c) -> c
    | Leaf id -> []

let buildTree records = 

    let pushValue (map: Map<int,int list>) record = 
        match map.TryFind(record.ParentId) with 
        | Some x -> map.Remove(record.ParentId) |> Map.add record.ParentId (record.RecordId :: x)
        | None -> map.Add(record.ParentId, [record.RecordId ])

    let rec mapToTree m key =
        if Map.containsKey key m then
            Branch (key, List.map (fun i -> mapToTree m i) (Map.find key m))
        else
            Leaf key  

    let result = 
        records
        |> List.sortByDescending (fun r -> r.RecordId)
        |> List.fold (fun acc r -> 
            match r with
            | _ when (r.ParentId = r.RecordId && r.ParentId <> 0) ||  r.ParentId > r.RecordId  -> failwith "Nodes with Invalid Parents"
            | _ when r.RecordId= 0 -> (Some(r), snd acc)
            | _ -> 
                let previous, map = acc
                let map' = 
                    match  previous with
                    | Some n-> if r.RecordId + 1 <> n.RecordId then failwith "Non-continuous list" else pushValue map r
                    | None -> pushValue map r
                (Some(r), map')
        ) (None, [] |> Map.ofList)

    
    let root, map = result

    match root with
    | None -> failwith "Empty input"
    | Some n -> if n.RecordId <> 0 then failwith "Root node is invalid"
    
    mapToTree map 0 