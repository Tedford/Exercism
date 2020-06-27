use std::cmp;
use std::iter;

pub fn find_saddle_points(input: &[Vec<u64>]) -> Vec<(usize, usize)> {
    let mut points = Vec::<(usize, usize)>::new();

    let rows = input.len();
    let cols = input[0].len();
    println!("Examining an {} by {} matrix", rows, cols);
    // for some reason vec![0, rows] was generating a vector 2 elements long
    let mut m: Vec<u64> = iter::repeat(0).take(rows).collect();
    let mut n: Vec<u64> = iter::repeat(u64::MAX).take(cols).collect();

    for r in 0..rows {
        for c in 0..cols {
            // check for max in each row
            m[r] = cmp::max(m[r], input[r][c]);
            // check for min in each column
            n[c] = cmp::min(n[c], input[r][c]);
        }
    }

    // check for local maximum
    for r in 0..rows {
        for c in 0..cols {
            let value = input[r][c];

            if value == m[r] && value == n[c] {
                points.push((r, c));
            }
        }
    }

    points
}
