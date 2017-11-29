using System.Data.Entity.ModelConfiguration;

namespace MediaStorage.Entity.Models
{
    public class MaterialPropertyItem : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MaterialId { get; set; }
        public Material Material { get; set; }

        public int MaterialPropertyId { get; set; }
        public MaterialProperty MaterialProperty { get; set; }
    }

    class MaterialPropertyItemMap : EntityTypeConfiguration<MaterialPropertyItem>
    {
        internal MaterialPropertyItemMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Name).IsRequired();
        }
    }
}
