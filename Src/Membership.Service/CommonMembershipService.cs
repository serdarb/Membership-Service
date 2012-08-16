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
            if (!this.db.Cities.Any(x => x.DeletedOn.HasValue == false && x.Name.Trim() == x.Name.Trim()))
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
            if (!this.db.Counties.Any(x => x.DeletedOn.HasValue == false && x.Name.Trim() == x.Name.Trim()))
            {
                this.db.Counties.Add(new County
                {
                    CreatedOn = DateTime.Now,
                    UpdatedBy = dto.UpdatedBy,
                    Comment = dto.Comment,

                    Name = dto.Name,
                    CityId=dto.City.Id
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
            if (!this.db.AdminMenuItems.Any(x => x.DeletedOn.HasValue == false && x.Name.Trim() == x.Name.Trim()))
            {
                this.db.AdminMenuItems.Add(new AdminMenuItem
                {
                    CreatedOn = DateTime.Now,
                    UpdatedBy = dto.UpdatedBy,
                    Comment = dto.Comment,

                    AdminMenuItemGroupId = dto.AdminMenuItemGroup.Id,
                    Name = dto.Name,
                    Description=dto.Description,
                    NavigateUrl=dto.NavigateUrl,
                    DisplayOrder=dto.DisplayOrder                    
                });

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateAdminMenuItem(AdminMenuItemDto dto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAdminMenuItem(AdminMenuItemDto dto)
        {
            throw new NotImplementedException();
        } 
        #endregion

        #region AdminMenuItemGroup
        public List<AdminMenuItemGroupDto> GetAdminMenuItemGroups()
        {
            throw new NotImplementedException();
        }

        public bool AddAdminMenuItemGroup(AdminMenuItemGroupDto dto)
        {
            throw new NotImplementedException();
        }

        public bool UpdatAdddminMenuItemGroup(AdminMenuItemGroupDto dto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAdddminMenuItemGroup(AdminMenuItemGroupDto dto)
        {
            throw new NotImplementedException();
        } 
        #endregion

        #region AdminMenuItemRole
        public List<AdminMenuItemRoleDto> GetAdminMenuItemRoles()
        {
            throw new NotImplementedException();
        }

        public bool AddAdminMenuItemRole(AdminMenuItemRoleDto dto)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAdminMenuItemRole(AdminMenuItemRoleDto dto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAdminMenuItemRole(AdminMenuItemRoleDto dto)
        {
            throw new NotImplementedException();
        } 
        #endregion

        #region AdminRole
        public List<AdminRoleDto> GetAdminRoles()
        {
            throw new NotImplementedException();
        }

        public bool AddAdminRole(AdminRoleDto dto)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAdminRole(AdminRoleDto dto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAdminRole(AdminRoleDto dto)
        {
            throw new NotImplementedException();
        } 
        #endregion

        #region EmployeeAdminRole
        public List<EmployeeAdminRoleDto> GetEmployeeAdminRoles()
        {
            throw new NotImplementedException();
        }

        public bool AddEmployeeAdminRole(EmployeeAdminRoleDto dto)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEmployeeAdminRole(EmployeeAdminRoleDto dto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployeeAdminRole(EmployeeAdminRoleDto dto)
        {
            throw new NotImplementedException();
        } 
        #endregion

        #region Gender
        public List<GenderDto> GetGenders()
        {
            throw new NotImplementedException();
        }

        public bool AddGender(GenderDto dto)
        {
            throw new NotImplementedException();
        }

        public bool UpdateGender(GenderDto dto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteGender(GenderDto dto)
        {
            throw new NotImplementedException();
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
