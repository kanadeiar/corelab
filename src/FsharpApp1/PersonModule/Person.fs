module Person

open System.Runtime.CompilerServices

[<assembly: InternalsVisibleTo("FsharpApp1Tests")>]
do()

/// <summary>
/// Способ формирования строки
/// </summary>
type PrintCode =
    | None
    | GluedLine
    | Formatting
    | Interpolation

/// <summary>
/// Анкета, которая может формировать строку ответа
/// </summary>
type ITextPrintingQuestionnary =
    /// <summary>
    /// Сформировать строку ответа
    /// </summary>
    abstract member MakeText : PrintCode -> string

/// <summary>
/// Анекта участника
/// </summary>
type Questionnary =
    val name : string
    val surName : string
    val age : int
    static member Create name surName age : ITextPrintingQuestionnary =
        Questionnary(name, surName, age)
    new (name, surName, age) =
        { name = name; surName = surName; age = age }
    interface ITextPrintingQuestionnary with
        member t.MakeText code = 
            match code with
            | GluedLine -> "Фамилия: " + t.surName + " Имя: " + t.name + " Возраст: " + t.age.ToString()
            | Formatting -> sprintf "Фамилия: %s Имя: %s Возраст: %d" t.surName t.name t.age
            | Interpolation -> $"""Фамилия: {t.surName} Имя: {t.name}  Возраст: {t.age}"""
            | _ -> ""
