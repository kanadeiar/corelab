module Tests

open Xunit
open Faqt
open System
open Attributes
open FsUnit.Xunit

type ISample = 
    abstract member Name: string with get, set
type Sample() =
    interface ISample with
        member val Name = "" with get, set
type ISamplesRepository =
    [<CLIEvent>]
    abstract member TestEvent : Control.IEvent<EventHandler, EventArgs> 
    abstract member GetAll : unit -> Sample list
type SamplesRepository() =
    let _testEvent = new Event<EventHandler, EventArgs>()
    interface ISamplesRepository with
        [<CLIEvent>]
        member _.TestEvent: IEvent<EventHandler,EventArgs> = 
            _testEvent.Publish
        member _.GetAll (): Sample list = 
            []
    member t.Execute() =
        _testEvent.Trigger(t, EventArgs.Empty)

[<Fact>]
let TestSample () =
    true |> should be True 


