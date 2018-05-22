﻿using MediaStorage.Data.Entities;
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

            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new LibraryMap());
            modelBuilder.Configurations.Add(new MaterialMap());
            modelBuilder.Configurations.Add(new MaterialTypeMap());
            modelBuilder.Configurations.Add(new MaterialTypePropertyMap());
            modelBuilder.Configurations.Add(new MaterialPropertyItemMap());
            modelBuilder.Configurations.Add(new ReservationMap());
            modelBuilder.Configurations.Add(new LendingMap());
            modelBuilder.Configurations.Add(new StockMap());
            modelBuilder.Configurations.Add(new TagMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new PageMap());
            modelBuilder.Configurations.Add(new AdministratorMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
