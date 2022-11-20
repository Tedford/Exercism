using System;

static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        bool parsed = DateTime.TryParseExact(appointmentDateDescription, "M/d/yyyy HH:mm:ss",null, System.Globalization.DateTimeStyles.None, out DateTime dt)
        || DateTime.TryParseExact(appointmentDateDescription, "MMMM d, yyyy HH:mm:ss",null, System.Globalization.DateTimeStyles.None, out dt)
        || DateTime.TryParseExact(appointmentDateDescription, "dddd, MMMM d, yyyy HH:mm:ss",null, System.Globalization.DateTimeStyles.None, out dt);
    
        return dt;
    }

    public static bool HasPassed(DateTime appointmentDate) => appointmentDate < DateTime.Now;
    

    public static bool IsAfternoonAppointment(DateTime appointmentDate) => appointmentDate.Hour > 11 && appointmentDate.Hour < 18;
    

    public static string Description(DateTime appointmentDate) => $"You have an appointment on {appointmentDate:M/d/yyyy h:mm:ss tt}.";

    public static DateTime AnniversaryDate() => new DateTime(DateTime.Now.Year,9,15,0,0,0);
    
}
