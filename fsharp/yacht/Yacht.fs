module Yacht

type Category = 
    | Ones
    | Twos
    | Threes
    | Fours
    | Fives
    | Sixes
    | FullHouse
    | FourOfAKind
    | LittleStraight
    | BigStraight
    | Choice
    | Yacht

type Die =
    | One 
    | Two 
    | Three
    | Four 
    | Five 
    | Six

let getValue die =
    match die with
    | One -> 1
    | Two -> 2
    | Three -> 3
    | Four -> 4
    | Five -> 5
    | Six -> 6

let checkIfStraight dice initial = 
    dice 
    |> List.map (fun die -> getValue die) 
    |> List.sort
    |> List.fold ( fun (last, valid) current -> 
        if valid && current = last + 1 then (current, true) else (current,false) ) (initial,true)
    |> snd

let getGroups dice =
    dice 
    |> List.groupBy id 
    |> List.map(fun (key, elements)->  (key, elements |> Seq.length) ) 

let checkIfSingular dice = dice |> getGroups |> List.length = 1

let getSingleScore die dice =
    let tuple = getGroups dice |> List.filter( fun tuple -> (fst tuple) = die ) |> List.tryHead
    match tuple with
    | None -> 0
    | Some(x) -> 
        let (_, count) = x
        count * getValue die

let score category dice = 
    match category with 
    | Ones -> getSingleScore One dice
    | Twos -> getSingleScore Two dice
    | Threes -> getSingleScore Three dice
    | Fours -> getSingleScore Four dice
    | Fives -> getSingleScore Five dice
    | Sixes -> getSingleScore Six dice
    | FullHouse -> 
        let groups =getGroups dice |> List.map (fun (die,count) ->(getValue die, count) ) |> List.sortBy fst
        match List.length groups, List.head groups |> snd with
        | count, cardinality when count = 2 && cardinality > 1 && cardinality < 4-> groups |> List.map (fun (value,count) -> value * count) |> List.sum
        | _ -> 0
    | FourOfAKind -> 
        match dice |> getGroups |> List.filter (fun (_,count) -> count > 3) |> List.sortByDescending snd with
        | (die,_) :: _  -> getValue die * 4 
        | _ -> 0
    | LittleStraight -> if checkIfStraight dice 0 then 30 else 0
    | BigStraight -> if checkIfStraight dice 1 then 30 else 0
    | Yacht -> if checkIfSingular dice then 50 else 0
    | Choice -> dice |> List.map getValue |> List.sum
    | _ -> 0