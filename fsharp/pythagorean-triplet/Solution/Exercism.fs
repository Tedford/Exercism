module PythagoreanTriplet

let triplet a b c = (a,b,c)

let isPythagorean (a,b,c) =
    let sorted = [| a; b; c|] |> Array.sort 
    let a' = sorted.[0]
    let b' = sorted.[1]
    let c' = sorted.[2]

    pown a' 2 + pown b' 2 = pown c' 2

let pythagoreanTriplets low high = 
    [low .. high - 2]
    |> List.map (fun a -> [ a + 1 .. high - 1] |> List.map ( fun b -> [ b + 1 .. high ] |> List.map(fun c -> triplet a b c )) )
    |> List.concat
    |> List.concat
    |> List.filter isPythagorean
    

    


    
    