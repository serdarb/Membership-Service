using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Membership.Contract;
using AutoMapper;
using Membership.Data.Entity;

namespace Membership.Service
{
    public class CommonMembershipService : BaseMembershipService, ICommonMembershipService
    {
        #region Country

        public List<CountryDto> GetCountries()
        {
            var countries = this.db.Countries.Where(x => x.DeletedOn.HasValue == false);
            var dtos = new List<CountryDto>();
            foreach (var country in countries)
            {
                dtos.Add(Mapper.Map<Country, CountryDto>(country));
            }

            return dtos;
        }

        public bool AddCountry(CountryDto country)
        {
            if (!this.db.Countries.Any(x => x.DeletedOn.HasValue == false && x.Name.Trim() == country.Name.Trim()))
            {
                this.db.Countries.Add(new Country
                {
                    CreatedOn = DateTime.Now,
                    UpdatedBy = country.UpdatedBy,
                    Comment = country.Comment,

                    Name = country.Name,
                    ShortName = country.ShortName,
                    CountryCode = country.CountryCode
                });

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateCountry(CountryDto dto)
        {
            var country = this.db.Countries.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);

            if (country != null)
            {
                country.UpdatedOn = DateTime.Now;
                country.UpdatedBy = dto.UpdatedBy;
                country.Comment = dto.Comment;

                country.Name = dto.Name;
                country.CountryCode = dto.CountryCode;
                country.ShortName = dto.ShortName;

                this.db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteCountry(CountryDto dto)
        {
            var country = this.db.Countries.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Name.Trim() == dto.Name.Trim());
            if (country != null)
            {
                country.DeletedOn = DateTime.Now;
                country.UpdatedBy = dto.UpdatedBy;
                country.Comment = dto.Comment;

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion

        #region City

        public List<CityDto> GetCities()
        {
            var cities = this.db.Cities.Where(x => x.DeletedOn.HasValue == false);
            var dtos = new List<CityDto>();

            foreach (var city in cities)
            {
                dtos.Add(Mapper.Map<City, CityDto>(city));
            }

            return dtos;
        }

        public bool AddCity(CityDto dto)
        {
            if (!this.db.Cities.Any(x => x.DeletedOn.HasValue == false && x.Name.Trim() == dto.Name.Trim()))
            {
                this.db.Cities.Add(new City
                {
                    CreatedOn = DateTime.Now,
                    UpdatedBy = dto.UpdatedBy,
                    Comment = dto.Comment,

                    Name = dto.Name,
                    GeoZoneId = dto.GeoZone.Id
                });

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateCity(CityDto dto)
        {
            var city = this.db.Cities.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (city != null)
            {
                city.UpdatedOn = DateTime.Now;
                city.UpdatedBy = dto.UpdatedBy;
                city.Comment = dto.Comment;

                city.Name = dto.Name;
                city.GeoZoneId = dto.GeoZone.Id;

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteCity(CityDto dto)
        {
            var city = this.db.Cities.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (city != null)
            {
                city.DeletedOn = DateTime.Now;
                city.UpdatedBy = dto.UpdatedBy;
                city.Comment = dto.Comment;

                this.db.SaveChanges();
                return true;
            }
            return false;

        }

        #endregion

        #region County

        public List<CountyDto> GetCounties()
        {
            var counties = this.db.Counties.Where(x => x.DeletedOn.HasValue == false);
            var dtos = new List<CountyDto>();

            foreach (var county in counties)
            {
                dtos.Add(Mapper.Map<County, CountyDto>(county));
            }

            return dtos;
        }

        public bool AddCounty(CountyDto dto)
        {
            if (!this.db.Counties.Any(x => x.DeletedOn.HasValue == false && x.Name.Trim() == dto.Name.Trim()))
            {
                this.db.Counties.Add(new County
                {
                    CreatedOn = DateTime.Now,
                    UpdatedBy = dto.UpdatedBy,
                    Comment = dto.Comment,

                    Name = dto.Name,
                    CityId = dto.City.Id
                });

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateCounty(CountyDto dto)
        {
            var county = this.db.Counties.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (county != null)
            {
                county.UpdatedOn = DateTime.Now;
                county.UpdatedBy = dto.UpdatedBy;
                county.Comment = dto.Comment;

                county.Name = dto.Name;
                county.CityId = dto.City.Id;

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteCounty(CountyDto dto)
        {
            var county = this.db.Counties.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (county != null)
            {
                county.DeletedOn = DateTime.Now;
                county.UpdatedBy = dto.UpdatedBy;
                county.Comment = dto.Comment;

                this.db.SaveChanges();
                return true;
            }
            return false; ;
        }

        #endregion

        #region AdminMenuItem

        public List<AdminMenuItemDto> GetAdminMenuItems()
        {
            var adminMenuItems = this.db.AdminMenuItems.Where(x => x.DeletedOn.HasValue == false);
            var dtos = new List<AdminMenuItemDto>();

            foreach (var adminMenuItem in adminMenuItems)
            {
                dtos.Add(Mapper.Map<AdminMenuItem, AdminMenuItemDto>(adminMenuItem));
            }

            return dtos;
        }

        public bool AddAdminMenuItem(AdminMenuItemDto dto)
        {
            if (!this.db.AdminMenuItems.Any(x => x.DeletedOn.HasValue == false && x.Name.Trim() == dto.Name.Trim()))
            {
                this.db.AdminMenuItems.Add(new AdminMenuItem
                {
                    CreatedOn = DateTime.Now,
                    UpdatedBy = dto.UpdatedBy,
                    Comment = dto.Comment,

                    AdminMenuItemGroupId = dto.AdminMenuItemGroup.Id,
                    Name = dto.Name,
                    Description = dto.Description,
                    NavigateUrl = dto.NavigateUrl,
                    DisplayOrder = dto.DisplayOrder
                });

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateAdminMenuItem(AdminMenuItemDto dto)
        {
            var updateAdminMenuItem = this.db.AdminMenuItems.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (updateAdminMenuItem != null)
            {
                updateAdminMenuItem.UpdatedOn = DateTime.Now;
                updateAdminMenuItem.UpdatedBy = dto.UpdatedBy;
                updateAdminMenuItem.Comment = dto.Comment;

                updateAdminMenuItem.AdminMenuItemGroupId = dto.AdminMenuItemGroup.Id;
                updateAdminMenuItem.Name = dto.Name;
                updateAdminMenuItem.Description = dto.Description;
                updateAdminMenuItem.NavigateUrl = dto.NavigateUrl;
                updateAdminMenuItem.DisplayOrder = dto.DisplayOrder;

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteAdminMenuItem(AdminMenuItemDto dto)
        {
            var updateAdminMenuItem = this.db.AdminMenuItems.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (updateAdminMenuItem != null)
            {
                updateAdminMenuItem.DeletedOn = DateTime.Now;
                updateAdminMenuItem.UpdatedBy = dto.UpdatedBy;
                updateAdminMenuItem.Comment = dto.Comment;

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion

        #region AdminMenuItemGroup

        public List<AdminMenuItemGroupDto> GetAdminMenuItemGroups()
        {
            var adminMenuItemGroups = this.db.AdminMenuItemGroups.Where(x => x.DeletedOn.HasValue == false);
            var dtos = new List<AdminMenuItemGroupDto>();

            foreach (var adminMenuItemGroup in adminMenuItemGroups)
            {
                dtos.Add(Mapper.Map<AdminMenuItemGroup, AdminMenuItemGroupDto>(adminMenuItemGroup));
            }

            return dtos;
        }

        public bool AddAdminMenuItemGroup(AdminMenuItemGroupDto dto)
        {
            if (!this.db.AdminMenuItemGroups.Any(x => x.DeletedOn.HasValue == false && x.Name.Trim() == dto.Name.Trim()))
            {
                this.db.AdminMenuItemGroups.Add(new AdminMenuItemGroup
                {
                    CreatedOn = DateTime.Now,
                    UpdatedBy = dto.UpdatedBy,
                    Comment = dto.Comment,

                    ParentAdminMenuItemGroupId = dto.ParentAdminMenuItemGroup.Id,
                    Name = dto.Name,
                    Description = dto.Description,
                    NavigateUrl = dto.NavigateUrl,
                    DisplayOrder = dto.DisplayOrder
                });

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdatAdddminMenuItemGroup(AdminMenuItemGroupDto dto)
        {
            var AdminMenuItemGroup = this.db.AdminMenuItemGroups.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (AdminMenuItemGroup != null)
            {
                AdminMenuItemGroup.UpdatedOn = DateTime.Now;
                AdminMenuItemGroup.UpdatedBy = dto.UpdatedBy;
                AdminMenuItemGroup.Comment = dto.Comment;

                AdminMenuItemGroup.ParentAdminMenuItemGroupId = dto.ParentAdminMenuItemGroup.Id;
                AdminMenuItemGroup.Name = dto.Name;
                AdminMenuItemGroup.Description = dto.Description;
                AdminMenuItemGroup.NavigateUrl = dto.NavigateUrl;
                AdminMenuItemGroup.DisplayOrder = dto.DisplayOrder;

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteAdddminMenuItemGroup(AdminMenuItemGroupDto dto)
        {
            var adminMenuItemGroup = this.db.AdminMenuItemGroups.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (adminMenuItemGroup != null)
            {
                adminMenuItemGroup.DeletedOn = DateTime.Now;
                adminMenuItemGroup.UpdatedBy = dto.UpdatedBy;
                adminMenuItemGroup.Comment = dto.Comment;

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion

        #region AdminMenuItemRole

        public List<AdminMenuItemRoleDto> GetAdminMenuItemRoles()
        {
            var adminMenuItemRoles = this.db.AdminMenuItemRoles.Where(x => x.DeletedOn.HasValue == false);
            var dtos = new List<AdminMenuItemRoleDto>();

            foreach (var adminMenuItemRole in adminMenuItemRoles)
            {
                dtos.Add(Mapper.Map<AdminMenuItemRole, AdminMenuItemRoleDto>(adminMenuItemRole));
            }

            return dtos;
        }

        public bool AddAdminMenuItemRole(AdminMenuItemRoleDto dto)
        {
            if (!this.db.AdminMenuItemRoles.Any(x => x.DeletedOn.HasValue == false && x.Id == dto.Id))
            {
                this.db.AdminMenuItemRoles.Add(new AdminMenuItemRole
                {
                    CreatedOn = DateTime.Now,
                    UpdatedBy = dto.UpdatedBy,
                    Comment = dto.Comment,

                    AdminMenuItemId = dto.AdminMenuItem.Id,
                    AdminRoleId = dto.AdminMenuItem.Id
                });

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateAdminMenuItemRole(AdminMenuItemRoleDto dto)
        {
            var adminMenuItemRole = this.db.AdminMenuItemRoles.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (adminMenuItemRole != null)
            {
                adminMenuItemRole.UpdatedOn = DateTime.Now;
                adminMenuItemRole.UpdatedBy = dto.UpdatedBy;
                adminMenuItemRole.Comment = dto.Comment;

                adminMenuItemRole.AdminMenuItemId = dto.AdminMenuItem.Id;
                adminMenuItemRole.AdminRoleId = dto.AdminMenuItem.Id;

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteAdminMenuItemRole(AdminMenuItemRoleDto dto)
        {
            var adminMenuItemRole = this.db.AdminMenuItemRoles.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (adminMenuItemRole != null)
            {
                adminMenuItemRole.DeletedOn = DateTime.Now;
                adminMenuItemRole.UpdatedBy = dto.UpdatedBy;
                adminMenuItemRole.Comment = dto.Comment;

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion

        #region AdminRole

        public List<AdminRoleDto> GetAdminRoles()
        {
            var adminRoles = this.db.AdminRoles.Where(x => x.DeletedOn.HasValue == false);
            var dtos = new List<AdminRoleDto>();

            foreach (var adminRole in adminRoles)
            {
                dtos.Add(Mapper.Map<AdminRole, AdminRoleDto>(adminRole));
            }

            return dtos;
        }

        public bool AddAdminRole(AdminRoleDto dto)
        {
            if (!this.db.AdminRoles.Any(x => x.DeletedOn.HasValue == false && x.Id == dto.Id))
            {
                this.db.AdminRoles.Add(new AdminRole
                {
                    CreatedOn = DateTime.Now,
                    UpdatedBy = dto.UpdatedBy,
                    Comment = dto.Comment,

                    Name = dto.Name,
                    Description = dto.Description
                });

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateAdminRole(AdminRoleDto dto)
        {
            var adminRole = this.db.AdminRoles.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (adminRole != null)
            {
                adminRole.UpdatedOn = DateTime.Now;
                adminRole.UpdatedBy = dto.UpdatedBy;
                adminRole.Comment = dto.Comment;

                adminRole.Name = dto.Name;
                adminRole.Description = dto.Description;

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteAdminRole(AdminRoleDto dto)
        {
            var adminRole = this.db.AdminRoles.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (adminRole != null)
            {
                adminRole.DeletedOn = DateTime.Now;
                adminRole.UpdatedBy = dto.UpdatedBy;
                adminRole.Comment = dto.Comment;

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion

        #region EmployeeAdminRole

        public List<EmployeeAdminRoleDto> GetEmployeeAdminRoles()
        {
            var employeeAdminRoles = this.db.EmployeeAdminRoles.Where(x => x.DeletedOn.HasValue == false);
            var dtos = new List<EmployeeAdminRoleDto>();

            foreach (var employeeAdminRole in employeeAdminRoles)
            {
                dtos.Add(Mapper.Map<EmployeeAdminRole, EmployeeAdminRoleDto>(employeeAdminRole));
            }

            return dtos;
        }

        public bool AddEmployeeAdminRole(EmployeeAdminRoleDto dto)
        {
            if (!this.db.EmployeeAdminRoles.Any(x => x.DeletedOn.HasValue == false && x.Id == dto.Id))
            {
                this.db.EmployeeAdminRoles.Add(new EmployeeAdminRole
                {
                    CreatedOn = DateTime.Now,
                    UpdatedBy = dto.UpdatedBy,
                    Comment = dto.Comment,

                    AdminRoleId = dto.AdminRole.Id,
                    EmployeeId = dto.Employee.Id
                });

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateEmployeeAdminRole(EmployeeAdminRoleDto dto)
        {
            var employeeAdminRole = this.db.EmployeeAdminRoles.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (employeeAdminRole != null)
            {
                employeeAdminRole.UpdatedOn = DateTime.Now;
                employeeAdminRole.UpdatedBy = dto.UpdatedBy;
                employeeAdminRole.Comment = dto.Comment;

                employeeAdminRole.AdminRoleId = dto.AdminRole.Id;
                employeeAdminRole.EmployeeId = dto.Employee.Id;

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteEmployeeAdminRole(EmployeeAdminRoleDto dto)
        {
            var employeeAdminRole = this.db.EmployeeAdminRoles.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (employeeAdminRole != null)
            {
                employeeAdminRole.DeletedOn = DateTime.Now;
                employeeAdminRole.UpdatedBy = dto.UpdatedBy;
                employeeAdminRole.Comment = dto.Comment;

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion

        #region Gender

        public List<GenderDto> GetGenders()
        {
            var genders = this.db.Genders.Where(x => x.DeletedOn.HasValue == false);
            var dtos = new List<GenderDto>();

            foreach (var gender in genders)
            {
                dtos.Add(Mapper.Map<Gender, GenderDto>(gender));
            }

            return dtos;
        }

        public bool AddGender(GenderDto dto)
        {
            if (!this.db.Genders.Any(x => x.DeletedOn.HasValue == false && x.Id == dto.Id))
            {
                this.db.Genders.Add(new Gender
                {
                    CreatedOn = DateTime.Now,
                    UpdatedBy = dto.UpdatedBy,
                    Comment = dto.Comment,

                    Name = dto.Name,
                    Description = dto.Description
                });

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateGender(GenderDto dto)
        {
            var gender = this.db.Genders.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (gender != null)
            {
                gender.UpdatedOn = DateTime.Now;
                gender.UpdatedBy = dto.UpdatedBy;
                gender.Comment = dto.Comment;

                gender.Name = dto.Name;
                gender.Description = dto.Description;

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteGender(GenderDto dto)
        {
            var gender = this.db.Genders.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (gender != null)
            {
                gender.DeletedOn = DateTime.Now;
                gender.UpdatedBy = dto.UpdatedBy;
                gender.Comment = dto.Comment;

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion


        #region GeoZone

        public List<GeoZoneDto> GetGeoZones()
        {
            throw new NotImplementedException();
        }

        public bool AddGeoZone(GeoZoneDto dto)
        {
            throw new NotImplementedException();
        }

        public bool UpdateGeoZone(GeoZoneDto dto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteGeoZone(GeoZoneDto dto)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Log

        public List<LogDto> GetLogs()
        {
            throw new NotImplementedException();
        }

        public bool AddLog(LogDto dto)
        {
            throw new NotImplementedException();
        }

        public bool UpdateLog(LogDto dto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteLog(LogDto dto)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region LogEvent

        public List<LogEventDto> GetLogEvents()
        {
            throw new NotImplementedException();
        }

        public bool AddLogEvent(LogEventDto dto)
        {
            throw new NotImplementedException();
        }

        public bool UpdateLogEvent(LogEventDto dto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteLogEvent(LogEventDto dto)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region UserType

        public List<UserTypeDto> GetUserTypes()
        {
            throw new NotImplementedException();
        }

        public bool AddUserType(UserTypeDto dto)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUserType(UserTypeDto dto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUserType(UserTypeDto dto)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
