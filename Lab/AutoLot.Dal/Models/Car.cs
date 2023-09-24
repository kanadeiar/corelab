namespace AutoLot.Dal.Models;

public class Car
{
    public int Id { get; set; }
    public int MakeId { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public byte[] Stamp { get; set; }
    public Car(int id, int makeId, string name, string color, byte[] stamp)
    {
        Id = id;
        MakeId = makeId;
        Name = name;
        Color = color;
        Stamp = stamp;
    }
}

