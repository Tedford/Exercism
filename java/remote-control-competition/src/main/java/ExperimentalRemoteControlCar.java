public class ExperimentalRemoteControlCar implements RemoteControlCar {
    private static final int Speed= 20;
    private int _distance;

    public void drive() {
        _distance += Speed;
    }

    public int getDistanceTravelled() {
        return _distance;
    }
}
