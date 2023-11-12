use std::fmt::{Display, Formatter, Result};

pub struct Roman {
    formatted: String,
}

impl Display for Roman {
    fn fmt(&self, _f: &mut Formatter<'_>) -> Result {
        write!(_f, "{}", self.formatted)
    }
}

impl Roman {
    fn construct_roman_digit(value_set: (char, char, char), digit: char) -> String {
        let (i, v, x) = value_set;
        match digit {
            '1' => format!("{}", i),
            '2' => format!("{}{}", i, i),
            '3' => format!("{}{}{}", i, i, i),
            '4' => format!("{}{}", i, v),
            '5' => format!("{}", v),
            '6' => format!("{}{}", v, i),
            '7' => format!("{}{}{}", v, i, i),
            '8' => format!("{}{}{}{}", v, i, i, i),
            '9' => format!("{}{}", i, x),
            _ => "".to_string(),
        }
    }
}

impl From<u32> for Roman {
    fn from(num: u32) -> Self {
        let s = format!("{}", num);
        let length = s.len();
        let formatted = s
            .chars()
            .enumerate()
            .map(|(i, e)| {
                Roman::construct_roman_digit(
                    match length - i - 1 {
                        0 => ('I', 'V', 'X'),
                        1 => ('X', 'L', 'C'),
                        2 => ('C', 'D', 'M'),
                        _ => ('M', 'M', 'M'),
                    },
                    e,
                )
            })
            .collect::<Vec<String>>()
            .join("");
        Roman { formatted }
    }
}
