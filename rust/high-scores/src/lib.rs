#[derive(Debug)]
pub struct HighScores {
    scores: Vec<u32>,
}

impl HighScores {
    pub fn new(scores: &[u32]) -> Self {
        HighScores {
            scores: scores.to_vec(),
        }
    }

    pub fn scores(&self) -> &[u32] {
        self.scores.as_slice()
    }

    pub fn latest(&self) -> Option<u32> {
        if self.scores.is_empty() {
            None
        } else {
            Some(self.scores[self.scores.len() - 1])
        }
    }

    pub fn personal_best(&self) -> Option<u32> {
        if self.scores.is_empty() {
            None
        } else {
            let mut scores = self.scores.clone();
            scores.sort();
            scores.reverse();
            Some(scores[0])
        }
    }

    pub fn personal_top_three(&self) -> Vec<u32> {
        if self.scores.is_empty() {
            Vec::<u32>::new()
        } else {
            let mut scores = self.scores.clone();
            scores.sort();
            scores.reverse();
            let mut top3 = Vec::<u32>::new();
            for i in scores.as_slice().iter().take(3) {
                top3.push(*i);
            }
            top3
        }
    }
}
