"""exercise"""

def is_triange(test):
    """
    :param sides: length of sides
    :return: True if a triangle; otherwise, false
    """
    return lambda sides: all(length > 0 for length in sides) and 2*max(sides) < sum(sides) and test(sides)


@is_triange
def equilateral(sides):
    """
    :param sides: length of sides
    """
    return (sides[0] == sides[1]) and (sides[1] == sides[2])


@is_triange
def isosceles(sides):
    """
    :param sides: length of sides
    """
    return ((sides[0] == sides[1]) or (sides[1] == sides[2]) or (sides[0] == sides[2]))


@is_triange
def scalene(sides):
    """
    :param sides: length of sides
    """
    return sides[0] != sides[1] and sides[1] != sides[2] and sides[0] != sides[2]
