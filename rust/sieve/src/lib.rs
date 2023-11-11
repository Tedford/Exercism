pub fn primes_up_to(upper_bound: u64) -> Vec<u64> {
    let mut primes = (0..=upper_bound)
        .map(|i| (i, true))
        .collect::<Vec<(u64, bool)>>();

    primes[0usize] = (0u64, false);
    primes[1usize] = (1u64, false);

    for i in 2..=upper_bound {
        let number = primes[i as usize].0;
        let mut j = 2;
        let mut value = number * j;

        while value <= upper_bound {
            primes[value as usize] = (number, false);
            j += 1;
            value = j * number;
        }
    }

    primes
        .iter()
        .filter_map(|t| if t.1 { Some(t.0) } else { None })
        .collect()
}
