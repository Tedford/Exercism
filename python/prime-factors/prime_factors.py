"""exercise"""


def factors(value):
    """
    :param value:
    :return:
    """
    factorized = []
    factor = 2
    remainder = value

    while factor <= remainder:
        if remainder % factor == 0:
            factorized.append(factor)
            remainder = remainder / factor
        else:
            factor += 1

    return factorized
