import java.text.CharacterIterator;
import java.text.StringCharacterIterator;
import java.util.ArrayList;
import java.util.Map;

public class Say {

    private final Map<Integer, String> _digitNames = Map.of(
            9, "nine",
            8, "eight",
            7, "seven",
            6, "six",
            5, "five",
            4, "four",
            3, "three",
            2, "two",
            1, "one");

    private final Map<Integer, String> _tensDigitNames = Map.of(
            9, "ninety",
            8, "eighty",
            7, "seventy",
            6, "sixty",
            5, "fifty",
            4, "forty",
            3, "thirty",
            2, "twenty",
            1, "one");

    public String say(long number) {
        if (number < 0 || number > 999_999_999_999L) {
            throw new IllegalArgumentException();
        }

        return number == 0 ? "zero" : toHumanLanguage(number);
    }

    private String toHumanLanguage(long number) {
        var parts = new ArrayList<String>();
        var iterator = new StringCharacterIterator(new StringBuffer(String.valueOf(number)).reverse().toString());
        StringBuilder sb = new StringBuilder();
        while (iterator.current() != CharacterIterator.DONE) {
            sb.insert(0, iterator.current());
            if (sb.length() == 3) {
                parts.add(0, sb.toString());
                sb = new StringBuilder();
            }
            iterator.next();
        }
        if (sb.length() > 0) {
            parts.add(0, sb.toString());
        }

        var answer = new StringBuilder();

        var scale = parts.size();

        for (var segment : parts) {
            var hundreds = 0;
            var tens = 0;
            var ones = 0;

            if (segment.length() == 3) {
                hundreds = Integer.parseInt(segment.substring(0, 1));
                tens = Integer.parseInt(segment.substring(1, 2));
                ones = Integer.parseInt(segment.substring(2, 3));
            } else if (segment.length() == 2) {
                tens = Integer.parseInt(segment.substring(0, 1));
                ones = Integer.parseInt(segment.substring(1, 2));
            } else {
                ones = Integer.parseInt(segment);
            }

            if (hundreds > 0) {
                answer.append(_digitNames.get(hundreds)).append(" hundred ");
            }
            if (tens > 1) {
                answer.append(_tensDigitNames.get(tens)).append(ones == 0 ? "" : "-");
            } else if (tens == 1) {
                switch (ones) {
                    case 9 -> answer.append("nineteen ");
                    case 8 -> answer.append("eighteen ");
                    case 7 -> answer.append("seventeen ");
                    case 6 -> answer.append("sixteen ");
                    case 5 -> answer.append("fifteen ");
                    case 4 -> answer.append("fourteen ");
                    case 3 -> answer.append("thirteen ");
                    case 2 -> answer.append("twelve ");
                    case 1 -> answer.append("eleven ");
                    case 0 -> answer.append("ten ");
                }
            }

            if (ones != 0 && tens != 1) {
                answer.append(_digitNames.get(ones)).append(" ");
            }

            if (hundreds + tens + ones > 0) {
                switch (scale--) {
                    case 4 -> answer.append("billion ");
                    case 3 -> answer.append("million ");
                    case 2 -> answer.append("thousand ");
                }
            }
        }

        return answer.toString().trim();
    }
}

