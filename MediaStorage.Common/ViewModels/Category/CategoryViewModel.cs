using System.ComponentModel.DataAnnotations;

namespace MediaStorage.Common.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Name")]
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Display(Name = "Parent Category")]
        public int? ParentCategoryId { get; set; }

        [Display(Name = "MaterialType")]
        [Required]
        public int MaterialTypeId { get; set; }
    }
}
