"""exercise"""

class Luhn:
    """calculate lunh checksums"""
    def __init__(self, card_num):
        """
        :param self:
        :param card_num:
        :return:
        """
        self.card_num = card_num


    def valid(self):
        """
        :param self:
        :return:
        """

        minimized = self.card_num.replace(" ", "")

        if len(minimized) > 1 and minimized.isdigit():
            double = False
            crc = []

            for i in range(len(minimized)-1,-1,-1):
                digit = int(minimized[i])
                if double:
                    digit *= 2
                    crc.append(digit if digit < 9 else digit - 9)
                else:
                    crc.append(digit)
                double = not double
            is_valid = sum(crc) % 10 == 0
        else:
            is_valid = False

        return is_valid
