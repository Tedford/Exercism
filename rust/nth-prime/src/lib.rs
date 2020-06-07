pub fn nth(n: u32) -> u32 {

    let prime_0 = 2;
    let mut last_prime = prime_0;
    let mut found =0;
    let mut i = 0;

    while found <= n
    {
        let mut candidate = prime_0 + i;
        if is_prime(candidate)
        {
            last_prime = candidate;
            found += 1;
        }
        i += 1;
    }

    last_prime
}

pub fn is_prime(n: u32) -> bool
{
    if n <= 3 
    {
        return n > 1;
    }
    else if n % 2 == 0 || n % 3 == 0
    {
        return false;
    }
    
    let mut i = 5;

    while i * i <= n 
    {
        if n % i == 0 || n % (i + 2) == 0
        {
            return false;
        }
        i += 6;
    }

    true
}