def is_valid(isbn):
    checksum = 0
    digit = 0
    valid = True
    for c in isbn:
        if c.isdigit():
            checksum = checksum + int(c) * (10-digit)
            digit += 1
        elif digit == 9 and c == "X":
            checksum += 10 
            digit += 1
        elif c != "-":
            valid = False
    valid &= digit == 10    
    
    return valid and checksum % 11 == 0