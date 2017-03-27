from collections import Counter

def word_count(phrase):
    encoded = phrase.decode('utf-8')

    normalized = ""
    for char in encoded.lower():
        current = unicode(char)
        normalized += current if current.isnumeric() or current.isalpha() else " "

    words = normalized.split()

    return Counter(words)
