using System.ComponentModel.DataAnnotations;

namespace MediaStorage.Common.ViewModels.Menu
{
    public class MenuItemListViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Area")]
        public string Area { get; set; }

        [Display(Name = "Action")]
        public string Action { get; set; }

        [Display(Name = "Controller")]
        public string Controller { get; set; }

        [Display(Name = "Icon")]
        public string Icon { get; set; }

        [Display(Name = "Row Index")]
        public int? RowIndex { get; set; }

        [Display(Name = "Parent Menu Item")]
        public string ParentMenuItem { get; set; }

        [Display(Name = "Menu")]
        public string Menu { get; set; }
    }
}
