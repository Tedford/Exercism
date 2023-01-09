private fun Int.squared() = this * this

class Squares(val seed:Int) {

    fun sumOfSquares() = 1.rangeTo(seed).sumOf { it.squared()}

    fun squareOfSum() = 1.rangeTo(seed).sum().squared()

    fun difference() = squareOfSum() - sumOfSquares()
}
