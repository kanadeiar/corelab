open System
open Person

printfn "Опытное приложение"

let q = 
    Questionnary.Create "One" "Name" 12
let print = 
    printfn "%s" << q.MakeText

print GluedLine
print Formatting
print Interpolation

printfn "\nНажмите любую кнопку для завершения ..."
Console.ReadKey() |> ignore
