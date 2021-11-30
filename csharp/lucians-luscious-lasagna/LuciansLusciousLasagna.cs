class Lasagna
{
    public static readonly int LayerTime = 2;

    public int ExpectedMinutesInOven() => 40;

    public int RemainingMinutesInOven(int elapsed)   => ExpectedMinutesInOven() - elapsed;

    public int PreparationTimeInMinutes(int layers) => LayerTime* layers;

    public int ElapsedTimeInMinutes(int layers, int elapsed) => PreparationTimeInMinutes(layers) + elapsed;
}
