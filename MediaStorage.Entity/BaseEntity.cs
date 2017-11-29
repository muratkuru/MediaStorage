using System;

namespace MediaStorage.Entity
{
    public class BaseEntity
    {
        public DateTime AddedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
