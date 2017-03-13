module DotDsl


type Edge = {
    Node1: string;
    Node2: string;
    Properties: string list;
}

type Node = {
    Name: string;
    Properties: List<string * string>;
}

type Attribute = {
    Key: string;
    Value: string;
}


type Graph = {
    Edges: Edge list;
    Nodes: Node list;
    Attributes: Attribute list
}

let graph input = 
    {
        Edges = [];
        Nodes = [];
        Attributes = [];
    }

let edges graph = []

let nodes graph = []

let attrs graph = []

let node name (props:List<string*string>) = { Name = name; Properties = props}

let edge node1 node2 props = [] 

let attr key value = []