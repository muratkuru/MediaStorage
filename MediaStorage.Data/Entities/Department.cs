using System.Collections.Generic;

namespace MediaStorage.Data.Entities
{
    public class Department : BaseEntity<int>
    {
        public string Name { get; set; }

        public int LibraryId { get; set; }
        public virtual Library Library { get; set; }

        public ICollection<Stock> Stocks { get; set; }
    }

    class DepartmentMap : BaseConfiguration<Department>
    {
        internal DepartmentMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Name).IsRequired();
            HasMany(m => m.Stocks)
                .WithRequired()
                .HasForeignKey(m => m.DepartmentId);
        }
    }
}
