using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace MediaStorage.Entity.Models
{
    public class Department : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int LibraryId { get; set; }
        public virtual Library Library { get; set; }

        public ICollection<Stock> Stocks { get; set; }
    }

    class DepartmentMap : EntityTypeConfiguration<Department>
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
