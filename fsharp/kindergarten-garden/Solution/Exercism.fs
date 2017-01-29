module KinderGartenGarden

type Plant = Clover | Grass | Radishes | Violets

let charToPlant c =
    match c with
    | 'C' -> Clover
    | 'G' -> Grass
    | 'V' -> Violets
    | 'R' -> Radishes
    | _ -> failwith (sprintf "Unknown plant %c detected" c)

let parseFlowerMap (row:string) =
    row
    |> Seq.toList
    |> List.map charToPlant
    |> List.chunkBySize 2


let lookupPlants child garden = 
    match Map.tryFind child garden with
    | Some(plants) -> plants
    | None -> []

let garden children (plants:string) =
    let sortedChildren = children |> List.sort
    let rows = plants.Split([|'\n'|], System.StringSplitOptions.RemoveEmptyEntries)
    let row1 = parseFlowerMap rows.[0]
    let row2 = parseFlowerMap rows.[1]

    List.map2 (fun r1 r2 -> r1 @ r2) row1 row2
    |> Seq.unfold (fun f -> match f with | [] -> Some([],[]) | head::tail -> Some(head,tail))
    |> Seq.take sortedChildren.Length
    |> List.ofSeq
    |> List.map2 (fun child flowers -> (child,flowers)) sortedChildren
    |> Map.ofList

let defaultGarden plants = 
    garden ["Alice";"Bob";"Charlie";"David";"Eve";"Fred";"Ginny";"Harriet";"Ileana";"Joseph";"Kincaid";"Larry"] plants
    