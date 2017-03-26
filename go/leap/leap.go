package leap

const testVersion = 3

// IsLeapYear test if a provided year is a leapyear
func IsLeapYear(year int) bool {
	return year%4 == 0 && (year%100 != 0 || (year%100 == 0 && year%400 == 0))
}
