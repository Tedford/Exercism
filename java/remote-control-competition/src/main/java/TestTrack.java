import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public class TestTrack {

    public static void race(RemoteControlCar car) {
        car.drive();
    }

    public static List<ProductionRemoteControlCar> getRankedCars(ProductionRemoteControlCar prc1,
                                                                 ProductionRemoteControlCar prc2) {
        var cars = new ArrayList<ProductionRemoteControlCar>();
        cars.add(prc1);
        cars.add(prc2);
        Collections.sort(cars);
        return cars;
    }
}
