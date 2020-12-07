use std::fmt;

const MINUTES_PER_HOUR: i32 = 60;
const HOURS_PER_DAY: i32 = 24;
const MINUTES_PER_DAY: i32 = MINUTES_PER_HOUR * HOURS_PER_DAY;

#[derive(PartialEq, Debug)]
pub struct Clock {
    offset: i32,
}

impl Clock {
    fn calculate_offset(base: i32, change: i32) -> i32 {
        (base + change).rem_euclid(MINUTES_PER_DAY)
    }

    pub fn hours(&self) -> i32 {
        self.offset.div_euclid(MINUTES_PER_HOUR)
    }

    pub fn minutes(&self) -> i32 {
        self.offset.rem_euclid(MINUTES_PER_HOUR)
    }

    pub fn new(hours: i32, minutes: i32) -> Self {
        Clock {
            offset: Clock::calculate_offset(0, hours * MINUTES_PER_HOUR + minutes)
        }
    }

    pub fn add_minutes(&self, minutes: i32) -> Self {
        Clock {
            offset: Self::calculate_offset(self.offset, minutes),
        }
    }
}

impl fmt::Display for Clock {
    fn fmt(&self, f: &mut fmt::Formatter) -> fmt::Result {
        write!(f, "{:0>2}:{:0>2}", &self.hours(), self.minutes())
    }
}
