public class LogLevels {
    
    public static String message(String logLine) {
        return logLine.substring(logLine.indexOf(' ')).trim();
    }

    public static String logLevel(String logLine) {
        var end = logLine.indexOf("]");
        var level = logLine.substring(1,end).toLowerCase();
        System.out.println(level);
        return level;
    }

    public static String reformat(String logLine) {
        var level = logLevel(logLine);
        var message = message(logLine);
        return String.format("%s (%s)", message, level);
    }
}
