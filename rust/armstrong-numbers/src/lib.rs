pub fn is_armstrong_number(num: u32) -> bool {
    let s= num.to_string();
    let digits = s.chars().map(|c| c.to_digit(10).unwrap());
    let digit_count = s.chars().count() as u32;

    let sum : u32 = digits.map(|d| d.pow(digit_count)).sum();

    sum == num
}