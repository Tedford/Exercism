"""exercise"""

ABUNDANT = "abundant"
DEFICIENT = "deficient"
PERFECT = "perfect"

def classify(number):
    """ A perfect number equals the sum of its positive divisors.

    :param number: int a positive integer
    :return: str the classification of the input integer
    """

    # if a number to be classified is less than 1.
    if number < 1:
        raise ValueError("Classification is only possible for positive integers.")

    aliquot_sum = sum([i for i in range(1,number//2+1) if number % i == 0])
    if aliquot_sum == number:
        classification = PERFECT
    elif aliquot_sum < number:
        classification = DEFICIENT
    else:
        classification = ABUNDANT

    return classification
