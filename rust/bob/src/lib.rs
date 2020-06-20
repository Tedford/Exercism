extern crate regex;

use regex::Regex;

pub fn reply(message: &str) -> &str {
    let silence = Regex::new("^\\s*$").unwrap();
    let alpha = Regex::new("[a-zA-z]+").unwrap();
    let is_yelling = message == message.to_ascii_uppercase();
    let is_question = message.trim().ends_with("?");

    let mut reply_message = "Whatever.";

    if is_yelling && is_question && alpha.is_match(message)
    {
        reply_message = "Calm down, I know what I'm doing!";
    }
    else if silence.is_match(message)
    {
        reply_message = "Fine. Be that way!";
    }
    else if is_yelling && alpha.is_match(message)
    {
        reply_message = "Whoa, chill out!";
    }
    else if is_question
    {
        reply_message = "Sure.";
    }

    reply_message
}
