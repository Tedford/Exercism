const CARS_PER_HOUR: f64 = 221.0;
const MINUTES_PER_HOUR: f64 = 60.0;

pub fn production_rate_per_hour(speed: u8) -> f64 {
    CARS_PER_HOUR * speed as f64
}

pub fn working_items_per_minute(speed: u8) -> u32 {
    match speed {
        1 | 2 | 3 | 4 => (production_rate_per_hour(speed) / MINUTES_PER_HOUR) as u32,
        5 | 6 | 7 | 8 => (production_rate_per_hour(speed) * 0.9 / MINUTES_PER_HOUR) as u32,
        _=> (production_rate_per_hour(speed) * 0.77 / MINUTES_PER_HOUR) as u32
    }
}
