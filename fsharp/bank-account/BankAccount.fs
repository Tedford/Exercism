module BankAccount

type Account(balance) =

    new () =
        Account(None)
        
    member val Balance : Option<decimal> = balance with get, set


let mkBankAccount() = Account()

let openAccount (account:Account) = 
    account.Balance <- Some(0.0m)
    account

let closeAccount account = Account()
    

let getBalance (account:Account) : Option<decimal> = account.Balance

let updateBalance change (account:Account) = 
    match account.Balance with
    | None -> failwith "The account is not open"
    | Some(x) ->  
        account.Balance <- Some(x + change)
        account
        

//type Account = {
//    Balance : Option<decimal>
//}

//let mkBankAccount() = {Balance = None}

//let openAccount (account:Account) = {Balance = Some(0.0m)}
    

//let closeAccount account = {Balance = None}

//let getBalance account = account.Balance

//let updateBalance change (account:Account) = 
//    match account.Balance with
//    | None -> failwith "The account is not open"
//    | Some(x) ->  
//    { account with Balance = Some(x + change)}
//        //account.Balance <- Some(x + change)
//        //account
        
        