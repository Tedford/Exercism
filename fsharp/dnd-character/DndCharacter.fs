module DndCharacter

open System

let rand = Random()
let rolld6 = fun f -> rand.Next(1,6)

type Character = {
Strength : int;
Dexterity: int;
Constitution : int;
Intelligence : int;
Wisdom : int;
Charisma : int;
Hitpoints : int;
};

let modifier x = Math.Floor(((float x - 10.0) / 2.0)) |> int

let ability() = 
    [|0..4|]
    |> Array.map rolld6
    |> Array.sortByDescending id
    |> Array.take 3
    |> Array.sum


let createCharacter() =
    let con = ability()
    let hp = 10 + (modifier con)
    {Strength= ability();Dexterity = ability(); Constitution= con;Intelligence = ability(); Wisdom = ability(); Charisma = ability(); Hitpoints = hp}
