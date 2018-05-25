using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaStorage.Data.Entities
{
    public class Member : BaseEntity<Guid>
    {
        public string FullName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }
        
        public virtual User User { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual ICollection<Lending> Lendings { get; set; }
    }

    class MemberConfiguration : BaseConfiguration<Member>
    {
        internal MemberConfiguration()
        {
            HasKey(m => m.Id);
            HasIndex(m => m.PhoneNumber).IsUnique();
            Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.FullName)
                .IsRequired()
                .HasMaxLength(255);
            Property(m => m.PhoneNumber)
                .IsRequired()
                .HasMaxLength(64);
            HasMany(m => m.Reservations)
                .WithRequired()
                .HasForeignKey(m => m.MemberId);
            HasMany(m => m.Lendings)
                .WithRequired()
                .HasForeignKey(m => m.MemberId);
        }
    }
}
