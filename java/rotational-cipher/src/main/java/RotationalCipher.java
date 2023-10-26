class RotationalCipher {
    private final int _shift;

    RotationalCipher(int shiftKey) {
        _shift = shiftKey;
    }
    
    String rotate(String data) {
        var sb = new StringBuilder();
        data.chars().forEach(x-> {
                if( Character.isAlphabetic(x)) {
                    char base;
                    if( Character.isUpperCase(x)) {
                    base = 'A';
                    }
                    else {
                        base = 'a';
                    }
                    sb.append((char)(((x-base+_shift) % 26) + base) );
                }
                else {
                    sb.append((char)x);
                }});

        return sb.toString();
    }

}
