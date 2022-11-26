def sum_of_multiples(limit, multiples):
    multiples = [n for n in multiples if n > 0]
    factors = []
    for i in range(1, limit, 1):
        if len([m for m in multiples if i % m == 0]) > 0:
            factors.append(i)

    return sum(factors)
