using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaStorage.Data.Entities
{
    public class UserRole : BaseEntity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }

    class UserRoleConfiguration : BaseConfiguration<UserRole>
    {
        internal UserRoleConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
