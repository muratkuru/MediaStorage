using System.ComponentModel.DataAnnotations;

namespace MediaStorage.Common.ViewModels
{
    public class MaterialTypeViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Gerekli alan.")]
        [MaxLength(100, ErrorMessage = "100 karakterden uzun olamaz.")]
        public string Name { get; set; }
    }
}
