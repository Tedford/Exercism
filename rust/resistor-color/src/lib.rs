use enum_iterator::{all, Sequence};
use int_enum::IntEnum;

#[derive(Clone, Copy, Debug, PartialEq, Eq, IntEnum, Sequence)]
#[repr(u32)]
pub enum ResistorColor {
    Black = 0,
    Brown = 1,
    Red = 2,
    Orange = 3,
    Yellow = 4,
    Green = 5,
    Blue = 6,
    Violet = 7,
    Grey = 8,
    White = 9,
}

pub fn color_to_value(color: ResistorColor) -> u32 {
    color as u32
}

pub fn value_to_color_string(value: u32) -> String {
    ResistorColor::from_int(value)
        .map(|c| format!("{:?}", c))
        .unwrap_or_else(|_| "value out of range".to_owned())
}

pub fn colors() -> Vec<ResistorColor> {
    all::<ResistorColor>().collect()
}
