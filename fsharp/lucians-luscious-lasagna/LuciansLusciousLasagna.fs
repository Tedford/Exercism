module LuciansLusciousLasagna

let expectedMinutesInOven = 40

let remainingMinutesInOven spent = expectedMinutesInOven - spent

let preparationTimeInMinutes layers = 2 * layers

let elapsedTimeInMinutes layers spent = (preparationTimeInMinutes layers) + spent