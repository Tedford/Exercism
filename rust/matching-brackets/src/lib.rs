pub fn brackets_are_balanced(string: &str) -> bool {
    let mut buffer = Vec::<char>::new();
    let mut balanced = true;

    for c in string.chars() {
        balanced = match c {
            '{' => {
                buffer.push('}');
                true
            }
            '[' => {
                buffer.push(']');
                true
            }
            '(' => {
                buffer.push(')');
                true
            }
            '}' | ']' | ')' => {
                buffer.pop() == Some(c)
            }
            _ => true,
        };

        if !balanced {
            break;
        }
    }

    balanced && buffer.is_empty()
}
