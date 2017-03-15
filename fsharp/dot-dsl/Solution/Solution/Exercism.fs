module DotDsl


type Element = 
    | Edge of Node1:string * Node2:string * Properties: (string *string) list
    | Node of Name:string * Properties : (string * string) list
    | Attribute of Key : string * Value : string

type Graph = {
    Edges: Element list;
    Nodes: Element list;
    Attributes: Element list;
}

let sortAttributes = function
    | Attribute(k, _) -> k
    | _ -> ""

let sortNodes = function
    | Node(n, _)-> n
    | _ -> ""

let sortEdges = function
    | Edge(n1, n2, _) -> n1 + n2
    | _ -> ""

let graph input = 
    {
        Edges = input |> List.choose (fun s -> match s with | Edge(_,_,_) as e -> Some(e) | _ -> None )  |> List.sortBy sortEdges
        Nodes = input |> List.choose (fun s -> match s with | Node(_,_) as n -> Some(n) | _ -> None ) |> List.sortBy sortNodes
        Attributes = input |> List.choose (fun s -> match s with | Attribute(_,_) as a -> Some(a) | _ -> None ) |> List.sortBy sortAttributes
    }


let edges graph = graph.Edges
   
let nodes graph = graph.Nodes

let attrs graph = graph.Attributes

let node name props = Node(name, props)

let edge node1 node2 props = Edge(node1, node2, props) 

let attr key value = Attribute(key, value) 