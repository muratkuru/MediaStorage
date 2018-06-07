using System.ComponentModel.DataAnnotations;

namespace MediaStorage.Common.ViewModels.MaterialType
{
    public class MaterialTypeViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Name")]
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
