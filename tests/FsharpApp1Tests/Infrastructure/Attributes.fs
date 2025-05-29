module Attributes

open AutoFixture.Xunit2
open AutoFixture
open AutoFixture.AutoMoq

type AutoMoqDataAttribute() = 
    inherit AutoDataAttribute(fun _ -> Fixture().Customize(AutoMoqCustomization()))
