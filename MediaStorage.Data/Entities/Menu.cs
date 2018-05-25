using System.Collections.Generic;

namespace MediaStorage.Data.Entities
{
    public class Menu : BaseEntity<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }

    class MenuConfiguration : BaseConfiguration<Menu>
    {
        internal MenuConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(255);
            Property(m => m.Description)
                .HasMaxLength(255);
            HasMany(m => m.MenuItems)
                .WithRequired()
                .HasForeignKey(m => m.MenuId);
        }
    }
}
