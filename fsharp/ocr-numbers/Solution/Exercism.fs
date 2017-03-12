module OcrNumbers

// reduced transposed representation of each digit
let digits = [ (" ||_ _ ||", "0"); 
               ("       ||", "1");
               ("  |___ | ", "2");
               ("   ___ ||", "3");
               (" |  _  ||", "4");
               (" | ___  |", "5");
               (" ||___  |", "6");
               ("   _   ||", "7");
               (" ||___ ||", "8");
               (" | ___ ||", "9");
             ] |> Map.ofList


let transposeStrip (strip:string) =
    // each character is reduced to 3 lines
    let width = strip.Length / 3
    [for i in [0..(width - 2)] do
        yield strip.[i]
        yield strip.[i+width]
        yield strip.[i+width * 2]
        ]

   
let recognizeDigit (input:char[]) =
    let key = System.String.Concat(input)
    if Map.containsKey key digits then Map.find key digits else "?"

let convert (value:string) = 
    let sequences = 
        List.unfold (fun l -> match l with 
                        | _ when System.String.IsNullOrWhiteSpace(l) -> None 
                        | x ->  

                            let segment = x.Split([|'\n' |]) |> Array.take 4
                            
                            let digit = (segment |> Array.take 3 |> String.concat "\n") + "\n"
                            let bufferLine = segment |> Array.skip 3 |> String.concat ""
                            let consumed = digit.Length + bufferLine.Length 

                            // the final line may or may not contain a new line followed by addition digits
                            let remainder = if x.Length > consumed then x.Substring(consumed + 1) else x.Substring(consumed)
                           
                            Some(digit, remainder)
            ) value



    let lines = 
        [for line in sequences do
            yield transposeStrip line
            |> Seq.chunkBySize 9
            |> Seq.map recognizeDigit
            |> String.concat ""]

    lines |> String.concat ","
