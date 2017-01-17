module ScrabbleScoreTest

open NUnit.Framework
open ScrabbleScore
  
[<Test>]
let ``Empty word scores zero`` () =
    Assert.That(score "", Is.EqualTo(0))

[<Test>]
let ``Whitespace scores zero`` () =
    Assert.That(score " \t\n", Is.EqualTo(0))

[<Test>]
let ``Scores very short word`` () =
    Assert.That(score "a", Is.EqualTo(1))

[<Test>]
let ``Scores other very short word`` () =
    Assert.That(score "f", Is.EqualTo(4))

[<Test>]
let ``Simple word scores the number of letters`` () =
    Assert.That(score "street", Is.EqualTo(6))

[<Test>]
let ``Complicated word scores more`` () =
    Assert.That(score "quirky", Is.EqualTo(22))

[<Test>]
let ``Scores are case insensitive`` () =
    Assert.That(score "OXYPHENBUTAZONE", Is.EqualTo(41))

[<Test>]
let ``Double word score`` () =
    Assert.That(score2 "OXYPHENBUTAZONE" [] DoubleWord, Is.EqualTo(82))

[<Test>]
let ``Triple word score`` () =
    Assert.That(score2 "OXYPHENBUTAZONE" [] TripleWord, Is.EqualTo(123))

[<Test>]
let ``Scores with a single double letter`` () =
    Assert.That(score2 "OXYPHENBUTAZONE" [DoubleLetter 'X'] SingleWord, Is.EqualTo(49))

[<Test>]
let ``Scores with a single triple letter`` () =
    Assert.That(score2 "OXYPHENBUTAZONE" [TripleLetter 'X'] SingleWord, Is.EqualTo(57))


[<Test>]
let ``Scores with multiple letter score qualifiers`` () =
    Assert.That(score2 "OXYPHENBUTAZONE" [TripleLetter 'X'; DoubleLetter 'P'; DoubleLetter 'A'; TripleLetter 'Z'] SingleWord, Is.EqualTo(81))


[<Test>]
let ``Scores with multiple letter score qualifiers and tripleword`` () =
    Assert.That(score2 "OXYPHENBUTAZONE" [TripleLetter 'X'; DoubleLetter 'P'; DoubleLetter 'A'; TripleLetter 'Z'] TripleWord, Is.EqualTo(243))