""""exercise"""

import re

def abbreviate(words):
    """
    :param words:
    :return:
    """
    words = words.replace("'","")
    words = re.sub("(?i)[^a-z]{1,}"," ",words)
    return "".join([word[0] for word in words.split(' ')]).upper()
