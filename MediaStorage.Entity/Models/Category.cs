using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace MediaStorage.Entity.Models
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }

        public int MaterialTypeId { get; set; }
        public virtual MaterialType MaterialType { get; set; }

        public virtual ICollection<Category> SubCategories { get; set; }

        public virtual ICollection<Material> Materials { get; set; }
    }

    class CategoryMap : EntityTypeConfiguration<Category>
    {
        internal CategoryMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Name).IsRequired();
            Property(m => m.MaterialTypeId).IsRequired();
            HasMany(m => m.Materials)
                .WithMany(m => m.Categories)
                .Map(m =>
                {
                    m.MapLeftKey("MaterialId");
                    m.MapRightKey("CategoryId");
                });
        }
    }
}
