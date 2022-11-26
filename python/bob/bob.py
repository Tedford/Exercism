def response(hey_bob):
    hey_bob = hey_bob.rstrip().lstrip()
    is_question = len(hey_bob) == 0 or hey_bob[-1] == '?'
    is_empty = len([c for c in hey_bob if c.isspace()]) == len(hey_bob)
    has_words = len([c for c in hey_bob if c.isalpha()]) == 0
    is_yelling = hey_bob == hey_bob.upper() and not has_words

    if is_empty:
        response = "Fine. Be that way!"
    elif is_yelling and is_question:
        response = "Calm down, I know what I'm doing!"
    elif is_question:
        response = "Sure."
    elif is_yelling:
        response  = "Whoa, chill out!"
    else:
        response = "Whatever."

    return response

