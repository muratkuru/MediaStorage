using System;

namespace MediaStorage.Data.Entities
{
    public class Reservation : BaseEntity<int>
    {
        public DateTime ReservationDate { get; set; }

        public int StockId { get; set; }
        public virtual Stock Stock { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }

    class ReservationConfiguration : BaseConfiguration<Reservation>
    {
        internal ReservationConfiguration()
        {
            HasKey(m => m.Id);
        }
    }
}
