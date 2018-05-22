using System;

namespace MediaStorage.Data.Entities
{
    public class Lending : BaseEntity<int>
    {
        public DateTime LendingDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int StockId { get; set; }
        public virtual Stock Stock { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }

    class LendingMap : BaseConfiguration<Lending>
    {
        internal LendingMap()
        {
            HasKey(m => m.Id);
            Property(m => m.LendingDate).IsRequired();
            Property(m => m.ReturnDate).IsRequired();
        }
    }

}
