"""exercise"""
import string

def rotate(text, key):
    """
    :param text:
    :param key:
    :return:
    """
    translated =string.ascii_lowercase[key:] + string.ascii_lowercase[:key]
    table = str.maketrans(string.ascii_letters, translated + translated.upper())
    return text.translate(table)
