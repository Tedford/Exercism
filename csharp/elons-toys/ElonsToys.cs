using System;

class RemoteControlCar
{
    private static readonly int DistancePerUnit = 20;

    private int _distance;
    private int _battery = 100;

    public static RemoteControlCar Buy() => new RemoteControlCar ();

    public string DistanceDisplay() => $"Driven {_distance} meters";

    public string BatteryDisplay() => _battery > 0 ? $"Battery at {_battery}%" : "Battery empty";

    public void Drive()
    {
        if (_battery > 0)
        {
            _distance += DistancePerUnit;
            _battery--;
        }
    }
}
