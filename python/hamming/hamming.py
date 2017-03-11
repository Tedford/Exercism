def distance(strand1, strand2):
    if len(strand1) != len(strand2):
        raise ValueError("The two DNA strands are not equal length")

    d = 0
    for s1, s2 in zip(strand1, strand2):
        d+= 1 if s1 != s2 else 0

    return d
