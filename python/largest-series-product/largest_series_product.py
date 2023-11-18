import functools
import operator

def largest_product(series, size):
    if size < 1:
        raise ValueError("span must not be negative")
    
    if size > len(series):
        raise ValueError("span must be smaller than string length")
    
    if not all(c.isdigit() for c in series):
        raise ValueError("digits input must only contain digits")

    products = [functools.reduce(operator.mul, [int(d) for d in series[i:(i+size)]]) for i in range(len(series)-size+1)]
    products.sort(reverse=True)
    return products[0]
    
