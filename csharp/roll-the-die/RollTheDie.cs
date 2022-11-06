using System;

public class Player
{
    private static readonly Random _rand = new();

    public int RollDie() => _rand.Next(1,19);

    public double GenerateSpellStrength() => _rand.NextDouble() * 100;
}
