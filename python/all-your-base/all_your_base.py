def rebase(input_base, digits, output_base):
    if input_base < 2:
        raise ValueError("input base must be >= 2")

    if output_base < 2:
        raise ValueError("output base must be >= 2")

    if not all([d > -1 and d < input_base for d in digits]):
        raise ValueError("all digits must satisfy 0 <= d < input base")

    base10 = sum([ input_base ** place * digit for place, digit in enumerate(reversed(digits))])

    if base10 == 0:
        output = [0]
    else:
        output = []
        remainder = base10
        while remainder > 0:
            digit = remainder % output_base
            remainder = remainder // output_base
            output.insert(0,digit)

    return output