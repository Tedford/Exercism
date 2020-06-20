pub fn square(s: u32) -> u64 {

    if s < 1 || s > 64
    {
        panic!("Square must be between 1 and 64")
    }

    let r = 2u64;
    let a = 1u64;

    // nth term of a geometric sequence
    a * r.pow(s-1)
}

pub fn total() -> u64 {
    (1..=64).map(square).sum()
}
