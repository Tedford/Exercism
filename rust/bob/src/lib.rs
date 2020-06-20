pub fn reply(message: &str) -> &str {
    let trimmed = message.trim();
    let is_question = trimmed.ends_with('?');
    let is_yelling =
        trimmed.chars().any(|c| c.is_alphabetic()) && trimmed.to_ascii_uppercase() == trimmed;
    let is_silence = trimmed.chars().all(|c| c.is_ascii_whitespace());

    match message {
        _ if is_silence => "Fine. Be that way!",
        _ if is_question && is_yelling => "Calm down, I know what I'm doing!",
        _ if is_yelling => "Whoa, chill out!",
        _ if is_question => "Sure.",
        _ => "Whatever.",
    }
}
