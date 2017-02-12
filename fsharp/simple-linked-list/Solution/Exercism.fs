module SimpleLinkedList


type Node = 
| Element of Node * int
| Empty

let nil = Empty

let isNil node = 
    match node with
    | Empty -> true
    | _ -> false

let create value next = Element(next, value)

let next node = 
    match node with
    | Empty -> failwith "The list is empty"
    | Element(n,_) -> n

let datum node = 
    match node with
    | Element(_,v) -> v
    | Empty -> failwith "The list is empty"

let toList linkedList = 
    let rec extract node =
        match node with
        | Empty -> []
        | Element(n,v)-> v :: extract n
    extract linkedList

let fromList l = 
    let rec makeNode list =
        match list with
        | [] -> Empty
        | head :: tail -> Element(makeNode tail, head)
    makeNode l

let reverse l = l |> toList |> List.rev |> fromList
    