using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace MediaStorage.Data.Entities
{
    public class Tag : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Material> Materials { get; set; }
    }

    class TagMap : EntityTypeConfiguration<Tag>
    {
        internal TagMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Name).IsRequired();
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
