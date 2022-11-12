using DriverApplication.DTOs;
using DriverApplication.DTOs.Driver;
using DriverApplication.JwtManagers;
using DriverApplication.Models;
using DriverApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Web;

namespace DriverApplication.Repositories
{
    public class DriverRepository : RepositoryBase<Driver>, IDriverRepository
    {
        public DriverRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public void AddDriver(DriverDto driverDto)
        {
            // password hashing using bcrypt
            int salt = 6;
            string hashPasswod = BCrypt.Net.BCrypt.HashPassword(driverDto.Password, salt);
            driverDto.Password = hashPasswod;

            DriverTeam driverTeam = this.DbContext.mt_driver_team.Find(driverDto.Team_id);
            if (driverTeam != null)
            {
                Driver driver = new Driver
                {
                    First_name = driverDto.First_name,
                    Last_name = driverDto.Last_name,
                    Email = driverDto.Email,
                    Phone = driverDto.Phone,
                    Username = driverDto.Username,
                    Password = driverDto.Password,
                    DriverTeam1 = driverTeam,
                    Transport_type_id = driverDto.Transport_type_id,
                    Transport_description = driverDto.Transport_description,
                    Licence_plate = driverDto.Licence_plate,
                    Color = driverDto.Color,
                };

                this.DbContext.mt_driver.Add(driver);

            }
            else if (driverTeam == null)
            {
                Driver driver = new Driver
                {
                    First_name = driverDto.First_name,
                    Last_name = driverDto.Last_name,
                    Email = driverDto.Email,
                    Phone = driverDto.Phone,
                    Username = driverDto.Username,
                    Password = driverDto.Password,
                    DriverTeam1 = null,
                    Transport_type_id = driverDto.Transport_type_id,
                    Transport_description = driverDto.Transport_description,
                    Licence_plate = driverDto.Licence_plate,
                    Color = driverDto.Color,
                };

                this.DbContext.mt_driver.Add(driver);

            }
            else
                throw new ArgumentNullException();

        }

        //public string CheckCredentials(DriverLoginDto driverLoginDto)
        //{
        //    if(driverLoginDto!=null)
        //    {
        //        Driver driverInDb = this.DbContext.mt_driver.Where(d => d.Username == driverLoginDto.username && d.Password == driverLoginDto.password).FirstOrDefault();

        //        if (driverInDb != null)
        //        {
        //            IAuthContainerModel authContainerModel = GetJwtContainerModel(driverInDb.Driver_id, driverInDb.First_name);
        //            IAuthService authService = new JWTService(authContainerModel.SecretKey);

        //            string token = authService.GenerateToken(authContainerModel);

        //            if (!authService.IsTokenValid(token))
        //            {
        //                throw new UnauthorizedAccessException();
        //            }
        //            else
        //            {
        //                List<Claim> claims = authService.GetTokensClaim(token).ToList();
        //            }
        //            return token;
        //        }
        //        else
        //        {
        //            return "No existing driver of the username exists!";
        //        }
        //    }
        //    else
        //    {
        //        return "no credentials found";
        //    }
        //}

        //private IAuthContainerModel GetJwtContainerModel(int id, string name)
        //{
        //    return new JwtContainerModel()
        //    {
        //        Claims = new Claim[]
        //        {
        //            new Claim (ClaimTypes.Name, name),
        //            new Claim ("DriverId", id.ToString())

        //        }
        //    };
        //}

        public Driver GetDriverByName(string driverName)
        {
            var driver = this.DbContext.mt_driver.Where(c => c.First_name == driverName).FirstOrDefault();

            return driver;

        }

        public string UpdateDriver(int id, DriverDto driverDto)
        {
            // password hashing using bcrypt
            int salt = 6;
            string hashPasswod = BCrypt.Net.BCrypt.HashPassword(driverDto.Password, salt);
            driverDto.Password = hashPasswod;

            DriverTeam driverTeam = this.DbContext.mt_driver_team.Find(driverDto.Team_id);
            var driverInDb = this.DbContext.mt_driver.Find(id);
            if(driverInDb == null)
            {
                throw new ArgumentException();
            }
            
            else
            {
                
                driverInDb.First_name = driverDto.First_name;
                driverInDb.Last_name = driverDto.Last_name;
                driverInDb.Email = driverDto.Email;
                driverInDb.Phone = driverDto.Phone;
                driverInDb.Username = driverDto.Username;
                driverInDb.Password = driverDto.Password;
                driverInDb.DriverTeam1 = driverTeam;
                driverInDb.Transport_type_id = driverDto.Transport_type_id;
                driverInDb.Transport_description = driverDto.Transport_description;
                driverInDb.Licence_plate = driverDto.Licence_plate;
                driverInDb.Color = driverDto.Color;
                driverInDb.Date_modified = DateTime.Now.Date;
                driverInDb.Modified_time_stamp = DateTime.Now.TimeOfDay;
                
                this.DbContext.Entry(driverInDb).State = System.Data.Entity.EntityState.Modified;
                this.DbContext.SaveChanges();
                return "Hey!! Shady your Driver Data Updated Successfully...";

            }
        }
    }
}