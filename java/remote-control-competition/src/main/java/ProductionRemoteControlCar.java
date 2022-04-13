class ProductionRemoteControlCar implements RemoteControlCar, Comparable<ProductionRemoteControlCar> {
    private static final int Speed = 10;
    private int _distance;
    private int _victories;

    public void drive() {
        _distance += Speed;
    }

    public int getDistanceTravelled() {
        return _distance;
    }

    public int getNumberOfVictories() {
        return _victories;
    }

    public void setNumberOfVictories(int numberofVictories) {
        _victories = numberofVictories;
    }

    @Override
    public int compareTo(ProductionRemoteControlCar other) {
       return _victories -  other.getNumberOfVictories();
    }
}
