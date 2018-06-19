using System;
using System.ComponentModel.DataAnnotations;

namespace MediaStorage.Common.ViewModels.User
{
    public class UserPostViewModel
    {
        public Guid? Id { get; set; }

        [Display(Name = "Username")]
        [Required]
        [MaxLength(255)]
        public string Username { get; set; }

        [Display(Name = "Mail")]
        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Mail { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "User Roles")]
        public int[] UserRoleIds { get; set; }
    }
}
