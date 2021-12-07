"""exercise"""

class Point:
    """Represents a position within the grid"""

    def __init__(self, x, y):
        """
        :param self:
        :param x:
        :param y:
        """
        self.x = x
        self.y = y

    def __repr__(self):
        return 'Point({}:{})'.format(self.x, self.y)

    def __eq__(self, other):
        """
        :param self:
        :param other:
        :return:
        """
        return self.x == other.x and self.y == other.y


class WordSearch:
    """Represents the puzzle plane"""

    def __init__(self, puzzle):
        """
        :param self:
        :param puzzle:
        """
        self.rows = len(puzzle)
        self.cols = len(puzzle[0])
        self.puzzle = puzzle

    def search(self, word):
        """
        :param self:
        :param word:
        """

        coordinates = None

        # check left to right and right to left
        for row, text in enumerate(self.puzzle):
            rev = text[::-1]
            if word in text:
                p0 = Point(text.index(word), row)
                p1 = Point(p0.x+len(word)-1, row)
                coordinates = (p0, p1)
            elif word in rev:
                p1 = Point(len(text)-rev.index(word)-1, row)
                p0 = Point(p1.x - len(word)+1, row)
                coordinates = (p1, p0)

        # check up and down and down and up
        if coordinates is None:
            for col in range(0,self.cols):
                letters = []
                for row, line in enumerate(self.puzzle):
                    letters.append(line[col])
                text = ''.join(letters)
                rev = text[::-1]
                if word in text:
                    p0 = Point(col,text.index(word))
                    p1 = Point(col,p0.y+len(word)-1)
                    coordinates = (p0, p1)
                elif word in rev:
                    p1 = Point(col,len(text)-rev.index(word)-1)
                    p0 = Point(col,p1.y - len(word)+1)
                    coordinates = (p1, p0)

        # check diagonally left to right
        if coordinates is None:
            for row in range(0, self.rows - len(word)):
                for offset in range(0,self.cols-len(word)):
                    if coordinates is not None:
                        break
                    letters = []
                    for col in range(0, min(self.cols  - offset,self.rows - row)):
                        letters.append(self.puzzle[row+col][offset+col])
                    text = ''.join(letters)
                    rev = text[::-1]

                    if word in text:
                        p0 = Point(offset,row)
                        p1 = Point(p0.x +len(word) -1,p0.y+len(word)-1)
                        coordinates = (p0, p1)
                    elif word in rev:
                        p1 = Point(len(rev) - rev.index(word) + offset - 1,len(text) - rev.index(word) + row - 1)
                        p0 = Point(p1.x - len(word)+1,p1.y-len(word)+1)
                        coordinates = (p1, p0)
            row += 1

        # check diagonally right to left
        if coordinates is None:
            for row in range(0, self.rows - len(word)):
                for offset in range(self.cols-1, len(word),-1):
                    if coordinates is not None:
                        break
                    letters = []
                    for col in range(0, min(offset,self.rows - row-1)+1):
                        letters.append(self.puzzle[row+col][offset-col])
                    text = ''.join(letters)
                    rev = text[::-1]

                    if word in text:
                        p0 = Point(offset-text.find(word),row+text.find(word))
                        p1 = Point(p0.x -len(word) +1,p0.y+len(word)-1)
                        coordinates = (p0, p1)
                    elif word in rev:
                        p1 = Point(rev.index(word),len(text) - rev.index(word) + row - 1)
                        p0 = Point(p1.x + len(word)-1,p1.y-len(word)+1)
                        coordinates = (p1, p0)

            row += 1

        return coordinates
