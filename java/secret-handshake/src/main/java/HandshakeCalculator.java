import java.util.Collections;
import java.util.List;
import java.util.ArrayList;


class HandshakeCalculator {

    List<Signal> calculateHandshake(int number) {
        var signals = new ArrayList<Signal>();
        if( (number & 0b00000001) != 0){
            signals.add(Signal.WINK);
        }
        if( (number & 0b00000010) != 0 ) {
            signals.add(Signal.DOUBLE_BLINK);
        }
        if( (number & 0b00000100) != 0){
            signals.add(Signal.CLOSE_YOUR_EYES);
        }
        if( (number & 0b00001000) != 0 ){
            signals.add(Signal.JUMP);
        }
        if( (number & 0b0010000) != 0) {
            Collections.reverse(signals);
        }
        return signals;
    }

}
