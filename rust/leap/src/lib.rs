pub fn is_leap_year(year: u64) -> bool {
    let is_mod4 = year % 4 == 0;
    let is_divisible_by_100 = year % 100 == 0;
    let is_divisible_by_400 = year % 400 == 0;

    is_mod4 && (!is_divisible_by_100 || is_divisible_by_400)
}
