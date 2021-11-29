"""exercise"""


def steps(number):
    """
    :param number: N
    :return: number of steps
    """
    if number < 1:
        raise ValueError("Only positive numbers are allowed")

    steps = 0
    while number != 1:
        number = number * 3 + 1 if number % 2 == 1 else number / 2
        steps += 1

    return steps
