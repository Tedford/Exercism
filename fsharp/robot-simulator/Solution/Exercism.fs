module RobotSimulator

type Bearing = North | South | East | West
type Movement = TurnRight | TurnLeft | Advance

type Robot = {Bearing : Bearing; Location: int * int }

let createRobot bearing location = {Bearing = bearing; Location = location}

let bearLeft bearing =
    match bearing with
    | North -> West
    | West -> South
    | South -> East
    | East -> North

let bearRight bearing =
    match bearing with
    | North -> East
    | East -> South
    | South -> West
    | West -> North

let turnLeft robot = {robot with Bearing = (bearLeft robot.Bearing)}

let turnRight robot = {robot with Bearing = (bearRight robot.Bearing)}

let advance robot =
    let (x,y) = robot.Location
    match robot.Bearing with
    | North -> {robot with Location = (x, y+1)}
    | East -> {robot with Location = (x+1, y)}
    | South -> {robot with Location = (x, y-1)}
    | West -> {robot with Location = (x-1, y)}

let mapMovement move =
    match move with
    | 'A' -> Advance
    | 'R' -> TurnRight
    | 'L' -> TurnLeft
    | _ -> invalidOp (sprintf "Unexpected movement %A detected" move)

let simulate robot actions = 
    actions
    |> Seq.toList
    |> List.map mapMovement
    |> List.fold (fun r movement -> 
        match movement with 
        | Advance -> advance r
        | TurnLeft-> turnLeft r
        | TurnRight ->  turnRight r
        ) robot