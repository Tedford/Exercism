module PythagoreanTriplet

let triplet a b c = (a,b,c)

let isPythagorean (a,b,c) =
   let [|a';b';c'|] = [| a; b; c|] |> Array.sort 
   pown a' 2 + pown b' 2 = pown c' 2

let pythagoreanTriplets low high = 
    [low .. high - 2]
    |> List.map (fun a -> [ a + 1 .. high - 1] |> List.map ( fun b -> [ b + 1 .. high ] |> List.map(fun c -> triplet a b c )) )
    |> List.concat
    |> List.concat
    |> List.filter isPythagorean
    

    


    
    