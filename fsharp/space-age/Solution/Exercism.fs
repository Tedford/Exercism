module SpaceAge
open System

type Planet =
    | Earth
    | Saturn
    | Neptune
    | Uranus
    | Mars
    | Venus
    | Mercury
    | Jupiter   

let spaceAge planet seconds =
    let normalizedAge = seconds / (365.25m * 60.0m * 60.0m * 24.0m)
    let factor = 
        match planet with
            | Mercury -> 0.2408467m 
            | Venus ->0.61519726m 
            | Mars -> 1.8808158m
            | Jupiter ->11.862615m
            | Saturn -> 29.447489m 
            | Uranus -> 84.016846m
            | Neptune -> 164.79132m
            | _-> 1.0m
    Math.Round(normalizedAge / factor, 2)