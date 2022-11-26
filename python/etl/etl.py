def transform(legacy_data):
    scores = dict()

    for score,letters in legacy_data.items():
        for letter in letters:
            scores[letter.lower()]= score

    return scores