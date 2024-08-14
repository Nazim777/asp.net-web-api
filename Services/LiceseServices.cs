using System.ComponentModel;
using MyApi.Models;

namespace MyApi.Services
{
    public class LiceseServices: ILiceseService
    {
        List<LicenseEvent> licenses = new List<LicenseEvent>(){
                new LicenseEvent{TenantId="tenant_id1",UserId="user_id1",Licenses=new List<LicenseDetail>{
                    new LicenseDetail{SubscriptionId="subscriptionid_1",Sku="sku1",Status="Active",UpdatedAt=122222222222}
                }},
                new LicenseEvent{TenantId="tenant_id2",UserId="user_id2",Licenses=new List<LicenseDetail>{
                    new LicenseDetail{SubscriptionId="subscriptionid_2",Sku="sku2",Status="Inactive",UpdatedAt=2111111111}
                }},
                 new LicenseEvent{TenantId="tenant_id3",UserId="user_id3",Licenses=new List<LicenseDetail>{
                    new LicenseDetail{SubscriptionId="subscriptionid_3",Sku="sku3",Status="Active",UpdatedAt=3111111111}
                }}
            };

        //   List<LicenseEvent2> licenses2 = new List<LicenseEvent2>(){
        //     new LicenseEvent2{TenantId="testtenatid1",UserId="testuserid1",Licenses=new List<LicenseDetail2>{
        //         new LicenseDetail2{SubscriptionId="testsubscriptionid1",Sku="testSku1",Status="active",UpdatedAt=11111111}
        //     }},
        //     new LicenseEvent2 {TenantId="testtenantid2",UserId="testuserid2",Licenses= new List<LicenseDetail2>{
        //         new LicenseDetail2{SubscriptionId="testsubscrioptionid2",Sku = "testsku2",Status="active",UpdatedAt=2222222222222}
        //     }},
        //     new LicenseEvent2 {
        //         TenantId="testtenantid3",UserId="testUserid3",Licenses=new List<LicenseDetail2>{
        //             new LicenseDetail2{SubscriptionId="testsubscriptionid3",Sku="testsku3",Status="inactive",UpdatedAt=333333333333}
        //         }
        //     }

        //   };
        List<LicenseEvent2> licenses2 = new List<LicenseEvent2>(){
            new LicenseEvent2{TenantId = "tenantid1",UserId = "userid1",Licenses = new List<LicenseDetail2>{
                new LicenseDetail2{
                    SubscriptionId="subscriptionid1",Sku="sku1",Status="active",UpdatedAt = 111111111
                }
            }},
             new LicenseEvent2{TenantId = "tenantid2",UserId = "userid2",Licenses = new List<LicenseDetail2>{
                new LicenseDetail2{
                    SubscriptionId="subscriptionid2",Sku="sku2",Status="active",UpdatedAt = 2222222222
                }
            }},
            new LicenseEvent2{TenantId = "tenantid3",UserId = "userid3",Licenses = new List<LicenseDetail2>{
                new LicenseDetail2{
                    SubscriptionId="subscriptionid3",Sku="sku3",Status="inactive",UpdatedAt = 333333333
                }
            }}
        };

        public Task<List<LicenseEvent2>> GetAllLicense()
        {
           return Task.FromResult(licenses2);
        }

        public Task<string> PublishLicense(LicenseEvent2 licenseEvent2)
        {
           if(String.IsNullOrEmpty(licenseEvent2.TenantId) || String.IsNullOrEmpty(licenseEvent2.UserId)){
            return Task.FromResult("TenantId Or UserId can not be null or empty");
           }
           if(licenseEvent2.TenantId.Length<5 || licenseEvent2.UserId.Length<5){
            return Task.FromResult("TenantId or UserId lenght should not be less then 5!");
           }
           if(licenseEvent2.TenantId.Length>10 || licenseEvent2.UserId.Length>10){
            return Task.FromResult("TenantId or UserId lenght should not be more then 10!");
           }
           foreach(var existinglicense in licenses2){
            if(existinglicense.TenantId.Equals(licenseEvent2.TenantId) || existinglicense.UserId.Equals(licenseEvent2.UserId)){
                return Task.FromResult("TenantId or UserId already exist!");
            }

            foreach(var license in licenseEvent2.Licenses){
                // sku should be test.sku.com
                if(!license.Sku.Equals("test.sku.com")){
                    return Task.FromResult("Invalid sku");
                }

                // status shoule be active or inactive
                if(!license.Status.Equals("active") && !license.Status.Equals("inactive")){
                    return Task.FromResult("Invalid status, It should be Active or Inactive");
                }

               // subscription id should be unique
                if(licenses2.Any(p=>p.Licenses.Any(l=>l.SubscriptionId.Equals(license.SubscriptionId)))){
                    return Task.FromResult("subscription id should be unique");
                }
                
            }

           }
            return Task.FromResult("event publish successfully!");
        }
    }
}