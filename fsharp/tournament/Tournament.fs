module Tournament
    
type Result =
    | Win
    | Lost
    | Draw

type Schedule ={
    Team: string;
    Wins: int;
    Losses: int;
    Draws: int;
    Points: int;
    }

let parse (line:string) =
    line.Split(";")
    |> function 
        | [|team1; team2; result |]-> 
            match result with
            | "win" -> [{Team = team1; Wins = 1; Losses = 0; Draws = 0; Points=3};{Team = team2; Wins = 0; Losses = 1; Draws = 0; Points =0;}]
            | "loss" -> [{Team = team1; Wins = 0; Losses = 1; Draws = 0; Points=0;};{Team = team2; Wins = 1; Losses = 0; Draws = 0; Points=3;}]
            | "draw" -> [{Team = team1; Wins = 0; Losses = 0; Draws = 1; Points=1;};{Team = team2; Wins = 0; Losses = 0; Draws = 1; Points=1;}]
            | _ -> failwithf "%A is unrecognized game result" result
        | _ -> failwithf "%A is not formatted as as <team>;<team>;<result>" line


let condenseSchedule team games = 
    let wins = games |> List.sumBy (fun g -> g.Wins)
    let losses = games |> List.sumBy (fun g -> g.Losses)
    let draws = games |> List.sumBy (fun g -> g.Draws)
    let points = games |> List.sumBy (fun g -> g.Points)
    {Team = team; Wins = wins; Losses = losses; Draws = draws; Points  = points;}

let prettyPrintTeam team =
    sprintf "%-30s |%3d |%3d |%3d |%3d |%3d" team.Team (team.Wins + team.Losses + team.Draws) team.Wins team.Draws team.Losses team.Points

let prettyPrintLeague schedule =
    "Team                           | MP |  W |  D |  L |  P" :: (schedule |> List.map prettyPrintTeam)

let tally input = 
    input 
    |> List.map parse 
    |> List.concat 
    |> List.groupBy (fun item -> item.Team) 
    |> List.map (fun (teams, games) -> condenseSchedule teams games)
    |> List.groupBy (fun schedule -> schedule.Points)
    |> List.sortByDescending (fun (points,_) -> points)
    |> List.map (fun (_, teams) -> teams |> List.sortBy( fun t -> t.Team))
    |> List.concat
    |> prettyPrintLeague