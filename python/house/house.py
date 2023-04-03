"""exercise"""

POEM = [
    "that belonged to the farmer sowing his corn",
    "that kept the rooster that crowed in the morn",
    "that woke the priest all shaven and shorn",
    "that married the man all tattered and torn",
    "that kissed the maiden all forlorn",
    "that milked the cow with the crumpled horn",
    "that tossed the dog",
    "that worried the cat",
    "that killed the rat",
    "that ate the malt",
    "that lay in the house that Jack built."
]

STARTERS = [
    "This is the horse and the hound and the horn",
    "This is the farmer sowing his corn",
    "This is the rooster that crowed in the morn",
    "This is the priest all shaven and shorn",
    "This is the man all tattered and torn",
    "This is the maiden all forlorn",
    "This is the cow with the crumpled horn",
    "This is the dog",
    "This is the cat",
    "This is the rat",
    "This is the malt",
    "This is the house that Jack built."
]


def verse(number):
    """
    :param number: the verse to generate
    :return: the constructed verse as a string
    """
    return ' '.join([STARTERS[-1*number]] + ([''] if number ==
                    1 else POEM[-1 * (number-1)::])).rstrip()

def recite(start_verse, end_verse):
    """
    :param start_verse: the first verse to generate
    :param end_verse: the last verse to generate
    :return: the poem verses as an array
    """
    return [verse(number) for number in range(start_verse, start_verse + end_verse-start_verse + 1)]
