object ScrabbleScore {
    fun scoreLetter(c: Char): Int {
        return when(c.uppercaseChar()) {
            'D' -> 2
            'G' -> 2
            'B' -> 3
            'C' -> 3
            'M' -> 3
            'P' -> 3
            'F' -> 4
            'H' -> 4
            'V' -> 4
            'W' -> 4
            'Y' -> 4
            'K' -> 5
            'J' -> 8
            'X' -> 8
            'Q' -> 10
            'Z' -> 10
            else -> 1
        }
    }

    fun scoreWord(word: String): Int {
        var score = 0
        for( c in word){
            score += scoreLetter(c)
        }
        return score
    }
}
