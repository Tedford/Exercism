import java.util.stream.IntStream;

public class Hamming {
    private String left;
    private String right;

    public Hamming(String leftStrand, String rightStrand) {
        if (leftStrand.isEmpty() && !rightStrand.isEmpty()) {
            throw new IllegalArgumentException("left strand must not be empty.");
        }
        if (rightStrand.isEmpty() && !leftStrand.isEmpty()) {
            throw new IllegalArgumentException("right strand must not be empty.");
        }
        if (leftStrand.length() != rightStrand.length()) {
            throw new IllegalArgumentException("leftStrand and rightStrand must be of equal length.");
        }
        left = leftStrand;
        right = rightStrand;
    }

    public int getHammingDistance() {
        return (int)IntStream.range(0, left.length()).filter(i->left.charAt(i) != right.charAt(i)).count();
    }
}
