module Allergies

type  Allergen =
| Eggs = 1
| Peanuts = 2
| Shellfish = 4
| Strawberries = 8
| Tomatoes = 16
| Chocolate = 32  
| Pollen = 64
| Cats = 128


let allergies score = 
    System.Enum.GetValues(typeof<Allergen>)
    |> Seq.cast<Allergen>
    |> Seq.map (fun allergen -> allergen,  (int allergen) &&& score = (int allergen))
    |> Seq.filter (fun (_, active) -> active)
    |> Seq.map (fun (allergen, active) -> allergen)
    |> Seq.toList


let allergicTo (allergen:Allergen) score = (int allergen) &&& score = (int allergen)
