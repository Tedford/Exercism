"""exercise"""

def latest(scores):
    """
    :param scores:
    :return:
    """
    return scores[-1]


def personal_best(scores):
    """
    :param scores:
    :return:
    """
    scores.sort()
    return scores[-1]


def personal_top_three(scores):
    """
    :param scores:
    :return:
    """
    scores.sort()
    return scores[-3:][::-1]
