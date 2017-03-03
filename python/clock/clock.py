class Clock(object):

    def minutesPerDay(self):
        return 24 * 60

    def __init__(self, hours, minutes):
        self.offset = (minutes + 60 * hours) % self.minutesPerDay()

    def __eq__(self, other):
        return self.offset == other.offset

    def __str__(self):
        hours = self.offset / 60
        minutes = self.offset % 60
        return "{:02d}:{:02d}".format(hours, minutes)

    def add(self, minutes):
        self.offset = (self.offset + minutes) % self.minutesPerDay()
        return self
