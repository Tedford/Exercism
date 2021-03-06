module AcronymTest

open NUnit.Framework
open Acronym

[<Test>]
let ``Empty string abbreviated to empty string`` () =
    Assert.That(acronym "", Is.EqualTo(""))

[<Test>]

let ``Basic`` () =
    let phrase = "Portable Network Graphics"
    let expected = "PNG"
    let actual = acronym phrase
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]

let ``Lowercase words`` () =
    let phrase = "Ruby on Rails"
    let expected = "ROR"
    let actual = acronym phrase
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]

let ``Camel case`` () =
    let phrase = "HyperText Markup Language"
    let expected = "HTML"
    let actual = acronym phrase
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]

let ``Punctuation`` () =
    let phrase = "First In, First Out"
    let expected = "FIFO"
    let actual = acronym phrase
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]

let ``All-Caps words`` () =
    let phrase = "PHP: Hypertext Preprocessor"
    let expected = "PHP"
    let actual = acronym phrase
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]

let ``Non-acronym all-caps word`` () =
    let phrase = "GNU Image Manipulation Program"
    let expected = "GIMP"
    let actual = acronym phrase
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]

let ``Hyphenated`` () =
    let phrase = "Complementary metal-oxide semiconductor"
    let expected = "CMOS"
    let actual = acronym phrase
    Assert.That(expected, Is.EqualTo(actual))