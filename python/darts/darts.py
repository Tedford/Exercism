"""exercise"""
import math

def score(x, y):
    """
    :param x:
    :param y:
    :return:
    """

    dist = math.sqrt(x**2 + y**2)

    if dist <= 1:
        result = 10
    elif dist <= 5:
        result = 5
    elif dist <= 10:
        result = 1
    else:
        result = 0

    return result
