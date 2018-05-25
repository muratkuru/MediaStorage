using System.Collections.Generic;

namespace MediaStorage.Data.Entities
{
    public class Library : BaseEntity<int>
    {
        public string Name { get; set; }

        public ICollection<Department> Departments { get; set; }

        public ICollection<Stock> Stocks { get; set; }
    }

    class LibraryConfiguration : BaseConfiguration<Library>
    {
        internal LibraryConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(255);
            HasMany(m => m.Departments)
                .WithRequired()
                .HasForeignKey(m => m.LibraryId);
            HasMany(m => m.Stocks)
                .WithRequired()
                .HasForeignKey(m => m.LibraryId);
        }
    }
}
