module Gigasecond
open System

let gigasecond (dob:DateTime) = 
    dob.AddSeconds(10.0 ** 9.0).Date
