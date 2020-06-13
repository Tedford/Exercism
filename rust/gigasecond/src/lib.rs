use chrono::{DateTime, Utc, Duration};

// Returns a Utc DateTime one billion seconds after start.
pub fn after(start: DateTime<Utc>) -> DateTime<Utc> {
    let base : i64 = 10;
    let billion = base.pow(9);
    start + Duration::seconds(billion)
}
