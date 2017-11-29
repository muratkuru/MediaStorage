using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace MediaStorage.Entity.Models
{
    public class User : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string FullName { get; set; }

        public string Mail { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual ICollection<Borrowing> Borrowings { get; set; }
    }

    class UserMap : EntityTypeConfiguration<User>
    {
        internal UserMap()
        {
            HasKey(m => m.Id);
            Property(m => m.FullName).IsRequired();
            Property(m => m.Mail).IsRequired();
            HasMany(m => m.Reservations)
                .WithRequired()
                .HasForeignKey(m => m.UserId);
            HasMany(m => m.Borrowings)
                .WithRequired()
                .HasForeignKey(m => m.UserId);
        }
    }
}
