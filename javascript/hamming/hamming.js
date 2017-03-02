var Hamming = function() {};

Hamming.prototype.compute = function(strand1, strand2){

    if( strand1.length != strand2.length)
    {
        throw "DNA strands must be of equal length.";
    }

    var distance = 0;
    for(var i=0; i < strand1.length; i++ )
    {
        distance += strand1.charAt(i) == strand2.charAt(i) ? 0 : 1;
    }

    return distance;
};

module.exports = Hamming;