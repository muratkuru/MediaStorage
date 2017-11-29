using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace MediaStorage.Entity.Models
{
    public class MaterialType : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Material> Materials { get; set; }

        public virtual ICollection<MaterialProperty> MaterialProperties { get; set; }
    }

    class MaterialTypeMap : EntityTypeConfiguration<MaterialType>
    {
        internal MaterialTypeMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Name).IsRequired();
            HasMany(m => m.Categories)
                .WithRequired()
                .HasForeignKey(m => m.MaterialTypeId);
            HasMany(m => m.Materials)
                .WithRequired()
                .HasForeignKey(m => m.MaterialTypeId);
        }
    }
}
