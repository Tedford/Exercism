"""exercise"""
# Game status categories
# Change the values as you see fit
STATUS_WIN = 'win'
STATUS_LOSE = 'lose'
STATUS_ONGOING = 'ongoing'


class Hangman:
    """
    hangman game
    """
    def __init__(self, word):
        self.remaining_guesses = 9
        self.status = STATUS_ONGOING
        self.guessed = [False for _ in word]
        self.word = word

    def guess(self, char):
        """
        :param self:
        :param char:
        """
        if self.status != STATUS_ONGOING:
            raise ValueError("The game has already ended.")

        count_correct = lambda : sum([1 if correct else 0 for correct in self.guessed])

        original_correct = count_correct()
        for index,c in enumerate(self.word):
            self.guessed[index] |= c == char
        final_correct = count_correct()

        if original_correct == final_correct:
            self.remaining_guesses -= 1

        if all(self.guessed):
            self.status = STATUS_WIN
        elif self.remaining_guesses < 0:
            self.status = STATUS_LOSE

    def get_masked_word(self):
        """
        :param self:
        :param char:
        :return:
        """
        return ''.join([self.word[i] if self.guessed[i] else '_' for i in range(0, len(self.word))])

    def get_status(self):
        """
        :param self:
        :return:
        """
        return self.status
