namespace SimpleConsole.Models;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public byte[] TimeStamp { get; set; }
}