def is_leap_year(year):
    by4 = year % 4 == 0
    by100 = year % 100 == 0
    by400 = year % 400 == 0
    return by4 and (not by100 or (by100 and by400))
