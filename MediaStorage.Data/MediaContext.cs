using MediaStorage.Data.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MediaStorage.Data
{
    public class MediaContext : DbContext
    {
        public MediaContext()
            :base("name=MediaContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<MediaContext>(null);
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Library> Libraries { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<MaterialType> MaterialTypes { get; set; }

        public DbSet<MaterialTypeProperty> MaterialTypeProperties { get; set; }

        public DbSet<MaterialPropertyItem> MaterialPropertyItems { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Lending> Lendings { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Page> Pages { get; set; }

        public DbSet<Administrator> Administrators { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ForeignKeyIndexConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new DepartmentConfiguration());
            modelBuilder.Configurations.Add(new LibraryConfiguration());
            modelBuilder.Configurations.Add(new MaterialConfiguration());
            modelBuilder.Configurations.Add(new MaterialTypeConfiguration());
            modelBuilder.Configurations.Add(new MaterialTypePropertyConfiguration());
            modelBuilder.Configurations.Add(new MaterialPropertyItemConfiguration());
            modelBuilder.Configurations.Add(new ReservationConfiguration());
            modelBuilder.Configurations.Add(new LendingConfiguration());
            modelBuilder.Configurations.Add(new StockConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new PageConfiguration());
            modelBuilder.Configurations.Add(new AdministratorConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
