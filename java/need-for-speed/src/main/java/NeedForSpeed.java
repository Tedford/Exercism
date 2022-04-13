class NeedForSpeed {
    private int _battery = 100;
    private int _batteryDrain;
    private int _speed;
    private int _distance;

    public NeedForSpeed(int speed, int batteryDrain) {
        _speed = speed;
        _batteryDrain = batteryDrain;
    }

    public boolean batteryDrained() {
        return _battery == 0;
    }

    public int distanceDriven() {
        return _distance;
    }

    public void drive() {
        if (_battery >=_batteryDrain) {
            _distance += _speed;
            _battery -= _batteryDrain;
        }
    }

    public static NeedForSpeed nitro() {
        return new NeedForSpeed(50, 4);
    }
}

class RaceTrack {

    private int _distance;

    public RaceTrack(int distance) {
        _distance = distance;
    }

    public boolean carCanFinish(NeedForSpeed car) {
        var finished = false;
        do {
            car.drive();
            finished = car.distanceDriven() >= _distance;
        } while (!finished && !car.batteryDrained());
        return finished;
    }
}
