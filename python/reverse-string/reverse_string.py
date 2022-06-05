"""Exercise"""
def reverse(text):
    """
    :param text:
    :return:
    """
    return ''.join([text[i-1] for i in range(len(text), 0, -1)])
