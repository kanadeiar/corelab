using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Model
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Пожалуйста, введите свое имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите свой адрес электронной почты")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите свой телефон")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Пожалуйста, сообщите примете ли вы участие")]
        public bool? WillAttend { get; set; }

    }
}