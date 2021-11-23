
"""exercise"""
FAILING = 40


def round_scores(student_scores):
    """
    :param student_scores: list of student exam scores as float or int.
    :return: list of student scores *rounded* to nearest integer value.
    """
    rounded = []
    for score in student_scores:
        rounded.append(round(score))

    return rounded


def count_failed_students(student_scores):
    """
    :param student_scores: list of integer student scores.
    :return: integer count of student scores at or below 40.
    """
    failed = 0
    for score in student_scores:
        if score <= FAILING:
            failed += 1

    return failed


def above_threshold(student_scores, threshold):
    """
    :param student_scores: list of integer scores
    :param threshold :  integer
    :return: list of integer scores that are at or above the "best" threshold.
    """
    above = []
    for score in student_scores:
        if score >= threshold:
            above.append(score)
    return above


def letter_grades(highest):
    """
    :param highest: integer of highest exam score.
    :return: list of integer lower threshold scores for each D-A letter grade interval.
             For example, where the highest score is 100, and failing is <= 40,
             The result would be [41, 56, 71, 86]:

             41 <= "D" <= 55
             56 <= "C" <= 70
             71 <= "B" <= 85
             86 <= "A" <= 100
    """
    step = int((highest - FAILING)/4)
    scores = []
    for i in range(0,4):
        scores.append(FAILING + 1 + i * step)
    return scores


def student_ranking(student_scores, student_names):
    """
     :param student_scores: list of scores in descending order.
     :param student_names: list of names in descending order by exam score.
     :return: list of strings in format ["<rank>. <student name>: <score>"].
     """

    rankings= []

    for i, score in enumerate(student_scores):
        rankings.append(f'{i+1}. {student_names[i]}: {score}')

    return rankings


def perfect_score(student_info):
    """
    :param student_info: list of [<student name>, <score>] lists
    :return: first `[<student name>, 100]` or `[]` if no student score of 100 is found.
    """
    perfect = []

    for student in student_info:
        if student[1] == 100:
            perfect = student
            break

    return perfect
