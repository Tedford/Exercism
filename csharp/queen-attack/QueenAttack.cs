using System;

public class Queen
{
    public Queen(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}

public static class Queens
{
    public static bool CanAttack(Queen white, Queen black)
    {
        if(white.Row == black.Row && white.Column == black.Column)
        {
            throw new ArgumentException($"The spot {white.Column}, {white.Row} is already occupied.");
        }

        return white.Row == black.Row || white.Column == black.Column || Math.Abs(white.Column - black.Column) == Math.Abs(white.Row - black.Row);
    }

}