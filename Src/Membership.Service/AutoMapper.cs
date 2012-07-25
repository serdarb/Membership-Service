namespace Membership.Service
{
    using AutoMapper;

    using Membership.Contract;
    using Membership.Data;

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
            Mapper.CreateMap(typeof(User), typeof(UserDto));
            Mapper.CreateMap(typeof(UserDto), typeof(User));
            Mapper.CreateMap(typeof(UserType), typeof(UserTypeDto));
            Mapper.CreateMap(typeof(UserTypeDto), typeof(UserType));
            Mapper.CreateMap(typeof(Gender), typeof(GenderDto));
            Mapper.CreateMap(typeof(GenderDto), typeof(Gender));
            Mapper.CreateMap(typeof(Employee), typeof(EmployeeDto));
            Mapper.CreateMap(typeof(EmployeeDto), typeof(Employee));
            Mapper.CreateMap(typeof(SupplierEmployee), typeof(SupplierEmployeeDto));
            Mapper.CreateMap(typeof(SupplierEmployeeDto), typeof(SupplierEmployee));
            Mapper.CreateMap(typeof(Supplier), typeof(SupplierDto));
            Mapper.CreateMap(typeof(SupplierDto), typeof(Supplier));
        }
    }
}