namespace Membership.Service
{
    using AutoMapper;

    using Membership.Contract;
    using Membership.Data.Entity;

    /// <summary>
    /// The auto mapper.
    /// </summary>
    public static class AutoMapperConfiguration
    {
        /// <summary>
        /// The create maps.
        /// </summary>
        public static void CreateMaps()
        {
            Mapper.CreateMap(typeof(AddressDto), typeof(Address));
            Mapper.CreateMap(typeof(Address), typeof(AddressDto));
            Mapper.CreateMap(typeof(AdminMenuItem), typeof(AdminMenuItemDto));
            Mapper.CreateMap(typeof(AdminMenuItemDto), typeof(AdminMenuItem));
            Mapper.CreateMap(typeof(AdminMenuItemRole), typeof(AdminMenuItemRoleDto));
            Mapper.CreateMap(typeof(AdminMenuItemRoleDto), typeof(AdminMenuItemRole));
            Mapper.CreateMap(typeof(AdminRole), typeof(AdminRoleDto));
            Mapper.CreateMap(typeof(AdminRoleDto), typeof(AdminRole));
            Mapper.CreateMap(typeof(Affiliate), typeof(AffiliateDto));
            Mapper.CreateMap(typeof(AffiliateDto), typeof(Affiliate));
            Mapper.CreateMap(typeof(City), typeof(CityDto));
            Mapper.CreateMap(typeof(CityDto), typeof(City));
            Mapper.CreateMap(typeof(Country), typeof(CountryDto));
            Mapper.CreateMap(typeof(CountryDto), typeof(Country));
            Mapper.CreateMap(typeof(County), typeof(CountyDto));
            Mapper.CreateMap(typeof(CountyDto), typeof(County));
            Mapper.CreateMap(typeof(Employee), typeof(EmployeeDto));
            Mapper.CreateMap(typeof(EmployeeDto), typeof(Employee));
            Mapper.CreateMap(typeof(EmployeeAdminRole), typeof(EmployeeAdminRoleDto));
            Mapper.CreateMap(typeof(EmployeeAdminRoleDto), typeof(EmployeeAdminRole));
            Mapper.CreateMap(typeof(Gender), typeof(GenderDto));
            Mapper.CreateMap(typeof(GenderDto), typeof(Gender));
            Mapper.CreateMap(typeof(GeoZone), typeof(GeoZoneDto));
            Mapper.CreateMap(typeof(GeoZoneDto), typeof(GeoZone));
            Mapper.CreateMap(typeof(Log), typeof(LogDto));
            Mapper.CreateMap(typeof(LogDto), typeof(Log));
            Mapper.CreateMap(typeof(LogEvent), typeof(LogEventDto));
            Mapper.CreateMap(typeof(LogEventDto), typeof(LogEvent));
            Mapper.CreateMap(typeof(Phone), typeof(PhoneDto));
            Mapper.CreateMap(typeof(PhoneDto), typeof(Phone));
            Mapper.CreateMap(typeof(Supplier), typeof(SupplierDto));
            Mapper.CreateMap(typeof(SupplierDto), typeof(Supplier));
            Mapper.CreateMap(typeof(SupplierEmployee), typeof(SupplierEmployeeDto));
            Mapper.CreateMap(typeof(SupplierEmployeeDto), typeof(SupplierEmployee));
            Mapper.CreateMap(typeof(User), typeof(UserDto));
            Mapper.CreateMap(typeof(UserDto), typeof(User));
            Mapper.CreateMap(typeof(UserType), typeof(UserTypeDto));
            Mapper.CreateMap(typeof(UserTypeDto), typeof(UserType));
        }
    }
}