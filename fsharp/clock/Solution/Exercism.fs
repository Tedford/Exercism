module Clock

let MinutesPerHour = 60
let MinutesPerDay = 60 * 24
type clock = {offset: int}

let mkClock hour minute = {offset = (hour * MinutesPerHour + minute) % MinutesPerDay}
let add minutes clock = {offset = (clock.offset + minutes)%MinutesPerDay }
let subtract minutes clock = {offset = if clock.offset - minutes < 0 then MinutesPerDay + (clock.offset - minutes) else clock.offset - minutes}
let display clock = sprintf "%02i:%02i" (clock.offset / MinutesPerHour) (clock.offset % MinutesPerHour)

