using System.Collections.Generic;

namespace MediaStorage.Data.Entities
{
    public class Tag : BaseEntity<int>
    {
        public string Name { get; set; }

        public ICollection<Material> Materials { get; set; }
    }

    class TagConfiguration : BaseConfiguration<Tag>
    {
        internal TagConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(255);
            HasMany(m => m.Materials)
                .WithMany(m => m.Tags)
                .Map(m =>
                {
                    m.MapLeftKey("MaterialId");
                    m.MapRightKey("TagId");
                });
        }
    }
}
