using System;
using System.Data.Entity.ModelConfiguration;

namespace MediaStorage.Data.Entities
{
    public class Borrowing : BaseEntity
    {
        public int Id { get; set; }

        public DateTime AcceptanceDate { get; set; }

        public DateTime FinalDeliveryDate { get; set; }

        public int StockId { get; set; }
        public virtual Stock Stock { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }

    class BorrowingMap : EntityTypeConfiguration<Borrowing>
    {
        internal BorrowingMap()
        {
            HasKey(m => m.Id);
            Property(m => m.AcceptanceDate).IsRequired();
            Property(m => m.FinalDeliveryDate).IsRequired();
        }
    }

}
