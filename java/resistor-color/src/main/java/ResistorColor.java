import java.util.Comparator;
import java.util.Map;

import static java.util.Map.entry;

class ResistorColor {
final Map<String,Integer> bands = Map.ofEntries(
        entry("black",0),
        entry("brown",1),
        entry("red",2),
        entry("orange",3),
        entry("yellow",4),
        entry("green",5),
        entry("blue",6),
        entry("violet",7),
        entry("grey",8),
        entry("white",9)
        );

    int colorCode(String color) {
        return bands.get(color);
    }

    String[] colors() {
        return bands.entrySet().stream().sorted(Comparator.comparing(Map.Entry::getValue)).map(Map.Entry::getKey).toArray(String[]::new);
    }
}
