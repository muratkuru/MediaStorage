using System.Collections.Generic;

namespace MediaStorage.Data.Entities
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }

        public int MaterialTypeId { get; set; }
        public virtual MaterialType MaterialType { get; set; }

        public virtual ICollection<Category> SubCategories { get; set; }

        public virtual ICollection<Material> Materials { get; set; }
    }

    class CategoryConfiguration : BaseConfiguration<Category>
    {
        internal CategoryConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(255);
            Property(m => m.MaterialTypeId).IsRequired();
            HasMany(m => m.Materials)
                .WithMany(m => m.Categories)
                .Map(m =>
                {
                    m.MapRightKey("CategoryId");
                    m.MapLeftKey("MaterialId");
                });
        }
    }
}
