import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.temporal.ChronoUnit;

public class Gigasecond {
    private LocalDateTime _epoch;
    public Gigasecond(LocalDate moment) {
        _epoch = moment.atStartOfDay();
    }

    public Gigasecond(LocalDateTime moment) {
        _epoch = moment;
    }

    public LocalDateTime getDateTime() {
        return _epoch.plus((long)Math.pow(10,9), ChronoUnit.SECONDS);
    }
}
