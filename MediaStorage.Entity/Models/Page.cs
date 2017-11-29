using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace MediaStorage.Entity.Models
{
    public class Page : BaseEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Area { get; set; }

        public string Action { get; set; }

        public string Controller { get; set; }

        public string Icon { get; set; }

        public int? ParentPageId { get; set; }
        public virtual Page ParentPage { get; set; }

        public int? RowIndex { get; set; }

        public virtual ICollection<Page> SubPages { get; set; }
    }

    class PageMap : EntityTypeConfiguration<Page>
    {
        internal PageMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Title).IsRequired();
        }
    }
}
