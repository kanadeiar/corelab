module Shapes

open System

[<AbstractClass>]
type Shape(_x : int, _y : int) =
    let mutable x = _x
    let mutable y = _y
    abstract Area : unit -> double
    member _.Print() =
        printfn $"x: {x} y: {y}"

type Rectangle(width, height, _x, _y) =
    inherit Shape(_x, _y)
    member _.Width = width
    member _.Height = height

    override this.Area() =
        this.Width * this.Height

type Circle(radius, _x, _y) =
    inherit Shape(_x, _y)
    member this.Radius = radius

    override this.Area() =
        Math.PI * this.Radius * this.Radius

