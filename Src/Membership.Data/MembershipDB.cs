namespace Membership.Data
{
    using System.Configuration;
    using System.Data.Entity;

    public class MembershipDB : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Gender> Genders { get; set; }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<GeoZone> GeoZones { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<County> Counties { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierEmployee> SupplierEmployees { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<AdminMenuItemGroup> AdminMenuItemGroups { get; set; }
        public DbSet<AdminMenuItem> AdminMenuItems { get; set; }
        public DbSet<AdminMenuItemRole> AdminMenuItemRoles { get; set; }

        public DbSet<AdminRole> AdminRoles { get; set; }
        public DbSet<EmployeeAdminRole> EmployeeAdminRoles { get; set; }

        public DbSet<Log> Logs { get; set; }
        public DbSet<LogEvent> LogEvents { get; set; }

        public DbSet<Affiliate> Affiliates { get; set; }

       
    }
}