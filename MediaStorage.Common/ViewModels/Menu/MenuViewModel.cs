using System.ComponentModel.DataAnnotations;

namespace MediaStorage.Common.ViewModels.Menu
{
    public class MenuViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Name")]
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
