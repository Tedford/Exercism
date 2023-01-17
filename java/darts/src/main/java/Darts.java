class Darts {
    int score(double xOfDart,double  yOfDart) {
        var dist = Math.sqrt(Math.pow(xOfDart,2) + Math.pow(yOfDart,2));
        var s = 0;
        if( dist <= 1){
            s = 10;
        } else if (dist <= 5){
            s = 5;
        }
        else if ( dist <= 10){
            s = 1;
        }
        return s;
    }
}
