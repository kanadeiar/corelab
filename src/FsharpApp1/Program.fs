open System
open System.IO
open Persons
open Shapes
open Collections

printfn "Опытное приложение"

task {
    let! text = File.ReadAllTextAsync "hello.txt" |> Async.AwaitTask
    Async.Sleep 1000 |> Async.RunSynchronously
    printfn "%s" text
} |> ignore


let emp = Employee("name", 12, "one")

async {
    let! res = emp.TestAsync "andrey"
    printfn "%s" res
} |> Async.RunSynchronously


printfn "\nНажмите любую кнопку для завершения ..."
Console.ReadKey() |> ignore
