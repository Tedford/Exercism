module SimpleLinkedList


type Node = 
| End of int
| Element of Node * int

let nil = None

let create value next = Node.End


let isNil node = false

let next (node:Node) = node

let datum node = 
    match node with
    | Element(n,v) -> Some(v)
    | End(v) -> Some(v)