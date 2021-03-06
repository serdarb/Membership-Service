﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Membership.Contract;
using AutoMapper;
using Membership.Data.Entity;
using System.Data.Entity;

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
                    UpdatedOn=DateTime.Now,
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
            var country = this.db.Countries.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
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

        public int GetCountryIdByGeoZoneId(int Id)
        {
            var geoZone = this.db.GeoZones
                .Include(x => x.Country)
                .FirstOrDefault(x=>x.DeletedOn.HasValue==false && x.Id==Id);

            if (geoZone!=null)
            {
                return geoZone.Country.Id;
            }

            return 0;
        }

        #endregion

        #region City

        public List<CityDto> GetCities()
        {
            var cities = this.db.Cities
                .Include(x=>x.GeoZone)
                .Where(x => x.DeletedOn.HasValue == false);
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
                    UpdatedOn=DateTime.Now,
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
            var counties = this.db.Counties
                .Include(x=>x.City)
                .Where(x => x.DeletedOn.HasValue == false);
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
                    UpdatedOn=DateTime.Now,
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

        public List<CountyDto> GetCountiesByCityId(int Id)
        {
            var counties = this.db.Counties.Where(x => x.DeletedOn.HasValue == false && x.CityId==Id);
            var dtos = new List<CountyDto>();

            foreach (var county in counties)
            {
                dtos.Add(Mapper.Map<County, CountyDto>(county));
            }

            return dtos;
        }

        #endregion

        #region AdminMenuItem

        public List<AdminMenuItemDto> GetAdminMenuItems()
        {
            var adminMenuItems = this.db.AdminMenuItems
                    .Include(x => x.ParentAdminMenuItem)
                    .Where(x => x.DeletedOn.HasValue == false);
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
                var adminMenuItem = new AdminMenuItem
                {
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    UpdatedBy = dto.UpdatedBy,
                    Comment = dto.Comment,

                    Name = dto.Name,
                    Description = dto.Description,
                    NavigateUrl = dto.NavigateUrl,
                    DisplayOrder = dto.DisplayOrder

                };

                if (dto.ParentAdminMenuItem != null)
                {
                    adminMenuItem.ParentAdminMenuItemId = dto.ParentAdminMenuItem.Id;
                }

                this.db.AdminMenuItems.Add(adminMenuItem);

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

                updateAdminMenuItem.ParentAdminMenuItemId = dto.ParentAdminMenuItem.Id;
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

        public int GetAdminMenuItemIdByName(string Name)
        {
            var adminMenuItem = this.db.AdminMenuItems.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Name.Trim() == Name.Trim());
            if (adminMenuItem != null)
            {
                return adminMenuItem.Id;
            }
            return 0;
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
                    UpdatedOn = DateTime.Now,
                    UpdatedBy = dto.UpdatedBy,
                    Comment = dto.Comment,

                    AdminMenuItemId = dto.AdminMenuItem.Id,
                    AdminRoleId = dto.AdminRole.Id
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
                adminMenuItemRole.AdminRoleId = dto.AdminRole.Id;

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
                    UpdatedOn = DateTime.Now,
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
            var employeeAdminRoles = this.db.EmployeeAdminRoles
                .Include(x=>x.Employee)
                .Include(x=>x.AdminRole)
                .Where(x => x.DeletedOn.HasValue == false);
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
                    UpdatedOn = DateTime.Now,
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
                    UpdatedOn = DateTime.Now,
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
            var geoZones = this.db.GeoZones
                .Include(x=>x.Country)
                .Where(x => x.DeletedOn.HasValue == false);
            var dtos = new List<GeoZoneDto>();

            foreach (var geoZone in geoZones)
            {
                dtos.Add(Mapper.Map<GeoZone, GeoZoneDto>(geoZone));
            }

            return dtos;
        }

        public bool AddGeoZone(GeoZoneDto dto)
        {
            if (!this.db.GeoZones.Any(x => x.DeletedOn.HasValue == false && x.Id == dto.Id))
            {
                this.db.GeoZones.Add(new GeoZone
                {
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    UpdatedBy = dto.UpdatedBy,
                    Comment = dto.Comment,

                    Name = dto.Name,
                    CountryId = dto.Country.Id
                });

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateGeoZone(GeoZoneDto dto)
        {
            var geoZone = this.db.GeoZones.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (geoZone != null)
            {
                geoZone.UpdatedOn = DateTime.Now;
                geoZone.UpdatedBy = dto.UpdatedBy;
                geoZone.Comment = dto.Comment;

                geoZone.Name = dto.Name;
                geoZone.CountryId = dto.Country.Id;

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteGeoZone(GeoZoneDto dto)
        {
            var geoZone = this.db.GeoZones.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (geoZone != null)
            {
                geoZone.DeletedOn = DateTime.Now;
                geoZone.UpdatedBy = dto.UpdatedBy;
                geoZone.Comment = dto.Comment;

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public int GetGeoZoneIdByCityId(int id)
        {
            var city = this.db.Cities
                .Include(x => x.GeoZone)
                .FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == id);

            if (city != null)
            {
                return city.GeoZone.Id;
            }
            return 0;
        }

        #endregion

        #region Log

        public List<LogDto> GetLogs()
        {
            var logs = this.db.Logs.Where(x => x.DeletedOn.HasValue == false);
            var dtos = new List<LogDto>();

            foreach (var log in logs)
            {
                dtos.Add(Mapper.Map<Log, LogDto>(log));
            }

            return dtos;
        }

        public bool AddLog(LogDto dto)
        {
            if (!this.db.Logs.Any(x => x.DeletedOn.HasValue == false && x.Id == dto.Id))
            {
                this.db.Logs.Add(new Log
                {
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    UpdatedBy = dto.UpdatedBy,
                    Comment = dto.Comment,

                    LogEventId = dto.LogEvent.Id,
                    Expression = dto.Expression,
                    OldRow = dto.OldRow,
                    NewRow = dto.NewRow
                });

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateLog(LogDto dto)
        {
            var log = this.db.Logs.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (log != null)
            {
                log.UpdatedOn = DateTime.Now;
                log.UpdatedBy = dto.UpdatedBy;
                log.Comment = dto.Comment;

                log.LogEventId = dto.LogEvent.Id;
                log.Expression = dto.Expression;
                log.OldRow = dto.OldRow;
                log.NewRow = dto.NewRow;

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion

        #region LogEvent

        public List<LogEventDto> GetLogEvents()
        {
            var logEvents = this.db.LogEvents.Where(x => x.DeletedOn.HasValue == false);
            var dtos = new List<LogEventDto>();

            foreach (var logEvent in logEvents)
            {
                dtos.Add(Mapper.Map<LogEvent, LogEventDto>(logEvent));
            }

            return dtos;
        }

        public bool AddLogEvent(LogEventDto dto)
        {
            if (!this.db.LogEvents.Any(x => x.DeletedOn.HasValue == false && x.Id == dto.Id))
            {
                this.db.LogEvents.Add(new LogEvent
                {
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
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

        public bool UpdateLogEvent(LogEventDto dto)
        {
            var logEvent = this.db.LogEvents.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (logEvent != null)
            {
                logEvent.UpdatedOn = DateTime.Now;
                logEvent.UpdatedBy = dto.UpdatedBy;
                logEvent.Comment = dto.Comment;

                logEvent.Name = dto.Name;
                logEvent.Description = dto.Description;

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteLogEvent(LogEventDto dto)
        {
            var logEvent = this.db.LogEvents.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (logEvent != null)
            {
                logEvent.DeletedOn = DateTime.Now;
                logEvent.UpdatedBy = dto.UpdatedBy;
                logEvent.Comment = dto.Comment;

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion

        #region UserType

        public List<UserTypeDto> GetUserTypes()
        {
            var userTypes = this.db.UserTypes.Where(x => x.DeletedOn.HasValue == false);
            var dtos = new List<UserTypeDto>();

            foreach (var userType in userTypes)
            {
                dtos.Add(Mapper.Map<UserType, UserTypeDto>(userType));
            }

            return dtos;
        }

        public bool AddUserType(UserTypeDto dto)
        {
            if (!this.db.UserTypes.Any(x => x.DeletedOn.HasValue == false && x.Id == dto.Id))
            {
                this.db.UserTypes.Add(new UserType
                {
                    CreatedOn = DateTime.Now,
                    UpdatedOn=DateTime.Now,
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

        public bool UpdateUserType(UserTypeDto dto)
        {
            var userType = this.db.UserTypes.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (userType != null)
            {
                userType.UpdatedOn = DateTime.Now;
                userType.UpdatedBy = dto.UpdatedBy;
                userType.Comment = dto.Comment;

                userType.Name = dto.Name;
                userType.Description = dto.Description;

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteUserType(UserTypeDto dto)
        {
            var userType = this.db.UserTypes.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (userType != null)
            {
                userType.DeletedOn = DateTime.Now;
                userType.UpdatedBy = dto.UpdatedBy;
                userType.Comment = dto.Comment;

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion


    }
}
