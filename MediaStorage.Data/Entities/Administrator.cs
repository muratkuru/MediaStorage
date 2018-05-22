using System;

namespace MediaStorage.Data.Entities
{
    public class Administrator : BaseEntity<Guid>
    {
        public string Username { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }
    }

    class AdministratorMap : BaseConfiguration<Administrator>
    {
        internal AdministratorMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Username).IsRequired();
            Property(m => m.Mail).IsRequired();
            Property(m => m.Password).IsRequired();
        }
    }
}
