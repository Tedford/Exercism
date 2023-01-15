class Scrabble {

    private final String _word;

    Scrabble(String word) {
        _word = word.toUpperCase();
    }

    int getScore() {
        return _word.chars().map(c -> score((char)c)).sum();
    }

    private int score(Character c) {
        var s = 0;
         switch (c){
             case 'D':
             case 'G':
                 s = 2;
                 break;
             case 'B':
             case 'C':
             case 'M':
             case 'P':
                 s = 3;
                 break;
             case 'F':
             case 'H':
             case 'V':
             case 'W':
             case 'Y':
                 s= 4;
                 break;
             case 'K':
                 s = 5;
                 break;
             case 'J':
             case 'X':
                 s = 8;
                 break;
             case 'Q':
             case 'Z':
                 s  = 10;
                 break;
            default :
                s = 1;
        };
        return s;
    }

}
