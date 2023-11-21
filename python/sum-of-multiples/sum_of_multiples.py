def sum_of_multiples(limit, multiples):
    multiples = [n for n in multiples if n > 0]
    return sum([i for i in range(1, limit) if len([m for m in multiples if i % m == 0]) > 0])
