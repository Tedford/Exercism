"""exercise"""


def equilateral(sides):
    """
    :param sides: length of sides
    """
    return is_triange(sides) and (sides[0] == sides[1]) and (sides[1] == sides[2])


def isosceles(sides):
    """
    :param sides: length of sides
    """
    return is_triange(sides) and ((sides[0] == sides[1]) or (sides[1]==sides[2]) or (sides[0] == sides[2]))


def scalene(sides):
    """
    :param sides: length of sides
    """
    return is_triange(sides) and sides[0] != sides[1] and sides[1] != sides[2] and sides[0] != sides[2]


def is_triange(sides):
    """
    :param sides: length of sides
    :return: True if a triangle; otherwise, false
    """
    sides.sort()
    is_three_sides = len(sides) == 3
    non_zero_length = all(length > 0 for length in sides)
    not_degenerate = sides[0] + sides[1] > sides[2]
    return  is_three_sides and  non_zero_length and not_degenerate
