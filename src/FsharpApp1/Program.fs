open System
open System.IO
open Persons
open Shapes

printfn "Опытное приложение"

let multiply a b = a * b

let divide a b =
    if b = 0 then None
    else Some(a / b)     

let printResult result =
    match result with
    | Some(n) -> printfn "%d" n
    | None -> printfn "Error"

let res1 = divide 100 0
printResult res1

let res2 = divide 200 10
printResult res2

//let res2 = divide 200 10
//printfn "%d" res2

Console.ReadLine() |> ignore

task {
    let! text = File.ReadAllTextAsync "hello.txt" |> Async.AwaitTask
    Async.Sleep 1000 |> Async.RunSynchronously
    printfn "%s" text
} |> ignore


printfn "\nНажмите любую кнопку для завершения ..."
Console.ReadKey() |> ignore
