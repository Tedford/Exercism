module SecretHandshake


let handshake input =
    let reversed = input &&& 0b00010000y = 0b00010000y
    let actions = input &&& 0b00001111y
    let s = actions.ToString()
    [1..s.Length]
    |> List.fold (fun code index -> 
         match System.Math.Pow(10.0, float index) with
            | 1.0 -> "wink" :: code
            | 10.0 -> "double blink" :: code
            | 100.0 -> "close your eyes" :: code
            | 1000.0 -> "jump" :: code
            | _ -> code
    ) []