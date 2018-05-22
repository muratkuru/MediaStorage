using System.Collections.Generic;

namespace MediaStorage.Data.Entities
{
    public class Tag : BaseEntity<int>
    {
        public string Name { get; set; }

        public ICollection<Material> Materials { get; set; }
    }

    class TagMap : BaseConfiguration<Tag>
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
