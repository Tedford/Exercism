"""exercise"""


def largest(min_factor, max_factor):
    """Given a range of numbers, find the largest palindromes which
       are products of two numbers within that range.

    :param min_factor: int with a default value of 0
    :param max_factor: int
    :return: tuple of (palindrome, iterable).
             Iterable should contain both factors of the palindrome in an arbitrary order.
    """
    if min_factor > max_factor:
        raise ValueError("min must be <= max")

    # product = None
    # factors = []
    # i = max_factor

    # while i > min_factor - 1 and len(factors) == 0:
    #     j = i
    #     while j < max_factor + 1 and len(factors) == 0:
    #         if is_palindrome(i*j):
    #             product = i * j
    #             factors.append((i, j))
    #         j += 1
    #     i -= 1

    # # determine factors
    # if len(factors) > 0:
    #     p0_i, _ = factors[0]

    #     for i in range(min_factor, p0_i):
    #         for j in range(min_factor, max_factor+1):
    #             if i * j == product:
    #                 factors.append((i, j))

    product = None
    factors = []
    i = max_factor

    while i > min_factor - 1 and len(factors) == 0:
        # for i in range(max_factor, min_factor, -1):
        j = i
        # for j in range(i, min_factor-1, -1):
        while j > min_factor - 1 and len(factors) == 0:
            if is_palindrome(i*j):
                product = i * j
                factors.append((i, j))
            j -= 1
        i -= 1
        # palindromes.append((i*j, [(i, j)]))
        #         break
        # if len(factors) > 1:
        #     break

    if len(factors) > 0:
        p0_i, _ = factors[0]

        for i in range(min_factor, p0_i):
            for j in range(min_factor, max_factor+1):
                if i * j == product:
                    factors.append((i, j))

    # palindromes = []
    # product = None
    # factors = []

    # for i in range(max_factor, min_factor, -1):
    #     for j in range(i, max_factor + 1):
    #         if is_palindrome(i*j):
    #             palindromes.append((i*j, [(i, j)]))
    #             break

    # if len(palindromes) > 0:
    #     palindromes.sort(key=lambda e: e[0])
    #     product, factors = palindromes[-1]

    #     p0_i, _ = factors[0]

    #     for i in range(min_factor, p0_i):
    #         for j in range(min_factor, max_factor+1):
    #             if i * j == product:
    #                 factors.append((i, j))

    return (product, factors)


def smallest(min_factor, max_factor):
    """Given a range of numbers, find the smallest palindromes which
    are products of two numbers within that range.

    :param min_factor: int with a default value of 0
    :param max_factor: int
    :return: tuple of (palindrome, iterable).
    Iterable should contain both factors of the palindrome in an arbitrary order.
    """
    if min_factor > max_factor:
        raise ValueError("min must be <= max")

    product = None
    factors = []
    i = min_factor

    while i < max_factor + 1 and len(factors) == 0:
        j = i
        while j < max_factor + 1 and len(factors) == 0:
            if is_palindrome(i*j):
                product = i * j
                factors.append((i, j))
            j += 1
        i += 1

    # determine factors
    if len(factors) > 0:
        p0_i, _ = factors[0]

        for i in range(p0_i+1, max_factor + 1):
            for j in range(i, max_factor+1):
                if i * j == product:
                    factors.append((i, j))

    return (product, factors)


def find_palindromes(min_factor, max_factor):
    """
    :param min_factor:
    :param max_factor:
    :return:
    """
    if min_factor > max_factor:
        raise ValueError("min must be <= max")

    palindromes = []
    for i in range(min_factor, max_factor+1):
        for j in range(i, max_factor + 1):
            if is_palindrome(i*j):
                palindromes.append((i*j, [i, j]))
                break

    return palindromes


def is_palindrome(number):
    """
    :param number:
    :return:
    """
    snumber = str(number)
    return snumber == snumber[::-1]
