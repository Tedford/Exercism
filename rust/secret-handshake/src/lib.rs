// bitmask! {
//     mask Action: u8 where flags Flags {
//         Wink = 0b00000001,
//         DoubleBlink = 0b00000010,
//         Close = 0b00000100,
//         Jump = 0b00001000,
//         Reverse = 0b00010000
//     }
// }

pub fn actions(n: u8) -> Vec<&'static str> {
    let mut actions = vec![];
    if n & 0b00000001 > 0 {
        actions.push("wink")
    }
    if n & 0b00000010 > 0 {
        actions.push("double blink")
    }
    if n & 0b00000100 > 0 {
        actions.push("close your eyes")
    }
    if n & 0b00001000 > 0 {
        actions.push("jump")
    }
    if  n & 0b00010000 > 0 {
        actions.reverse()
    }

    actions
}
