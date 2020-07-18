pub fn is_armstrong_number(num: u32) -> bool {
    let s = num.to_string();
    let digit_count = s.len() as u32;
    let sum: u32 = s
        .chars()
        .map(|c| c.to_digit(10).unwrap().pow(digit_count))
        .sum();

    sum == num
}
