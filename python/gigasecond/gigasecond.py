import datetime
import math

def add_gigasecond(date):
    return date + datetime.timedelta(0, math.pow(10, 9))
