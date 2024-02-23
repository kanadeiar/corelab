module public Persons

type IPrintable =
    abstract member Print : unit -> unit

[<Struct>]
type Pet =
    val mutable name : string
    val mutable age : int
    interface IPrintable with
        member this.Print() = printfn "%s" this.name

type Person(name : string, _age : int) =
  
    let mutable age = _age

    member val Name = name
        
    abstract member Age : int with get, set
    
    default _.Age
        with get() = age
        and set value = age <- value

    interface IPrintable with
        member this.Print() =
            printfn $"Name: {this.Name} {this.Age}"

    abstract member Test : unit -> unit
    default this.Test() = 
        printfn "Def"

    member this.TestAsync name = async {
        Async.Sleep 1000 |> Async.RunSynchronously
        return $"asunc result {name}"
    }

type Employee(name, age, pet) = 
    inherit Person(name, age)

    member this.Pet = pet

    override _.Age
        with get() = base.Age
        and set value = base.Age <- value

    member this.Print() =
        printfn $"Name: {this.Name} {this.Age}"

    override this.Test() =
        printfn "Test"


    

