import java.util.Random;

class DnDCharacter {
    private static final Random _rand = new Random();
    private final Integer _str = ability();
    private final Integer _dex = ability();
    private final Integer _con = ability();
    private final Integer _wis = ability();
    private final Integer _int = ability();
    private final Integer _cha = ability();


    int ability() {
        return _rand.ints(4,1,7).sorted().skip(1).sum();
    }

    int modifier(int input) {
        return (int) Math.floor((input - 10) / 2.0);
    }

    int getStrength() {
        return _str;
    }

    int getDexterity() {
        return _dex;
    }

    int getConstitution() {
        return _con;
    }

    int getIntelligence() {
        return _int;
    }

    int getWisdom() {
        return _wis;
    }

    int getCharisma() {
        return _cha;
    }

    int getHitpoints() {
        return modifier(_con) + 10;
    }

}
