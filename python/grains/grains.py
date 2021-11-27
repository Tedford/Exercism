def square(number):
    """
    :param number: the chess square number
    :return: the number of rice grains present on the square

    """
    if number < 1 or number > 64:
        raise ValueError("square must be between 1 and 64")

    return pow(2, number-1)

def total():
    """
    :return: the total number of rice squares present on the chessboard
    """
    return sum([square(i) for i in range(1,65)])
