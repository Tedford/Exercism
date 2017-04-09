module CustomSet

let empty = []

let isEmpty set = set |> List.isEmpty

let singleton value = [value]

let contains value set = set |> List.contains value

let fromList values = values |> List.sort

let isSubsetOf set1 set2 = 
    [for e in set1 -> List.contains e set2]
    |> Seq.forall ( fun exists -> exists = true )

let isDisjointFrom set1 set2 = 
    [for e in set1 -> List.contains e set2]
    |> Seq.forall ( fun exists -> exists = false )

let insert value set=
    if contains value set then set else value :: set |> List.sort

let intersection set1 set2 = 
    [for e in set1 -> e, List.contains e set2]
    |> List.filter (fun (_, intersects) -> intersects) 
    |> List.map fst

let difference set1 set2 =
    [for e in set1 -> e, List.contains e set2]
    |> List.filter (fun (_, intersects) -> not intersects) 
    |> List.map fst

let union set1 set2  = 
    set1 @ set2
    |> List.groupBy id
    |> List.map fst
    |> List.sort