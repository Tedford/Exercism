module BookingUpForBeauty

// The following line is needed to use the DateTime type
open System
open System.Globalization

let epoch = DateTime(2012, 9,15)

let schedule (appointmentDateDescription: string): DateTime = DateTime.ParseExact(appointmentDateDescription, [|"M/dd/yyyy HH:mm:ss";"MMMM d, yyyy HH:mm:ss"; "dddd, MMMM d, yyyy HH:mm:ss" |], CultureInfo.InvariantCulture, DateTimeStyles.None)

let hasPassed (appointmentDate: DateTime): bool = appointmentDate < DateTime.Now

let isAfternoonAppointment (appointmentDate: DateTime): bool =   appointmentDate.Hour > 11 && appointmentDate.Hour < 18

let description (apt: DateTime): string = $"You have an appointment on {apt:``M/d/yyyy h:mm:ss tt``}."

let anniversaryDate(): DateTime = DateTime(DateTime.Now.Year, epoch.Month, epoch.Day)
