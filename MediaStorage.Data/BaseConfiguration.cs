using System.Data.Entity.ModelConfiguration;

namespace MediaStorage.Data
{
    class BaseConfiguration<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        internal BaseConfiguration()
        {
            Property(m => m.CreateDate)
                .HasColumnAnnotation("DefaultValueSql", "GETDATE()");
        }
    }
}
