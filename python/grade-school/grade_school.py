"""exercise"""

class School:
    """school"""

    def __init__(self):
        """ctor"""
        self.enrollment = dict()
        self.enrollment_actions = []

    def add_student(self, name, grade):
        """
        :param self:
        :param name:
        :param grade:
        """

        if not name in self.enrollment:
            self.enrollment[name] = grade
            self.enrollment_actions.append(True)
        else:
            self.enrollment_actions.append(False)

    def added(self):
        """
        :param self:
        :return:
        """
        return self.enrollment_actions

    def roster(self):
        """
        :param self:
        :param grade_number:
        :return:
        """
        grades = list({grade for _, grade in self.enrollment.items()})
        grades.sort()

        sortered_roster = []

        for grade in grades:
            sortered_roster += self.grade(grade)

        return sortered_roster

    def grade(self, grade_number):
        """
        :param self:
        :param grade_number:
        :return:
        """
        grade_roster = [student for student, grade in self.enrollment.items() if grade == grade_number]
        grade_roster.sort()
        return grade_roster
