module BinarySearchTree

// adapted from https://en.wikibooks.org/wiki/F_Sharp_Programming/Advanced_Data_Structures#AVL_Trees

type 'a tree =
    | Node of int * int * 'a tree * 'a tree
    | Nil


let height = function
    | Node(h,_,_,_)-> h
    | Nil -> 0

let make value left right =
    let h = 1 + max (height left) (height right)
    Node(h, value, left, right)

let rotateRight = function
    | Node(_, x, Node(_, lx, ll, lr), r) -> 
        let r' = make x lr r
        make lx ll r'
    | node-> node

let rotateLeft = function
    | Node(_, x, l, Node(_, rx, rl, rr)) ->
        let l' = make x l rl
        make rx l' rr
    | node -> node


let doubleRotateLeft = function
    | Node( h, x, l, r)->
        let r' = rotateRight r
        let node' = make x l r'
        rotateLeft node'
    | node->node


let doubleRotateRight = function
    | Node( h, x, l, r)->
        let l' = rotateLeft l
        let node' = make x l' r
        rotateRight node'
    | node -> node


let balanceFactor = function
    | Nil -> 0
    | Node(_, _, l, r) -> (height l) - (height r)


let balance = function
    | Node(h, x, l,r ) as node when balanceFactor node >= 2 ->
        if balanceFactor l >= 1 then rotateRight node
        else doubleRotateRight node
    | Node(h,x,l,r) as node when balanceFactor node <= -2 ->
        if balanceFactor r <= -1 then rotateLeft node
        else doubleRotateLeft node
    | node -> node


let rec insert value = function
    | Nil -> Node(1, value, Nil, Nil)
    | Node(_, x, l, r) as node ->
            let l', r' = if value <= x then insert value l, r else l, insert value r
            let node' = make x l' r'
            balance <| node'

let singleton value = make value Nil Nil

let value = function
    | Nil -> None
    | Node(_,x,_,_) -> Some(x)


let left = function
    | Nil -> None
    | Node(_,_,l,_) -> Some(l)

let right = function
    | Nil -> None
    | Node(_,_,_,r)-> Some(r)

let fromList values = 
    values
    |> List.fold (fun tree v -> insert v tree) Nil
    

let toList tree = 
    let rec visit = function
        | Nil -> []
        | Node(_,x,l,r) -> 
            [
                yield! visit l;
                yield x;
                yield! visit r
            ]
    visit tree


