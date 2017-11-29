using System;
using System.Data.Entity.ModelConfiguration;

namespace MediaStorage.Entity.Models
{
    public class Reservation : BaseEntity
    {
        public int Id { get; set; }

        public DateTime ApplicationDate { get; set; }

        public int StockId { get; set; }
        public virtual Stock Stock { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }

    class ReservationMap : EntityTypeConfiguration<Reservation>
    {
        internal ReservationMap()
        {
            HasKey(m => m.Id);
        }
    }
}
