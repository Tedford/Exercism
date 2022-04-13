public class CarsAssemble {
    private final int CarsPerSpeed = 221;

    public double productionRatePerHour(int speed) {
        var successRate = .77;
        if (speed < 5) {
            successRate = 1;
        } else if (speed < 9) {
            successRate = .9;
        } else if (speed < 10) {
            successRate = .8;
        } 
        return speed * CarsPerSpeed * successRate;
    }

    public int workingItemsPerMinute(int speed) {
        return (int) productionRatePerHour(speed) / 60;
    }
}
