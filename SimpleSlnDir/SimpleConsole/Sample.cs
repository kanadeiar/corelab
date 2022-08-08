using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleConsole;

public class Sample
{
    public string? Name { get; set; } = null;
    public void Test(string name)
    {
        ArgumentNullException.ThrowIfNull(name);
        // код
    }
}


