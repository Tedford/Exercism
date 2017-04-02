using System.Linq;

public static class BeerSong
{
    public static string Verse(int number)
    {
        string verse;
        switch(number)
        {
            case 2:
                verse = "2 bottles of beer on the wall, 2 bottles of beer.\nTake one down and pass it around, 1 bottle of beer on the wall.\n";
                break;
            case 1:
                verse = "1 bottle of beer on the wall, 1 bottle of beer.\nTake it down and pass it around, no more bottles of beer on the wall.\n";
                break;
            case 0:
                verse = "No more bottles of beer on the wall, no more bottles of beer.\nGo to the store and buy some more, 99 bottles of beer on the wall.\n";
                break;
            default:
                verse = $"{number} bottles of beer on the wall, {number} bottles of beer.\nTake one down and pass it around, {number-1} bottles of beer on the wall.\n";
                break;
        }

        return verse;
    }

    public static string Verses(int begin, int end) => string.Join("\n", Enumerable.Range(end, begin-end+1).Reverse().Select(i => Verse(i)));
    
}