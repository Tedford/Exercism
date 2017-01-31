module BinarySearch

//let rec bs array value =
//    printf "Searching for %d in the array of %A\n" value array
//    let midpoint = Array.length array / 2
//    match midpoint, Array.length array with
//    | _, 0 -> None
//    | idx, _ when array.[idx] = value -> Some(idx)
//    | idx, _ when array.[idx] < value -> bs (snd (Array.splitAt (idx + 1) array)) value 
//    // the cell is greater in value
//    | idx, _ -> bs (Array.sub array 0 idx) value
//
//
//let bs2 array value =
//    let mutable cell = None
//    let mutable ``done`` = false
//    let mutable midpoint = Array.length array / 2
//    if Array.length array > 0 then
//        while not ``done`` do
//            printf "Bisecting %A at %d for %d\n" array midpoint value
//            if array.[midpoint] = value then
//                ``done`` <- true
//                cell <- Some(midpoint)
//            else 
//                if midpoint / 2 = midpoint then
//                    ``done`` <- true
//                else
//                    midpoint <- midpoint / 2
//    cell
//
//
//let rec bs3 array lower upper value = 
//    printf "Search %A from %d to %d for %d\n" array lower upper value
//    match Array.length array, (upper + lower) / 2 with 
//    | 0, _ -> None
//    | _, idx when array.[idx] = value -> Some(idx)    
//    | _, idx when array.[idx] > value -> bs3 array 0 idx value
//    | _, idx -> bs3 array idx (Array.length array) value
//
////    if Array.length array = 0 then None
////    else if array.[midpoint] = value then Some(midpoint)
////    else if array.[midpoint] > value then bs (Array.sub array 0 midpoint) value
////        let idx = bs (Array.sub array 0 midpoint) value
////        match idx with
////        | None -> None
////        | Some(x) -> Some(x-1)
////    else
////        let idx = bs (snd (Array.splitAt (midpoint+1) array)) value
////        match idx with
////        | None -> None
////        | Some(x) -> Some( midpoint + x + 1)

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