module ValentinesDay

type Genre = Crime | Horror | Romance | Thriller
type Approval = Yes | No | Maybe
type Cuisine = Korean | Turkish
type Activity = 
    | BoardGame
    | Chill
    | Movie of Genre
    | Restaurant of Cuisine
    | Walk of int

let rateActivity (activity: Activity): Approval = 
    match activity with
    | BoardGame -> No
    | Chill -> No
    | Movie genre -> match genre with Romance -> Yes | _-> No
    | Restaurant cuisine -> match cuisine with Korean -> Yes | _ -> Maybe
    | Walk distance -> match distance with | x when x < 3 -> Yes | x when x < 5 -> Maybe | _ -> No
