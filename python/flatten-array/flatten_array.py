def flatten(iterable):
    output = []

    for slice in iterable:
        if hasattr(slice, "__len__"):
            output.extend(flatten(slice))
        elif slice != None:
            output.append(slice)

    return output