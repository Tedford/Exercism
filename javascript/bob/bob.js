var Bob = function() {};

Bob.prototype.hey = function(message){
    var response = "Whatever.";

    if (message == message.toUpperCase() && message.match(/[A-Z]/))
    {
        response = "Whoa, chill out!";
    }
    else if (message.substr(-1)=="?")
    {
        response = "Sure.";
    }
    else if(message.trim() == "") 
    {
        response = "Fine. Be that way!";
    }

    return response;
};




module.exports = Bob;