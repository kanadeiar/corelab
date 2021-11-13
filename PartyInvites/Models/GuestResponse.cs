namespace PartyInvites.Models;

public class GuestResponse
{
    public string Name { get; set; } = "Безимянный";
    public string Email { get; set; } = "none@mail.ru";
    public string Phone { get; set; } = "999";
    public bool? WillAttend { get; set; }
}
