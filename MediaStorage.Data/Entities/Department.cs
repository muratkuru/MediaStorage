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

    class DepartmentConfiguration : BaseConfiguration<Department>
    {
        internal DepartmentConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(255);
            HasMany(m => m.Stocks)
                .WithRequired()
                .HasForeignKey(m => m.DepartmentId);
        }
    }
}
