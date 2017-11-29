using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace MediaStorage.Data.Entities
{
    public class MaterialProperty : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MaterialTypeId { get; set; }
        public virtual MaterialType MaterialType { get; set; }

        public virtual ICollection<MaterialPropertyItem> MaterialPropertyItems { get; set; }
    }

    class MaterialPropertyMap : EntityTypeConfiguration<MaterialProperty>
    {
        internal MaterialPropertyMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Name).IsRequired();
            HasMany(m => m.MaterialPropertyItems)
                .WithRequired(m => m.MaterialProperty)
                .HasForeignKey(m => m.MaterialPropertyId);
        }
    }
}
