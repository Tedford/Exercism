class Bob {

    String hey(String input) {
        var letters = input.chars().filter(Character::isAlphabetic).count();
        var isYelling = input.chars().filter(Character::isAlphabetic).filter(Character::isUpperCase).count() ==letters && letters > 0;
        var isQuestion = input.trim().endsWith("?");
        var response = "Whatever.";

        /*
        "Sure." This is his response if you ask him a question, such as "How are you?" The convention used for questions is that it ends with a question mark.
"Whoa, chill out!" This is his answer if you YELL AT HIM. The convention used for yelling is ALL CAPITAL LETTERS.
"Calm down, I know what I'm doing!" This is what he says if you yell a question at him.
"Fine. Be that way!" This is how he responds to silence. The convention used for silence is nothing, or various combinations of whitespace characters.
"Whatever." This is what he answers to anything else.
         */


        if( isYelling && isQuestion){
            response = "Calm down, I know what I'm doing!";
        }
        else if(isQuestion){
            response = "Sure.";
        }
        else if(isYelling){
            response = "Whoa, chill out!";
        }
        else if(input.trim().isEmpty()) {
            response = "Fine. Be that way!";
        }

        return response;
    }

}