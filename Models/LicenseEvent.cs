using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Models
{
    public sealed class LicenseEvent
    {
        public string TenantId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public List<LicenseDetail> Licenses { get; set; } = null!;
    }
    public class LicenseDetail{
        public   string SubscriptionId { get; set; } = null!;
        public string Sku { get; set; } = null!;
        public string Status { get; set; } = null!;
        public long UpdatedAt { get; set; } 

    }

}