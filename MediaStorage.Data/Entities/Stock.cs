using System.Collections.Generic;

namespace MediaStorage.Data.Entities
{
    public class Stock : BaseEntity<int>
    {
        public string Barcode { get; set; }

        public string Location { get; set; }

        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual ICollection<Lending> Lendings { get; set; }
    }

    class StockConfiguration : BaseConfiguration<Stock>
    {
        internal StockConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Barcode)
                .IsRequired();
            Property(m => m.Location)
                .IsRequired()
                .HasMaxLength(255);
            HasMany(m => m.Reservations)
                .WithRequired()
                .HasForeignKey(m => m.StockId);
            HasMany(m => m.Lendings)
                .WithRequired()
                .HasForeignKey(m => m.StockId);
        }
    }
}
