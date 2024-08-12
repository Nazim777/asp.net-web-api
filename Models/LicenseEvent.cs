using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Models
{
    public class LicenseEvent
    {
        public string TenantId { get; set; }
        public string UserId { get; set; }
        public List<LicenseDetail> Licenses { get; set; }
    }
    public class LicenseDetail{
        public   string SubscriptionId { get; set; }
        public string Sku { get; set; }
        public string Status { get; set; }
        public long UpdatedAt { get; set; }

    }

}