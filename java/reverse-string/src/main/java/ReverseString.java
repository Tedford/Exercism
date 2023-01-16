import java.util.stream.IntStream;

class ReverseString {

    String reverse(String inputString) {
        var len = inputString.length();
        return  IntStream.range(0,len)
                .map(i-> inputString.charAt(len-i-1))
                .collect(StringBuilder::new, StringBuilder::appendCodePoint, StringBuilder::append)
                .toString();
    }
}
