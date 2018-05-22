using System;
using System.Collections.Generic;

namespace MediaStorage.Data.Entities
{
    public class Material : BaseEntity<int>
    {
        public string InternationalNumber { get; set; }

        public string Title { get; set; }

        public DateTime PublishDate { get; set; }

        public string Contents { get; set; }

        public string ImageUrl { get; set; }

        public int MaterialTypeId { get; set; }
        public virtual MaterialType MaterialType { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }

        public virtual ICollection<MaterialPropertyItem> MaterialPropertyItems { get; set; }
    }

    class MaterialMap : BaseConfiguration<Material>
    {
        internal MaterialMap()
        {
            HasKey(m => m.Id);
            HasIndex(m => m.InternationalNumber).IsUnique();
            Property(m => m.InternationalNumber)
                .HasMaxLength(30)
                .IsRequired();
            Property(m => m.Title).IsRequired();
            HasMany(m => m.Stocks)
                .WithRequired()
                .HasForeignKey(m => m.MaterialId);
            HasMany(m => m.MaterialPropertyItems)
                .WithRequired()
                .HasForeignKey(m => m.MaterialId);
        }
    }
}
