﻿using System.Collections.Generic;

namespace MediaStorage.Data.Entities
{
    public class Page : BaseEntity<int>
    {
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

    class PageConfiguration : BaseConfiguration<Page>
    {
        internal PageConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Title).IsRequired();
        }
    }
}