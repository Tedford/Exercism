import re

mappings = {'G' : "C",
            'C' : "G",
            'T' : "A",
            'A' : "U"
}

def to_rna(strand):
    result = ""
    if re.match("^[GCTA]+$", strand):
        for c in strand:
            result += mappings[c]
    return result

