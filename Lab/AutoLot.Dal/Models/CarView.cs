namespace AutoLot.Dal.Models;

public class CarView : Car
{
    public string Make { get; set; }

    public CarView(int id, string make, string name, string color, byte[] stamp) : base(id, 0, name, color, stamp)
    {
        Make = make;
    }
}