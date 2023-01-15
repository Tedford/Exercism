object Pangram {

    fun isPangram(input: String) =
        input.lowercase()
             .filter { it.isLetter() }
             .toSet()
             .size == 26
}
