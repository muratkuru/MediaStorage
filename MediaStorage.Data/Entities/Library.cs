using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace MediaStorage.Data.Entities
{
    public class Library : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Department> Departments { get; set; }

        public ICollection<Stock> Stocks { get; set; }
    }

    class LibraryMap : EntityTypeConfiguration<Library>
    {
        internal LibraryMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Name).IsRequired();
            HasMany(m => m.Departments)
                .WithRequired()
                .HasForeignKey(m => m.LibraryId);
            HasMany(m => m.Stocks)
                .WithRequired()
                .HasForeignKey(m => m.LibraryId);
        }
    }
}
