module House


let objects = 
    [
        "house that Jack built."; 
        "malt"; 
        "rat";
        "cat";
        "dog";
        "cow with the crumpled horn"; 
        "maiden all forlorn"; 
        "man all tattered and torn"; 
        "priest all shaven and shorn"; 
        "rooster that crowed in the morn";
        "farmer sowing his corn";
        "horse and the hound and the horn"
    ]

let verbs = 
    [
        "lay in";
        "ate";
        "killed";
        "worried";
        "tossed";
        "milked";
        "kissed";
        "married";
        "woke";
        "kept";
        "belonged to"
    ]

let intro = sprintf "This is the %s"
let activity =sprintf  "that %s the %s"


let createStanza stanza = 
    seq { yield intro objects.[stanza] 
          yield! [0..stanza - 1] |> List.rev |> List.map(fun i->activity verbs.[i] objects.[i])
    }
    |> String.concat "\n"

let rhyme =  
   [0..(List.length objects - 1)]
   |> List.map createStanza
   |> String.concat "\n\n"
    