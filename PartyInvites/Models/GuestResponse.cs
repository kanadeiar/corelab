using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models;

public class GuestResponse
{
    [Required(ErrorMessage = "Введите свои имя")]
    public string Name { get; set; } = "Безимянный";

    [Required(ErrorMessage = "Введите свой адрес почты")]
    [EmailAddress]
    public string Email { get; set; } = "none@mail.ru";

    [Required(ErrorMessage = "Введите свой номер телефона")]
    public string Phone { get; set; } = "999";

    [Required(ErrorMessage = "Пожалуйста, укажите, примете ли вы участие")]
    public bool? WillAttend { get; set; }
}
