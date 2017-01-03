let sayHello name:string =
    let n = defaultArg name "World"
    sprintf "Hello, %s!" n


printfn "When no name is supplied"
printfn "%s" (sayHello None)
printfn "When the name \"Bob\" is supplied"
printfn "%s" (sayHello (Some "Bob"))