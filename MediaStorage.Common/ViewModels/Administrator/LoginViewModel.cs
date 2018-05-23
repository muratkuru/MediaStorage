using System.ComponentModel.DataAnnotations;

namespace MediaStorage.Common.ViewModels.Administrator
{
    public class LoginViewModel
    {
        [Display(Name = "Username", Prompt = "Username")]
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [Display(Name = "Password", Prompt = "Password")]
        [DataType(DataType.Password)]
        [Required]
        [MaxLength(512)]
        public string Password { get; set; }
    }
}
