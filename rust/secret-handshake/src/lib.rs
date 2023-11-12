pub fn actions(n: u8) -> Vec<&'static str> {
    let mut actions = vec![];
    let mut mask = 0b00001;

    while mask & 0b11111 > 0 {
        match mask & n {
            0b0001 => actions.push("wink"),
            0b0010 => actions.push("double blink"),
            0b0100 => actions.push("close your eyes"),
            0b1000 => actions.push("jump"),
            0b10000 => actions.reverse(),
            _ => ()
        };
        mask <<= 1;
    }

    actions
}
