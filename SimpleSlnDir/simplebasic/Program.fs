open System

module Calc = let add one two = one + two

[<EntryPoint>]
let main argv =
    let ans = Calc.add 1 2
    printfn "1 + 2 = %d" ans
    printfn "Press any key"
    let _ = Console.ReadKey()
    0


