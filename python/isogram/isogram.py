import re

def is_isogram(word):
    letters = re.sub("[^a-z]", "", word.lower())
    return len(set(letters)) == len(letters)
