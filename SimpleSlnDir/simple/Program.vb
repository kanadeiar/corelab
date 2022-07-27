Imports System

Namespace BasicExample

    Module Program
        Sub Main(args As String())
            Dim c As new Calc
            Dim ans As Integer = c.Add(1, 2)

            Console.WriteLine("1 + 2 = {0}", ans)
            Console.WriteLine("Press any key ...")
            Console.ReadKey()
        End Sub
    End Module

    Class Calc
        Public Function Add(ByVal one As Integer, ByVal two As Integer) As Integer
            Return one + two
        End Function
    End Class
End Namespace