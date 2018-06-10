using System.ComponentModel.DataAnnotations;

namespace MediaStorage.Common.ViewModels.Category
{
    public class CategoryListViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Parent Category")]
        public string ParentCategory { get; set; }

        [Display(Name = "Material Type")]
        public string MaterialType { get; set; }
    }
}
