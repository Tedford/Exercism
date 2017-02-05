module Meetup

type Schedule = First | Second | Teenth | Third | Fourth | Last

let candidateDays dayOfWeek month year =
    Array.init (System.DateTime.DaysInMonth(year, month)) (fun day -> new System.DateTime(year, month, day+1))
    |> Array.filter (fun date-> date.DayOfWeek= dayOfWeek)

let getSelector  =
    function
    | First ->  Array.item 0
    | Second -> Array.item 1
    | Third ->  Array.item 2
    | Fourth -> Array.item 3
    | Teenth -> Array.find (fun (d:System.DateTime) -> d.Day > 12 && d.Day < 20) 
    | Last ->   Array.last

let meetupDay dayOfWeek schedule year month  =  
    candidateDays dayOfWeek month year
    |> getSelector schedule