import java.time.LocalDate
import java.time.LocalDateTime
import java.lang.Math.pow

class Gigasecond (val epoch: LocalDateTime) {
    constructor(dt: LocalDate) : this(dt.atStartOfDay()) {}
    val date: LocalDateTime =  epoch.plusSeconds(pow(10.0,9.0).toLong())
}
