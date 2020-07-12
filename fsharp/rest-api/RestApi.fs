module RestApi


open Newtonsoft.Json
open System.Collections.Generic
open Newtonsoft.Json.Linq
open System


type AscendingDictionarySerializer() = 
    inherit JsonConverter()
    override this.CanConvert t = t =  typeof<Dictionary<string,double>>
    override this.ReadJson (reader, objectType, existingValue, serializer)= raise (NotImplementedException())
    override this.WriteJson(writer, value, _) =
        match value with
        | x when value.GetType() = typeof<Dictionary<string,double>> -> 
            let dict = x:?> Dictionary<string,float>
            let container = JObject()
            dict.Keys 
            |> Seq.sortBy id
            |> Seq.iter (fun k-> 
                container.Add(JProperty(k, dict.[k]))
            )
            container.WriteTo(writer)
        | _ ->  JToken.FromObject(value).WriteTo(writer)

type Balance = {
    Entity: string;
    Amount: float;
}

type Account = {
    [<JsonProperty("name")>]
    Name: string;

    [<JsonProperty("owes")>]
    Owes: Dictionary<string,float>

    [<JsonProperty("owed_by")>]
    Owed: Dictionary<string,float>

    [<JsonProperty("balance")>]
    Balance: float;
}

type Database = {
    [<JsonProperty("users")>]
    Users: Account list
}

type IouRequest = {
    [<JsonProperty("lender")>]
    Lender : string;
    [<JsonProperty("borrower")>]
    Borrower: string;
    [<JsonProperty("amount")>]
    Amount: float;
}

type AddUserRequest = {
    [<JsonProperty("user")>]
    User: string;
}

let getUserName json =
    let jtoken = JObject.Parse(json)
    (jtoken.["users"] :?> JArray).[0].Value<string>()

let serialize i = JsonConvert.SerializeObject(i, Formatting.None, AscendingDictionarySerializer() )

let deserialize<'a> json= JsonConvert.DeserializeObject<'a>(json)

let creditAccount lender borrower amount =
    let _, owedAmount = lender.Owed.TryGetValue borrower
    let owes, owesAmount = lender.Owes.TryGetValue borrower

    if owes && (owesAmount - amount > 0.0) then
        lender.Owes.[borrower] <- owesAmount - amount
    else 
        lender.Owes.Remove(borrower) |> ignore
    
    if owedAmount + amount - owesAmount > 0.0 then
        lender.Owed.[borrower] <- owedAmount + amount - owesAmount
    else
        lender.Owed.Remove(borrower) |> ignore

    {lender with Balance = lender.Balance + amount}

let debitAccount borrower lender amount =
    let owed, owedAmount = borrower.Owed.TryGetValue lender
    let _, owesAmount = borrower.Owes.TryGetValue lender

    if owed && (owedAmount - amount > 0.0) then
        borrower.Owed.[lender] <- owedAmount - amount
    else
        borrower.Owed.Remove(lender) |> ignore

    if owedAmount - owesAmount - amount < 0.0 then
        borrower.Owes.[lender] <- owesAmount + amount - owedAmount
    else 
        borrower.Owes.Remove(lender) |> ignore
    
    {borrower with Balance = borrower.Balance - amount}
    

type RestApi(database : string) =
    let _database = Dictionary<string,Account>()
    do
        JsonConvert.DeserializeObject<Database>(database).Users
        |> Seq.iter (fun user -> _database.Add(user.Name, user))

    
    member this.Get(url: string) = {Users = _database.Values |> Seq.toList} |> serialize

    member this.Get(url: string, payload: string) =
        let userName = getUserName payload
        let users = _database.[userName]
        serialize { Users= [users] }

    member this.Post(url: string, payload: string)  =
        match url with 
        | "/add" -> 
            let request = deserialize<AddUserRequest> payload
            _database.[request.User] <- {Name = request.User; Balance =0.0; Owes = Dictionary<string,float>(); Owed = Dictionary<string,float>()}
            _database.[request.User] :> Object
        | "/iou" -> 
            let request = deserialize<IouRequest> payload
            let lenderFound, lender = _database.TryGetValue request.Lender
            let borrowerFound, borrower = _database.TryGetValue request.Borrower

            match lenderFound, borrowerFound with
            | true, true ->  
                _database.[lender.Name] <- creditAccount lender borrower.Name request.Amount
                _database.[borrower.Name] <- debitAccount borrower lender.Name request.Amount
                {Users = [_database.[lender.Name]; _database.[borrower.Name]] |> List.sortBy (fun u -> u.Name )} :> Object

            | _ -> failwithf "Unable to find the lender %s or borrower %s" request.Lender request.Borrower

        | _ -> failwithf "Unmapped URL %s specified" url
        |> serialize
        

