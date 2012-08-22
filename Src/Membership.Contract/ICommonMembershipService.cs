using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Membership.Contract
{
    [ServiceContract]
    public interface ICommonMembershipService
    {
        [OperationContract]
        List<CountryDto> GetCountries();

        [OperationContract]
        bool AddCountry(CountryDto country);

        [OperationContract]
        bool UpdateCountry(CountryDto country);

        [OperationContract]
        bool DeleteCountry(CountryDto country);


        [OperationContract]
        List<CityDto> GetCities();

        [OperationContract]
        bool AddCity(CityDto dto);

        [OperationContract]
        bool UpdateCity(CityDto dto);

        [OperationContract]
        bool DeleteCity(CityDto dto);


        [OperationContract]
        List<CountyDto> GetCounties();

        [OperationContract]
        bool AddCounty(CountyDto dto);

        [OperationContract]
        bool UpdateCounty(CountyDto dto);

        [OperationContract]
        bool DeleteCounty(CountyDto dto);


        [OperationContract]
        List<AdminMenuItemDto> GetAdminMenuItems();

        [OperationContract]
        bool AddAdminMenuItem(AdminMenuItemDto dto);

        [OperationContract]
        bool UpdateAdminMenuItem(AdminMenuItemDto dto);

        [OperationContract]
        bool DeleteAdminMenuItem(AdminMenuItemDto dto);

        [OperationContract]
        int GetAdminMenuItemIdByName(string Name);


        [OperationContract]
        List<AdminMenuItemGroupDto> GetAdminMenuItemGroups();

        [OperationContract]
        bool AddAdminMenuItemGroup(AdminMenuItemGroupDto dto);

        [OperationContract]
        bool UpdatAdminMenuItemGroup(AdminMenuItemGroupDto dto);

        [OperationContract]
        bool DeleteAdminMenuItemGroup(AdminMenuItemGroupDto dto);

        [OperationContract]
        int GetAdminMenuItemGroupIdByName(string Name);


        [OperationContract]
        List<AdminMenuItemRoleDto> GetAdminMenuItemRoles();

        [OperationContract]
        bool AddAdminMenuItemRole(AdminMenuItemRoleDto dto);

        [OperationContract]
        bool UpdateAdminMenuItemRole(AdminMenuItemRoleDto dto);

        [OperationContract]
        bool DeleteAdminMenuItemRole(AdminMenuItemRoleDto dto);


        [OperationContract]
        List<AdminRoleDto> GetAdminRoles();

        [OperationContract]
        bool AddAdminRole(AdminRoleDto dto);

        [OperationContract]
        bool UpdateAdminRole(AdminRoleDto dto);

        [OperationContract]
        bool DeleteAdminRole(AdminRoleDto dto);


        [OperationContract]
        List<EmployeeAdminRoleDto> GetEmployeeAdminRoles();

        [OperationContract]
        bool AddEmployeeAdminRole(EmployeeAdminRoleDto dto);

        [OperationContract]
        bool UpdateEmployeeAdminRole(EmployeeAdminRoleDto dto);

        [OperationContract]
        bool DeleteEmployeeAdminRole(EmployeeAdminRoleDto dto);


        [OperationContract]
        List<GenderDto> GetGenders();

        [OperationContract]
        bool AddGender(GenderDto dto);

        [OperationContract]
        bool UpdateGender(GenderDto dto);

        [OperationContract]
        bool DeleteGender(GenderDto dto);


        [OperationContract]
        List<GeoZoneDto> GetGeoZones();

        [OperationContract]
        bool AddGeoZone(GeoZoneDto dto);

        [OperationContract]
        bool UpdateGeoZone(GeoZoneDto dto);

        [OperationContract]
        bool DeleteGeoZone(GeoZoneDto dto);


        [OperationContract]
        List<LogDto> GetLogs();

        [OperationContract]
        bool AddLog(LogDto dto);

        [OperationContract]
        bool UpdateLog(LogDto dto);


        [OperationContract]
        List<LogEventDto> GetLogEvents();

        [OperationContract]
        bool AddLogEvent(LogEventDto dto);

        [OperationContract]
        bool UpdateLogEvent(LogEventDto dto);

        [OperationContract]
        bool DeleteLogEvent(LogEventDto dto);


        [OperationContract]
        List<UserTypeDto> GetUserTypes();

        [OperationContract]
        bool AddUserType(UserTypeDto dto);

        [OperationContract]
        bool UpdateUserType(UserTypeDto dto);

        [OperationContract]
        bool DeleteUserType(UserTypeDto dto);






    }
}
