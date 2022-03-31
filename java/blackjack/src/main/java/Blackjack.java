public class Blackjack {

    private final int BLACKJACK = 21;
    private final String HIT = "H";
    private final String SPLIT = "P";
    private final String STAND = "S";
    private final String WIN = "W";

    public int parseCard(String card) {
        var value = 0;
        switch(card){
            case "ace":
                value = 11;
                break;
            case "king":
            case "queen":
            case "jack":
            case "ten":
                value = 10;
                break;
            case "nine":
                value = 9;
                break;
            case "eight":
                value = 8;
                break;
            case "seven":
                value = 7;
                break;
            case "six":
                value = 6;
                break;
            case "five":
                value = 5;
                break;
            case "four":
                value =4;
                break;
            case "three":
                value =3;
                break;
            case "two":
                value = 2;
                break;
            case "one":
                value = 1;
                break;
        }
        return value;
    }

    public boolean isBlackjack(String card1, String card2) {
        return parseCard(card1) + parseCard(card2) == BLACKJACK;
    }

    public String largeHand(boolean isBlackjack, int dealerScore) {
        var strategy = STAND;
        if( !isBlackjack)
        {
            strategy =SPLIT;
        }
        else if( dealerScore < 10)
        {
            strategy = WIN;
        }
        
        return strategy;
    }

    public String smallHand(int handScore, int dealerScore) {
        var strategy = STAND;
        
        if( handScore <11|| (handScore < 17 && dealerScore > 6) ){
            strategy = HIT;
        }
        return strategy;
    }

    // FirstTurn returns the semi-optimal decision for the first turn, given the cards of the player and the dealer.
    // This function is already implemented and does not need to be edited. It pulls the other functions together in a
    // complete decision tree for the first turn.
    public String firstTurn(String card1, String card2, String dealerCard) {
        int handScore = parseCard(card1) + parseCard(card2);
        int dealerScore = parseCard(dealerCard);

        if (20 < handScore) {
            return largeHand(isBlackjack(card1, card2), dealerScore);
        } else {
            return smallHand(handScore, dealerScore);
        }
    }
}
