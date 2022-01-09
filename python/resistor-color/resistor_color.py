"""exercise"""
COLOR_ENCODING = {
    "black": 0,
    "brown": 1,
    "red": 2,
    "orange": 3,
    "yellow": 4,
    "green": 5,
    "blue": 6,
    "violet": 7,
    "grey": 8,
    "white": 9
}

def color_code(color):
    """
    :param color:
    :return:
    """
    return COLOR_ENCODING[color]


def colors():
    """
    :return:
    """
    return [key for key in COLOR_ENCODING]
