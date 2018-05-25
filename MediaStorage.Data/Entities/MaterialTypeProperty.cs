using System.Collections.Generic;

namespace MediaStorage.Data.Entities
{
    public class MaterialTypeProperty : BaseEntity<int>
    {
        public string Name { get; set; }

        public int MaterialTypeId { get; set; }
        public virtual MaterialType MaterialType { get; set; }

        public virtual ICollection<MaterialPropertyItem> MaterialPropertyItems { get; set; }
    }

    class MaterialTypePropertyConfiguration : BaseConfiguration<MaterialTypeProperty>
    {
        internal MaterialTypePropertyConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(255);
            HasMany(m => m.MaterialPropertyItems)
                .WithRequired(m => m.MaterialTypeProperty)
                .HasForeignKey(m => m.MaterialTypePropertyId);
        }
    }
}
