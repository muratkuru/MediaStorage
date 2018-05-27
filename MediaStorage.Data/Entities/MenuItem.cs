using System.Collections.Generic;

namespace MediaStorage.Data.Entities
{
    public class MenuItem : BaseEntity<int>
    {
        public string Title { get; set; }

        public string Area { get; set; }

        public string Action { get; set; }

        public string Controller { get; set; }

        public string Icon { get; set; }

        public int? RowIndex { get; set; }

        public int? ParentMenuItemId { get; set; }
        public virtual MenuItem ParentMenuItem { get; set; }

        public int MenuId { get; set; }
        public virtual Menu Menu { get; set; }

        public virtual ICollection<MenuItem> SubMenuItems { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }

    class MenuItemConfiguration : BaseConfiguration<MenuItem>
    {
        internal MenuItemConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Title)
                .HasMaxLength(255);
            Property(m => m.Area)
                .HasMaxLength(255);
            Property(m => m.Action)
                .HasMaxLength(255);
            Property(m => m.Controller)
                .HasMaxLength(255);
            Property(m => m.Icon)
                .HasMaxLength(255);
            Property(m => m.Title).IsRequired();
            HasMany(m => m.UserRoles)
                .WithMany(m => m.MenuItems)
                .Map(m =>
                {
                    m.MapLeftKey("MenuItemId");
                    m.MapRightKey("UserRoleId");
                });
        }
    }
}
