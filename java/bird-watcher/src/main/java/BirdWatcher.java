
class BirdWatcher {
    private final int[] birdsPerDay;

    public BirdWatcher(int[] birdsPerDay) {
        this.birdsPerDay = birdsPerDay.clone();
    }

    public int[] getLastWeek() {
        return birdsPerDay;
    }

    public int getToday() {
        return birdsPerDay.length > 0 ? birdsPerDay[birdsPerDay.length - 1] : 0;
    }

    public void incrementTodaysCount() {
        birdsPerDay[birdsPerDay.length - 1] += 1;
    }

    public boolean hasDayWithoutBirds() {
        var status = false;

        for (int day : birdsPerDay) {
            status |= day == 0;
        }

        return status;
    }

    public int getCountForFirstDays(int numberOfDays) {
        var sum = 0;
        var days = Math.min(numberOfDays, birdsPerDay.length);
        for (int i = 0; i < days; i++) {
            sum += birdsPerDay[i];
        }
        return sum;
    }

    public int getBusyDays() {
        var busy = 0;

        for (int day : birdsPerDay) {
            busy += day > 4 ? 1 : 0;
        }

        return busy;
    }
}
