module BinarySearch

let binarySearch array value = 
    let rec bs array value =
        let midpoint = Array.length array / 2
        match Array.length array, midpoint with
        | 0, _ -> None
        | _, idx when array.[idx] = value -> Some(idx)
        | _, idx when array.[idx] > value -> bs (Array.sub array 0 idx) value
        | _, idx -> 
            match bs (snd (Array.splitAt (idx + 1) array)) value with
            | None -> None
            | Some(idx2) -> Some(idx + idx2 + 1)
    bs array value