using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace MediaStorage.Entity.Models
{
    public class Stock : BaseEntity
    {
        public int Id { get; set; }

        public string FixtureNumber { get; set; }

        public string Location { get; set; }

        public string MaterialId { get; set; }
        public virtual Material Material { get; set; }

        public int LibraryId { get; set; }
        public virtual Library Library { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual ICollection<Borrowing> Borrowings { get; set; }
    }

    class StockMap : EntityTypeConfiguration<Stock>
    {
        internal StockMap()
        {
            HasKey(m => m.Id);
            Property(m => m.FixtureNumber).IsRequired();
            HasMany(m => m.Reservations)
                .WithRequired()
                .HasForeignKey(m => m.StockId);
            HasMany(m => m.Borrowings)
                .WithRequired()
                .HasForeignKey(m => m.StockId);
        }
    }
}
