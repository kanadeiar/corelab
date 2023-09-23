namespace AutoLot.Dal.Models;

public class Car
{
    public int Id { get; set; }
    public int MakeId { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Color { get; set; } = String.Empty;
    public byte[] Stamp { get; set; } = Array.Empty<byte>();
}

