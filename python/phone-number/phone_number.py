"""exercise"""

ALLOWED_PUNCTUATION = ['-','(',')','.','+']

class PhoneNumber:
    """represents a phone number"""
    def __init__(self, number):
        digits = []

        for c in number:
            if c.isdigit():
                digits.append(c)
            elif c in ALLOWED_PUNCTUATION:
                pass
            elif c.isalpha():
                raise ValueError("letters not permitted")
            elif not c.isspace():
                raise ValueError("punctuations not permitted")

        digits = "".join(digits)

        if len(digits) > 11:
            raise ValueError("more than 11 digits")

        country_code = None if len(digits) != 11 else digits[0]
        num = digits if country_code is None else digits[1:]

        if country_code is not None and country_code != "1":
            raise ValueError("11 digits must start with 1")

        if len(num) != 10:
            raise ValueError("incorrect number of digits")

        # area code validation
        if int(num[0]) == 0:
            raise ValueError("area code cannot start with zero")
        if int(num[0]) == 1:
            raise ValueError("area code cannot start with one")

        # exchange validation
        if int(num[3]) == 0:
            raise ValueError("exchange code cannot start with zero")
        if int(num[3]) == 1:
            raise ValueError("exchange code cannot start with one")

        self.number = num
        self.area_code = num[0:3]
        self.exchange = num[3:6]
        self.subscriber = num[6:]

    def pretty(self):
        """
        :return: the formatted 10 digit phone number
        """
        return f'({self.area_code})-{self.exchange}-{self.subscriber}'
