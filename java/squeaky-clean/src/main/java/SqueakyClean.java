import java.lang.Character.UnicodeBlock;

class SqueakyClean {
    static String clean(String identifier) {
        var builder = new StringBuilder();
        var capitalize = false;

        for (var c : identifier.toCharArray()) {
            if (c == ' ') {
                builder.append('_');
            } else if (Character.isISOControl(c)) {
                builder.append("CTRL");
            } else if (c == '-') {
                capitalize = true;
            } else if (UnicodeBlock.of(c) == UnicodeBlock.GREEK && Character.isLowerCase(c)) {
            } else if (!Character.isAlphabetic(c)) {
            } else if (capitalize) {
                capitalize = false;
                builder.append(Character.toUpperCase(c));
            } else {
                builder.append(c);
            }
        }
        return builder.toString();
    }
}
