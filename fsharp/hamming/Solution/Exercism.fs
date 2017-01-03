module Hamming

let compute strand1 strand2 = 
    Seq.zip strand1 strand2 
    |> Seq.sumBy (fun (s1,s2) -> if s1 = s2 then 0 else 1)
