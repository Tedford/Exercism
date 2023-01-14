object HandshakeCalculator {

    private infix fun Int.isBitSet(bit: Int): Boolean = (this shr (bit - 1)).and(0b00000001) != 0

    fun calculateHandshake(number: Int): List<Signal> {
        return mutableListOf<Signal>().apply {
            if (number.isBitSet(1)) {
                add(Signal.WINK)
            }
            if( number.isBitSet(2)) {
                add(Signal.DOUBLE_BLINK)
            }
            if( number.isBitSet(3)){
                add(Signal.CLOSE_YOUR_EYES)
            }
            if( number.isBitSet(4)){
                add(Signal.JUMP)
            }
            if( number.isBitSet(5)){
                reverse()
            }
        }
    }
}
