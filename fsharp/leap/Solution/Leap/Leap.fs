module LeapYear

let isLeapYear year = 
    let mod4 = (year % 4) = 0
    let mod100 = (year % 100)  = 0
    let mod400 = (year % 400) = 0
    match (mod4,mod100,mod400) with
    | true, true, true-> true
    | true, false, _ -> true
    | _ -> false