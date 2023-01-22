import java.util.ArrayList;
import java.util.stream.IntStream;

public class NaturalNumber {
    private final Integer _number;

    public NaturalNumber(Integer number) {
        if (number < 1) {
            throw new IllegalArgumentException("You must supply a natural number (positive integer)");
        }
        _number = number;
    }

    public Classification getClassification() {
        var sum = calculateSumOfFactors();
        var classification = Classification.PERFECT;
        if (_number < sum) {
            classification = Classification.ABUNDANT;
        } else if (_number > sum || _number == 1) {
            classification = Classification.DEFICIENT;
        }
        return classification;
    }

    private Integer calculateSumOfFactors() {
        return IntStream.rangeClosed(1, (int) Math.ceil(_number / 2.0)).filter(i -> _number % i == 0).sum();
    }
}
