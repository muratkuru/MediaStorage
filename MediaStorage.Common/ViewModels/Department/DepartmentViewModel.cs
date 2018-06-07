using System.ComponentModel.DataAnnotations;

namespace MediaStorage.Common.ViewModels.Department
{
    public class DepartmentViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Name")]
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Display(Name = "Library")]
        [Required]
        public int LibraryId { get; set; }
    }
}
