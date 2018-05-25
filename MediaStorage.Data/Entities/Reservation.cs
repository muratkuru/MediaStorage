using System;

namespace MediaStorage.Data.Entities
{
    public class Reservation : BaseEntity<int>
    {
        public DateTime ReservationDate { get; set; }

        public int StockId { get; set; }
        public virtual Stock Stock { get; set; }

        public Guid MemberId { get; set; }
        public virtual Member Member { get; set; }
    }

    class ReservationConfiguration : BaseConfiguration<Reservation>
    {
        internal ReservationConfiguration()
        {
            HasKey(m => m.Id);
        }
    }
}
