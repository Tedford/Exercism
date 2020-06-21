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
        let offset = if base + delta < 0 {
            MINUTES_PER_DAY + base + delta
        } else {
            base + delta
        };
        offset % MINUTES_PER_DAY
    }

    pub fn hours(&self) -> i32 {
        self.offset / MINUTES_PER_HOUR
    }

    pub fn minutes(&self) -> i32 {
        self.offset % MINUTES_PER_HOUR
    }

    pub fn new(hours: i32, minutes: i32) -> Self {
        let h = if hours < 0 {
            HOURS_PER_DAY + (hours % HOURS_PER_DAY)
        } else {
            hours % HOURS_PER_DAY
        } + minutes / MINUTES_PER_HOUR % HOURS_PER_DAY
            + if minutes < 0 { -1 } else { 0 };

        let m = if minutes < 0 {
            MINUTES_PER_HOUR + (minutes % MINUTES_PER_HOUR)
        } else {
            minutes % MINUTES_PER_HOUR
        };

        let offset = Self::calculate_offset(0, h * MINUTES_PER_HOUR + m);
        let clock = Clock { offset };
        println!(
            "{:0>2}:{:0>2}->{:0>2}:{:0>2}",
            hours,
            minutes,
            clock.hours(),
            clock.minutes()
        );

        clock
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
