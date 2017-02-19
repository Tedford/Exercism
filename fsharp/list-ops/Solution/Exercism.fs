module ListOps

let length l =
    let rec count len = function
        | []-> len
        | head::tail-> count (len + 1) tail
    count 0 l
    
let reverse l =
    let rec rev acc = function
        | [] -> acc
        | head::tail -> rev (head :: acc) tail
    rev [] l

let map func l=
    let rec f acc = function
        | [] -> acc
        | head::tail -> f (func head :: acc) tail
    f [] l
    |> reverse

let filter func l =
    let rec f acc = function
        | [] -> acc
        | head::tail -> 
            match func head with
            | false -> f acc tail
            | true -> f (head :: acc) tail
    f [] l
    |> reverse

let foldl func state l = 
    let rec fold acc = function
        | [] -> acc
        | head::tail -> fold (func acc head) tail
    fold state l

let foldr func state l = 
    let rec fold acc = function
        | [] -> acc
        | head::tail -> fold (func head acc) tail
    fold state (reverse l)

let append l1 l2 = 
    let rec add acc = function
        | []-> acc
        | head::tail -> add (head :: acc) tail
    add (reverse l1) l2
    |> reverse

let concat l = [for i in [0..(length l - 1)] do yield! l.[i]]