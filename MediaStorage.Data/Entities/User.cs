using System;
using System.Collections.Generic;

namespace MediaStorage.Data.Entities
{
    public class User : BaseEntity<Guid>
    {
        public string Username { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }
        
        public virtual Member Member { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }

    class UserConfiguration : BaseConfiguration<User>
    {
        internal UserConfiguration()
        {
            HasKey(m => m.Id);
            HasIndex(m => m.Username).IsUnique();
            Property(m => m.Username)
                .IsRequired()
                .HasMaxLength(30);
            Property(m => m.Mail)
                .IsRequired()
                .HasMaxLength(255);
            Property(m => m.Password)
                .IsRequired()
                .HasMaxLength(255);
            Property(m => m.IsActive)
                .HasColumnAnnotation("DefaultValueSql", 0);
            HasOptional(m => m.Member)
                .WithRequired(m => m.User);
            HasMany(m => m.UserRoles)
                .WithMany(m => m.Users)
                .Map(m =>
                {
                    m.MapRightKey("UserId");
                    m.MapLeftKey("UserRoleId");
                });
        }
    }
}
