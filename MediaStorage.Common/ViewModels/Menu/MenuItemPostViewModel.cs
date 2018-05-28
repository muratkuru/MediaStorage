using System.ComponentModel.DataAnnotations;

namespace MediaStorage.Common.ViewModels.Menu
{
    public class MenuItemPostViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Title")]
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Display(Name = "Area")]
        [MaxLength(255)]
        public string Area { get; set; }

        [Display(Name = "Action")]
        [MaxLength(255)]
        public string Action { get; set; }

        [Display(Name = "Controller")]
        [MaxLength(255)]
        public string Controller { get; set; }

        [Display(Name = "Icon")]
        [MaxLength(255)]
        public string Icon { get; set; }

        [Display(Name = "Row Index")]
        public int? RowIndex { get; set; }

        [Display(Name = "Parent Menu Item")]
        public int? ParentMenuItemId { get; set; }

        [Display(Name = "Menu")]
        [Required]
        public int MenuId { get; set; }

        [Display(Name = "User Roles")]
        public int[] UserRoleIds { get; set; }
    }
}
