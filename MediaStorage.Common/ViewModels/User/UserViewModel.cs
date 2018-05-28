using System.ComponentModel.DataAnnotations;

namespace MediaStorage.Common.ViewModels.User
{
    public class UserViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Mail")]
        public string Mail { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }
    }
}
