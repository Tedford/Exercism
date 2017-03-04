var DnaTranscriber = function(){};

DnaTranscriber.prototype.toRna = function(nucleotide)
{
    var rna = "";

    for(var i = 0; i < nucleotide.length; i++)
    {
        switch(nucleotide[i]) {
            case "G":
                rna += 'C';
                break;
            case "C":
                rna += 'G';
                break;
            case "T":
                rna += 'A';
                break;
            case "A":
                rna += 'U';
                break;
            default:
                throw "Invalid input"
        }
    }

    return rna;
};

module.exports = DnaTranscriber;