"""exercise"""
def square_root(number):
    """
    :param number:
    :return:
    """
    return 1 if number == 1 else [n for n in range(1,(number // 2)+1) if n * n == number][0]
