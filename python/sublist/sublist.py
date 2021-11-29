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

# Possible sublist categories.
# Change the values as you see fit.
SUBLIST = 0
SUPERLIST = 1
EQUAL = 2
UNEQUAL = 3


def sublist(list_one, list_two):
    """
    :param list_one:
    :param list_two"
    :return: one of SUBLIST, SUPERLIST, EQUAL, UNEQUAL
    """
    set1 = set(list_one)
    str1 = str(list_one)[1:-1]
    set2 = set(list_two)
    str2 = str(list_two)[1:-1]

    if set1 == set2 and str1 == str2:
        state = EQUAL
    elif set1.issubset(set2) and str1 in str2:
        state = SUBLIST
    elif set1.issuperset(set2) and str2 in str1:
        state = SUPERLIST
    else:
        state = UNEQUAL

    return state
