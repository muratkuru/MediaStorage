using System;

namespace MediaStorage.Data.Entities
{
    public class Administrator : BaseEntity<Guid>
    {
        public string Username { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }
    }

    class AdministratorConfiguration : BaseConfiguration<Administrator>
    {
        internal AdministratorConfiguration()
        {
            HasKey(m => m.Id);
            HasIndex(m => m.Username).IsUnique();
            Property(m => m.Username)
                .IsRequired()
                .HasMaxLength(30);
            Property(m => m.Mail)
                .IsRequired()
                .HasMaxLength(200);
            Property(m => m.Password)
                .IsRequired()
                .HasMaxLength(512);
        }
    }
}
