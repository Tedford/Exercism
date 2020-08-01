use std::fmt;

const MINUTES_PER_HOUR: i32 = 60i32;
const HOURS_PER_DAY: i32 = 24i32;
const MINUTES_PER_DAY: i32 = MINUTES_PER_HOUR * HOURS_PER_DAY;

#[derive(PartialEq)]
pub struct Clock {
    offset: i32,
}

impl Clock {
    fn calculate_offset(base: i32, change: i32) -> i32 {
        let delta = change % MINUTES_PER_DAY;
        if base + delta < 0 {
            MINUTES_PER_DAY + base + delta
        } else {
            base + delta
        }.rem_euclid(MINUTES_PER_DAY)
    }

    pub fn hours(&self) -> i32 {
        self.offset.div_euclid(MINUTES_PER_HOUR)
    }

    pub fn minutes(&self) -> i32 {
        self.offset.rem_euclid(MINUTES_PER_HOUR)
    }

    pub fn new(hours: i32, minutes: i32) -> Self {
        let offset1 = hours * MINUTES_PER_HOUR + minutes;

        let offset = if offset1 < 0 {
           MINUTES_PER_DAY + offset1
        } else {
            offset1
        }.rem_euclid(MINUTES_PER_DAY);
        Clock { offset }
    }

    pub fn add_minutes(&self, minutes: i32) -> Self {
        Clock {
            offset: Self::calculate_offset(self.offset, minutes),
        }
    }
}

impl fmt::Debug for Clock {
    fn fmt(&self, f: &mut fmt::Formatter) -> fmt::Result {
        f.debug_struct("Clock")
            .field("hours", &self.hours())
            .field("minutes", &self.minutes())
            .finish()
    }
}

impl fmt::Display for Clock {
    fn fmt(&self, f: &mut fmt::Formatter) -> fmt::Result {
        write!(f, "{:0>2}:{:0>2}", &self.hours(), self.minutes())
    }
}
