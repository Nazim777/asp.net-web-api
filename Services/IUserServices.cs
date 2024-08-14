using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApi.Models;

namespace MyApi.Services
{
    public interface IUserServices
    {
       
        Task<List<User>> GetALlUserAsync();
        Task<string> PostUserAsync(User user);
        Task<string> PublishLicenseEvent(LicenseEvent licenseEvent);
        Task<List<LicenseEvent>> GetAllLicense();
    }
}