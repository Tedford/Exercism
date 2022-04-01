"""exercise"""


def is_armstrong_number(number):
    """
    :param number:
    :return:
    """
    text = str(number)
    length = len(text)
    return number == sum([pow(int(c),length) for c in text])
