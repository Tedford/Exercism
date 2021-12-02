"""exercise"""

def grep(pattern, flags, files):
    """
    :param pattern:
    :param flags:
    :param files:
    :return:
    """

    flags = set(flags.split(' '))

    matches = []

    for file in files:
        included = False
        with open(file, encoding="utf-8") as handle:
            for line, text in enumerate(handle.readlines()):
                if "-i" in flags and "-x" in flags:
                    matched = pattern.lower() == text.lower().rstrip()
                elif "-i" in flags:
                    matched = pattern.lower() in text.lower()
                elif "-x" in flags:
                    matched = pattern == text.rstrip()
                else:
                    matched = pattern in text

                if "-v" in flags:
                    matched = not matched

                if matched:
                    if "-l" in flags:
                        text = file + "\n"
                        matched = True if not included else False
                        included = True
                    elif "-n" in flags:
                        text = f'{line+1}:{text}'

                    if len(files) > 1 and not "-l" in flags:
                        text = f'{file}:{text}'

                if matched:
                    matches.append(text)

    return "".join(matches)
