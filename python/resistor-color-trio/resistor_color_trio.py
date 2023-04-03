"""exercise"""

BANDS = {"black": '0', "brown": '1', "red": '2', "orange": '3', "yellow": '4',
         "green": '5', "blue": '6', "violet": '7', "grey": '8', "white": '9'}


def label(colors):
    """
    :param colors: coded string of resister colors
    :return: the human friendly label
    """
    magnitude = int(''.join(
        [BANDS[color] for color in colors[0:2]])) * pow(10, int(BANDS[colors[2]]))

    if magnitude > 1_000_000_000:
        unit = "giga"
        magnitude //= 1_000_000_000
    elif magnitude > 1_000_000:
        unit = "mega"
        magnitude //= 1_000_000
    elif magnitude > 1000:
        unit = "kilo"
        magnitude //= 1000
    else:
        unit = ""

    return f"{magnitude} {unit}ohms"
