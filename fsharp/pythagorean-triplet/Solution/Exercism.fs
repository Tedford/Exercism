module PythagoreanTriplet

let triplet a b c = (a,b,c)

let isPythagorean (a,b,c) =
    let sorted = seq {yield a; yield b; yield c} |> Seq.sort |> Seq.toArray
    let a' = sorted.[0]
    let b' = sorted.[1]
    let c' = sorted.[2]
    
    pown a' 2 + pown b' 2 = pown c' 2

let pythagoreanTriplets low high = 
    [for a in [low .. high - 2] do
        for b in [ a + 1 .. high - 1] do
            for c in [b + 1 .. high] do
                yield triplet a b c]
    |> List.filter isPythagorean
    

    


    
    