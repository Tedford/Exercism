"""exercise"""

NAMES = {
    "G": "Grass",
    "C": "Clover",
    "R": "Radishes",
    "V": "Violets"
}

class Garden:

    """class"""
    def __init__(self, diagram, students = None):
        """ctor"""
        students = students if students is not None else  ["Alice", "Bob", "Charlie", "David", "Eve", "Fred","Ginny","Harriet", "Ileana","Joseph","Kincaid","Larry"]
        students.sort()
        self.students = students
        self.diagram = [letter for row in diagram.split('\n') for letter in row]

    def plants(self, student):
        """
        :param self:
        :param student:
        :return:
        """

        shelf_width = len(self.diagram)//2
        results = []
        nth = self.students.index(student)
        for index in range(0,2):
            results.insert(index, NAMES[self.diagram[nth * 2 + index]])
            results.insert(index*2+2, NAMES[self.diagram[nth * 2 + index + shelf_width]])

        return results
