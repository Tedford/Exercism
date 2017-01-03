module GradeSchool
open System

let empty = Map.empty

let add child grade roster = 
    match Map.tryFind grade roster with
    | Some students -> Map.add grade (child :: students) roster
    | None -> Map.add grade [child] roster

let roster school = 
    Map.map (fun _ value -> List.sort value) school
    |> Map.toList

let grade level school = 
    match Map.tryFind level school with
    | Some students -> students |> List.sort
    | None -> List.empty
