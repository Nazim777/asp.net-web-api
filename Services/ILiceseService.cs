using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApi.Models;

namespace MyApi.Services
{
    public interface ILiceseService
    {
        Task<List<LicenseEvent2>> GetAllLicense();
        Task<string> PublishLicense(LicenseEvent2 licenseEvent2);
    }
}