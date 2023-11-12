use std::cmp::Ordering;

pub fn find(array: &[i32], key: i32) -> Option<usize> {
    let i = &array.len() / 2;
    match key.cmp((&array).get(i)?) {
        Ordering::Equal => Some(i),
        Ordering::Less => find(&array[..i], key),
        Ordering::Greater => find(&array[i + 1..], key).map(|x| x + i + 1),
    }
}
