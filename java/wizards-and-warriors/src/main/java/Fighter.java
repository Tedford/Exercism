abstract class Fighter {

    @Override
    public String toString() {
        return String.format("Fighter is a %s", this.getClass().getName());
    }

    boolean isVulnerable() {
        return false;
    }

    abstract int damagePoints(Fighter fighter);

}

class Warrior extends Fighter {

    @Override
    int damagePoints(Fighter wizard) {
        return wizard.isVulnerable() ? 10 : 6;
    }
}

class Wizard extends Fighter {

    private boolean prepared;

    @Override
    boolean isVulnerable() {
        return !prepared;
    }

    @Override
    int damagePoints(Fighter warrior) {
        return prepared ? 12 : 3;
    }

    void prepareSpell() {
        prepared = true;
    }

}
