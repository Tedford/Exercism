
var Isogram = function(phrase) {
    this.phrase = phrase.toLowerCase();
};

Isogram.prototype.isIsogram = function() {
    var letters  = new Set();

    for( var i =0; i <this.phrase.length; i++)
    {
        var char = this.phrase.charAt(i);
        if( char.toLowerCase() != char.toUpperCase())
        {
            if (letters.has(char))
            { 
                return false;
            }
            else
            {
                letters.add(char);
            }
        }
    }

    return true;
};

module.exports = Isogram;