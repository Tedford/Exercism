module QueenAttack

let canAttack white black = 
    if white = black then failwith (sprintf "Cannot occuply the same square %A" white)
    match white, black with 
    | (x1,y1), (x2, y2) when x1 = x2 || y1 = y2  -> true
    | (x1,y1), (x2, y2) when abs(x2 - x1) = abs(y2-y1) -> true
    | _ -> false
