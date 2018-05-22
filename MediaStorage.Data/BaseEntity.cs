using System;

namespace MediaStorage.Data
{
    public class BaseEntity
    {
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }

        public bool IsRemoved { get; set; } = false;
    }

    public class BaseEntity<T> : BaseEntity
    {
        public T Id { get; set; }
    }
}
