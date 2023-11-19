<#
.SYNOPSIS
    Implement a clock that handles times without dates.

.DESCRIPTION
    Implement a clock that handles times without dates in 24 hours format.
    You should be able to add and subtract minutes to it.
    Two clocks that represent the same time should be equal to each other.
    Note: Please try to implement the class and its method instead of using built-in module Datetime.

.EXAMPLE
    $clock1 = [Clock]::new(5,0)
    $clock1.ToString()
    Return: "05:00"

    $clock2 = [Clock]::new(6,-120)
    $clock2.Add(60).ToString()
    Return: "05:00"

    $clock1 -eq $clock2
    Return: $true
#>

class Clock {
    static [int] $MinutesPerDay = 24 * 60
    [int] $Offset

    Clock([int]$hour, [int]$minutes) {
        if ($hour -lt 0) {
            $hour = 24 + ($hour % 24)
        }
                
        $this.Offset = ([Clock]::NormalizeMinutes($minutes) + $hour * 60) % [Clock]::MinutesPerDay
    }

    [string] ToString() {
        $hours = [Math]::Floor($this.Offset / 60 % 24).ToString("00")
        $minutes = ($this.Offset % 60).ToString("00")
        return "$($hours):$($minutes)"
    }

    [Clock] Add([int]$minutes){
        $this.Offset += [Clock]::NormalizeMinutes($minutes)
        return $this
    }

    [bool] Equals($other) {
        return $this.Offset -eq $other.Offset
    }

    static [int] NormalizeMinutes([int]$minutes){
        if ( $minutes -lt 0){
            $minutes = [Clock]::MinutesPerDay + ($minutes % [Clock]::MinutesPerDay)
        }
        return $minutes
    }
}