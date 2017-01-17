module ErrorHandling

type Result<'TSuccess, 'TError> = 
    | Ok of 'TSuccess
    | Error of 'TError

let (|Int|_|) str = 
    match System.Int32.TryParse(str) with
    | (true, int) -> Some(int)
    |  _ -> None

let handleErrorByThrowingException value = failwith "Danger, Will Robinson, Danger"

let handleErrorByReturningOption value = 
    match value with
    | Int i  -> Some(i)
    | _ -> None
     
let handleErrorByReturningResult value = 
    match value with
    | Int i -> Ok(i)
    | _ -> Error("Could not convert input to integer")

let cleanupDisposablesWhenThrowingException resource = 
    use r = resource
    failwith "Danger, Will Robinson, Danger"
    
let bind next = 
    fun input ->
    match input with
    | Ok value -> next value
    | Error value -> Error value