module Tests

open System
open Xunit
open Faqt

[<Fact>]
let ``My test`` () =
    true.Should().BeTrue()

[<Fact>]
let ``Dev test`` () =
    let actual = 1
    actual.Should().Be(1)
