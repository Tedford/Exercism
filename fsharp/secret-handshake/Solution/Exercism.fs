module SecretHandshake


let handshake input =
    let reversed = input &&& 16 = 16
    let c = 
        [0..3]
        |> List.fold (fun code index -> 
            let mask = pown 2 index
            match  input &&& mask with
            | 1 -> "wink" :: code
            | 2 -> "double blink" :: code
            | 4 -> "close your eyes" :: code
            | 8 -> "jump" :: code
            | x -> code
        ) []
    match reversed with
    | true -> c 
    | false -> c |> List.rev 