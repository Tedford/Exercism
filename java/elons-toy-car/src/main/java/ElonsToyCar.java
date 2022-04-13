public class ElonsToyCar {
    private int _distanceDriven = 0;
    private int _batteryLevel = 100;

    public static ElonsToyCar buy() {
        return new ElonsToyCar();
    }

    public String distanceDisplay() {
        return String.format("Driven %d meters", _distanceDriven);
    }

    public String batteryDisplay() {
        return _batteryLevel > 0 ? String.format("Battery at %d%%", _batteryLevel) : "Battery empty";
    }

    public void drive() {
        if (_batteryLevel > 0) {
            _distanceDriven += 20;
            _batteryLevel -= 1;
        }
    }
}
