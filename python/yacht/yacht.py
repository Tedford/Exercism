"""
This exercise stub and the test suite contain several enumerated constants.

Since Python 2 does not have the enum module, the idiomatic way to write
enumerated constants has traditionally been a NAME assigned to an arbitrary,
but unique value. An integer is traditionally used because it’s memory
efficient.
It is a common practice to export both constants and functions that work with
those constants (ex. the constants in the os, subprocess and re modules).

You can learn more here: https://en.wikipedia.org/wiki/Enumerated_type
"""


# Score categories.
# Change the values as you see fit.

YACHT = "Y"
ONES = "1"
TWOS = "2"
THREES = "3"
FOURS = "4"
FIVES = "5"
SIXES = "6"
FULL_HOUSE = "FH"
FOUR_OF_A_KIND = "F"
LITTLE_STRAIGHT = "LS"
BIG_STRAIGHT = "BS"
CHOICE = "C"


def score(dice, category):
    """
    :param dice:
    :param category:
    :return:
    """

    if category == YACHT:
        result = 50 if len(set(dice)) == 1 else 0
    elif category == ONES:
        result = score_number(dice,1)
    elif category == TWOS:
        result = score_number(dice,2)
    elif category== THREES:
        result = score_number(dice,3)
    elif category== FOURS:
        result = score_number(dice,4)
    elif category== FIVES:
        result = score_number(dice,5)
    elif category== SIXES:
        result = score_number(dice,6)
    elif category== FULL_HOUSE:
        result = score_full_house(dice)
    elif category== FOUR_OF_A_KIND:
        result = score_four_of_a_kind(dice)
    elif category== LITTLE_STRAIGHT:
        result = 0 if set(dice) != set(range(1,6)) else 30
    elif category== BIG_STRAIGHT:
        result = 0 if set(dice) != set(range(2,7)) else 30
    else:
        result = sum(dice)

    return result

def score_number(dice, number):
    """
    :param dice:
    :return:
    """
    return dice.count(number) * number

def score_full_house(dice):
    """
    :param dice:
    :return:
    """
    dice_set = [(d,dice.count(d)) for d in set(dice)]
    return 0 if len(dice_set) != 2 or {dice_set[0][1], dice_set[1][1]} != set([2,3]) else sum(dice)

def score_four_of_a_kind(dice):
    """
    :param dice:
    :return:
    """

    repeats = [(d, dice.count(d)) for d in dice[0:2] if dice.count(d) > 1]
    repeats.sort( key = lambda e : e[1],reverse=True)

    return 0 if len(repeats) == 0 or repeats[0][1] < 4 else 4 * repeats[0][0]
