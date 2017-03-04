import re

def is_pangram(string):
    return len(set(re.sub("[^a-z]", "", string.lower()))) == 26
