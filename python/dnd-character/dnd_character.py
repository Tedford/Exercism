"""exercise"""
import random
import math

class Character:
    """
    present a rolled character sheet
    """
    def __init__(self):
        self.strength = self.ability()
        self.dexterity = self.ability()
        self.constitution = self.ability()
        self.intelligence = self.ability()
        self.wisdom= self.ability()
        self.charisma= self.ability()
        self.hitpoints = modifier(self.constitution) + 10

    def ability(self):
        """
        :return: a valid ability score
        """
        rolls = [random.randrange(1,6) for _ in range(0,4)]
        rolls.sort()
        return sum(rolls[1::])


def modifier(stat):
    """
    :param stat:
    :return:
    """
    return math.floor((stat - 10) / 2)
