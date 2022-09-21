using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SimpleConsole.Models;

[Owned]
public class Person
{
    [Required, StringLength(100)]
    public string FirstName { get; set; }
    [Required, StringLength(100)]
    public string LastName { get; set; }
}