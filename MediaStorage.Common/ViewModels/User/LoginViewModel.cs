using System.ComponentModel.DataAnnotations;

namespace MediaStorage.Common.ViewModels.User
{
    public class LoginViewModel
    {
        [Display(Name = "Username")]
        [Required]
        [MaxLength(255)]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required]
        [MaxLength(255)]
        public string Password { get; set; }
    }
}
