using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace MyApi.Models
{
    public sealed class LicenseEvent2
    {
        public string TenantId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public List<LicenseDetail2> Licenses {get; set;} = null!;
        
    }
    public sealed class LicenseDetail2
    {
        public string SubscriptionId { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string Sku {get;set;} =null!;
        public long UpdatedAt { get; set; }
    }
}