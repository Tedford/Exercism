#[derive(Debug)]
pub struct Duration {
    seconds: f64,
}

impl From<u64> for Duration {
    fn from(s: u64) -> Self {
        Duration { seconds: s as f64 }
    }
}

pub trait Planet {
    fn ratio() -> f64;
    fn years_during(d: &Duration) -> f64 {
        d.seconds / (365.25f64 * 24f64 * 60f64 * 60f64) / Self::ratio()
    }
}

macro_rules! planet {
    ($n: ident, $p:expr) => {
        pub struct $n;
        impl Planet for $n {
            fn ratio() -> f64 {
                $p
            }
        }
    };
}

planet!(Mercury, 0.2408467);
planet!(Venus, 0.61519726);
planet!(Earth, 1.0);
planet!(Mars, 1.8808158);
planet!(Jupiter, 11.862615);
planet!(Saturn, 29.447498);
planet!(Uranus, 84.016846);
planet!(Neptune, 164.79132);
