pub fn factors(n: u64) -> Vec<u64> {
    let mut acc = Vec::<u64>::new();
    let mut factor = 2u64;
    let mut remainder = n;

    // throws a stackoverflow for the last test case
    // fn reduce( mut acc: Vec<u64>, factor: u64, remainder: u64  ) -> Vec<u64>
    // {
    //     if factor > remainder
    //     {
    //         acc
    //     }
    //     else if  remainder % factor == 0
    //     {
    //         acc.push(factor);
    //         reduce( acc, factor,remainder / factor)
    //     }
    //     else {
    //         reduce (acc, factor+1u64, remainder)
    //     }
    // }
    // reduce( Vec::<u64>::new(), 2u64, n )

    while factor <= remainder {
        if remainder % factor == 0 {
            acc.push(factor);
            remainder /= factor;
        } else {
            factor += 1;
        }
    }
    acc
}
