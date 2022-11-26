def commands(binary_str):
    actions = []
    if binary_str[-1] == '1':
        actions.append("wink")

    if binary_str[-2] == '1':
        actions.append("double blink")

    if binary_str[-3] == '1':
        actions.append("close your eyes")

    if binary_str[-4] == '1':
        actions.append("jump")

    return list(reversed(actions)) if binary_str[0] == '1' else actions