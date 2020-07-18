module CircularBuffer

open System

type Buffer = {
    Size: int;
    Elements : int list;
}


let hasCapacity buffer = buffer.Elements |> List.length < buffer.Size

let mkCircularBuffer size = 
    {Size = size; Elements = []}

let clear buffer = 
    {buffer with Elements = []} 

let write value buffer = 
    match hasCapacity buffer  with
    | true -> {buffer with Elements = buffer.Elements @ [value]}
    | false -> raise (Exception("Cannot push new value, the buffer is full"))

let forceWrite value buffer = 
    match hasCapacity buffer, buffer.Elements with 
    | false , _ :: tail  -> {buffer with Elements = tail @ [value]}
    | true, x  -> {buffer with Elements = x @ [value]}
    | _ -> failwith "Unexpected condition"

let read buffer = 
    match buffer.Elements with
    | head:: tail -> (head, {buffer with Elements = tail})
    | [] -> failwith "Attempting to read an empty buffer"