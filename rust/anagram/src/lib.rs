use std::collections::HashSet;

fn normalize(s: &str) -> String {
    let mut chars: Vec<char> = s[..].to_lowercase().chars().collect();
    chars.sort_unstable();
    dbg!(chars.into_iter().collect())
}

pub fn anagrams_for<'a>(word: &str, possible_anagrams: &'a [&str]) -> HashSet<&'a str> {
    let lowered = dbg!(word.to_lowercase());
    let ordered = dbg!(normalize(word));

    possible_anagrams
        .iter()
        .filter(|w| *w.to_lowercase() != lowered && ordered == normalize(w))
        .copied()
        .collect()
}
