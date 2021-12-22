"""exercise"""
class Matrix:
    """
    class
    """
    def __init__(self, matrix_string):
        """
        :param self:
        :param matrix_string:
        """
        self.matrix = [[int(col) for col in row.split(' ')] for row in matrix_string.split('\n')]

    def row(self, index):
        """"
        :param self:
        :param index:
        :return:
        """
        return self.matrix[index-1]

    def column(self, index):
        """
        :param self:
        :param index:
        :return:
        """
        return [row[index-1] for row in self.matrix]
