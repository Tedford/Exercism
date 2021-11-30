"""exercise"""

ALPHABET_LENGTH = 26
GROUP_LENGTH = 5
BASE = ord('a')


def encode(plain_text, a, b):
    """
    :param plain_text:
    :param a:
    :param b:
    :return:
    """
    assert_coprime(a)

    written = 0
    encoded = []

    for c in plain_text.lower():
        if c.isdigit():
            encoded.append(c)
            written += 1
            if written % GROUP_LENGTH == 0:
                encoded.append(" ")
        else:
            offset = ord(c) - BASE
            if 0 <= offset < ALPHABET_LENGTH:
                cprime = chr(BASE + (a * offset + b) % ALPHABET_LENGTH)
                encoded.append(cprime)
                written += 1
                if written % GROUP_LENGTH == 0:
                    encoded.append(" ")

    return ("".join(encoded)).strip()


def calculate_mmi(a):
    """
    :param a:
    :return:
    """
    values = [x for x in range(1, ALPHABET_LENGTH)
              if (a * x) % ALPHABET_LENGTH == 1]
    return values[0] if len(values) > 0 else 1


def decode(ciphered_text, a, b):
    """
    :param ciphered_text:
    :param a:
    :param b:
    :return:
    """

    assert_coprime(a)

    mmi = calculate_mmi(a)
    letters = []

    for c in ciphered_text:
        if c.isalpha():
            offset = ord(c) - BASE
            x = mmi * (offset - b) % ALPHABET_LENGTH
            letters.append(chr(ALPHABET_LENGTH+x+BASE)
                           if x < 0 else chr(x + BASE))
        elif c.isdigit():
            letters.append(c)

    return "".join(letters)


def assert_coprime(a):
    """
    :param a:
    :return:
    """

    def gcd(x, y):
        """
        :param x:
        :param y:
        :return:
        """
        return x if y == 0 else gcd(y, x % y)

    if gcd(a, ALPHABET_LENGTH) != 1:
        raise ValueError("a and m must be coprime.")
