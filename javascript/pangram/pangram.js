var Pangram = function(input) {
    this.input = input.toLowerCase();
};

Pangram.prototype.isPangram = function() {
    var map = new Map();
    this.input.split("").forEach(function(c){
        if(c >= 'a' && c <= 'z')
        {
            map.set(c,1);
        }
    });
    
    return map.size == 26;
};

module.exports = Pangram;