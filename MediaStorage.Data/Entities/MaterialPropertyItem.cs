namespace MediaStorage.Data.Entities
{
    public class MaterialPropertyItem : BaseEntity<int>
    {
        public string Name { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public int MaterialTypePropertyId { get; set; }
        public MaterialTypeProperty MaterialTypeProperty { get; set; }
    }

    class MaterialPropertyItemConfiguration : BaseConfiguration<MaterialPropertyItem>
    {
        internal MaterialPropertyItemConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
