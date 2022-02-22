namespace SportStore.WebModels;

public class LoginWebModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Password { get; set; }
    public string ReturnUrl { get; set; } = "/";
}