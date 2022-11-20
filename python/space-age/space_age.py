class SpaceAge:
    def __init__(self, seconds):
        self.seconds = seconds

    def on_earth(self):
        return self.truncate(self.normalized())

    def on_mercury(self):
        return self.truncate(self.normalized() / 0.2408467)

    def on_venus(self):
        return self.truncate(self.normalized() / 0.61519726)

    def on_mars(self):
        return self.truncate(self.normalized() / 1.8808158)

    def on_jupiter(self):
        return self.truncate(self.normalized() / 11.862615)

    def on_saturn(self):
        return self.truncate(self.normalized() / 29.447498)

    def on_uranus(self):
        return self.truncate(self.normalized() / 84.016846)

    def on_neptune(self):
        return self.truncate(self.normalized() / 164.79132)

    def truncate(self, number):
        return round(number, 2)

    def normalized(self):
        return self.seconds / 31557600
