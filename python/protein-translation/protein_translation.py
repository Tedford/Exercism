"""exercise"""
STEP = 3
Codons = {"AUG":("Methionine",False),
          "UUC":("Phenylalanine",False),
          "UUU":("Phenylalanine",False),
          "UUA":( "Leucine",False),
          "UUG":( "Leucine",False),
          "UCU":( "Serine",False),
          "UCC":( "Serine",False),
          "UCA":( "Serine",False),
          "UCG":( "Serine",False),
          "UAU":( "Tyrosine",False),
          "UAC":( "Tyrosine",False),
          "UGU":( "Cysteine",False),
          "UGC":( "Cysteine",False),
          "UGG":( "Tryptophan",False),
          "UAA": ("",True),
          "UAG": ("",True),
          "UGA": ("",True)
          }

def proteins(strand):
    """
    :param strand:
    :return:
    """

    codons = [Codons[strand[index:index+STEP]] for index in range(0,len(strand),STEP)]
    acids = []
    done = False
    i = 0
    while not done:
        if i >= len(codons):
            done = True
        elif codons[i][1]:
            done = True
        else:
            acids.append(codons[i][0])
            i +=1
    return acids
