using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaStorage.Data.Entities
{
    public class User : BaseEntity<Guid>
    {
        public string FullName { get; set; }

        public string Mail { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual ICollection<Lending> Lendings { get; set; }
    }

    class UserConfiguration : BaseConfiguration<User>
    {
        internal UserConfiguration()
        {
            HasKey(m => m.Id);
            HasIndex(m => m.Mail).IsUnique();
            HasIndex(m => m.PhoneNumber).IsUnique();
            Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.FullName)
                .IsRequired()
                .HasMaxLength(200);
            Property(m => m.Mail)
                .IsRequired()
                .HasMaxLength(200);
            Property(m => m.PhoneNumber)
                .IsRequired()
                .HasMaxLength(30);
            Property(m => m.Password)
                .IsRequired()
                .HasMaxLength(512);
            Property(m => m.IsActive)
                .HasColumnAnnotation("DefaultValueSql", 0);
            HasMany(m => m.Reservations)
                .WithRequired()
                .HasForeignKey(m => m.UserId);
            HasMany(m => m.Lendings)
                .WithRequired()
                .HasForeignKey(m => m.UserId);
        }
    }
}
