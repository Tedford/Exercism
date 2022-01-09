"""exercise"""

DAYS =  ['first','second','third','fourth','fifth','sixth','seventh','eighth','ninth','tenth','eleventh','twelfth']
GIFTS = ["a Partridge in a Pear Tree.","two Turtle Doves","three French Hens","four Calling Birds","five Gold Rings","six Geese-a-Laying","seven Swans-a-Swimming","eight Maids-a-Milking","nine Ladies Dancing","ten Lords-a-Leaping","eleven Pipers Piping","twelve Drummers Drumming" ]


def sing(verse):
    """
    :param verse:
    :return:
    """
    preamble = f'On the {DAYS[verse-1]} day of Christmas my true love gave to me: '
    verses = ", ".join([GIFTS[day-1] for day in range(verse, 1, -1)])
    verses += (", and " if verse > 1 else "") + GIFTS[0]

    return preamble + verses

def recite(start_verse, end_verse):
    """
    :param start_verse:
    :param end_verse:
    :return:
    """

    return [sing(verse) for verse in range(start_verse, end_verse+1)]
