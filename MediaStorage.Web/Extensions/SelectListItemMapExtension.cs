using MediaStorage.Common;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MediaStorage.Web
{
    public static class SelectListItemMapExtension
    {
        public static IEnumerable<SelectListItem> ToMVCSelectListItem(this ICollection<CustomSelectListItem> customSelectListItem)
        {
            return customSelectListItem.Select(s => new SelectListItem
            {
                Value = s.Value,
                Text = s.Text,
                Selected = s.Selected
            });
        }
    }
}