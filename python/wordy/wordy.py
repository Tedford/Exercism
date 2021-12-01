"""exercise"""

OPERATORS = {"plus": lambda x, y: x+y,
             "minus": lambda x, y: x-y,
             "multiplied": lambda x, y: x * y,
             "divided": lambda x, y: x/y}


def answer(question):
    """
    :param question:
    :return:
    """
    tokens = question[0:-1].replace(" by", "").split(' ')
    operation = " ".join(tokens[0:2])
    tokens = tokens[2:]

    if operation != "What is":
        raise ValueError("unknown operation")

    if len(tokens) == 0:
        raise ValueError("syntax error")

    operands = []
    operator = None

    for i, token in enumerate(tokens):
        if i % 2 == 0:
            try:
                operands.append(int(token))
            except Exception:
                raise ValueError("syntax error") from Exception
        else:
            if token in OPERATORS:
                operator = OPERATORS[token]
            elif token.replace("-", "").isdigit():
                raise ValueError("syntax error")
            else:
                raise ValueError("unknown operation")

        if len(operands) == 2 and operator is not None:
            operands = [operator(operands[0], operands[1])]
            operator = None

    if operator is not None:
        raise ValueError("syntax error")

    return operands[0]
