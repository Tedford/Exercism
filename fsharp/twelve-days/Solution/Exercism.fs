module TwelveDaysSong

let gifts = [
    "two Turtle Doves";
    "three French Hens";
    "four Calling Birds";
    "five Gold Rings";
    "six Geese-a-Laying";
    "seven Swans-a-Swimming";
    "eight Maids-a-Milking";
    "nine Ladies Dancing";
    "ten Lords-a-Leaping";
    "eleven Pipers Piping";
    "twelve Drummers Drumming"
    ]

let dayToOrdinal day = 
    match day with
    | 2 -> "second"
    | 3 -> "third"
    | 4 -> "fourth"
    | 5 -> "fifth"
    | 6 -> "sixth"
    | 7 -> "seventh"
    | 8 -> "eighth"
    | 9 -> "ninth"
    | 10 -> "tenth"
    | 11 -> "eleventh"
    | 12 -> "twelfth"
    | _ -> failwith (sprintf "Day %d is out of range" day)

let giftsForDay day = 
    gifts
    |> List.take (day - 1)
    |> List.rev
    |> String.concat ", "

    
let verse day = 
    match day with
    | 1 -> "On the first day of Christmas my true love gave to me, a Partridge in a Pear Tree.\n"
    | x -> sprintf "On the %s day of Christmas my true love gave to me, %s, and a Partridge in a Pear Tree.\n" (dayToOrdinal x) (giftsForDay x)

let verses day0 dayn = 
    (
        [day0..dayn] 
        |> List.map verse 
        |> String.concat "\n"
    ) + "\n"


let song = verses 1 12