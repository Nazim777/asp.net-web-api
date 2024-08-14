using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApi.Models;

namespace MyApi.Services
{
    public class UserService : IUserServices
    {
         List<User> Users = new List<User>(){
                new User{Name="Rahim",Email="rahim@gmail.com",VisitedCountrys=new List<CountryDetails>{
                    new CountryDetails{Name="USA",Capital="NYC"},
                    new CountryDetails{Name="Germany",Capital="Berlin"},
                    new CountryDetails{Name="Japan",Capital="Tokyo"}
                    }},
                new User{Name="Karim",Email="karim@gmail.com",VisitedCountrys=new List<CountryDetails>{
                    new CountryDetails{Name="Bangladesh",Capital="Dhaka"},
                    new CountryDetails{Name="India",Capital="Delhi"},
                    new CountryDetails{Name="Pakistan",Capital="Islamabad"}
                }
                },
                new User{Name="Habib",Email="habib@gmail.com",VisitedCountrys=new List<CountryDetails>
                {
                    new CountryDetails{Name="China",Capital="Beijing"},
                    new CountryDetails{Name="Germany",Capital="Berlin"}
                }},
                new User{Name="Rakib",Email="rakib@gmail.com",VisitedCountrys=new List<CountryDetails>{
                    new CountryDetails{Name="USA",Capital="NYC"}
                }}
            };

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

        public Task<List<LicenseEvent>> GetAllLicense()
        {
            return Task.FromResult(licenses);
        }

        public Task<List<User>> GetALlUserAsync()
        {
           
            return Task.FromResult(Users);
        }

        public async Task<string> PostUserAsync(User user){
            if(user==null){
                return "User is null";
            }
            if(user.Name.Length<5 ){
                return "User name is too short";
            }
            if(user.Name.Length>30){
                return "User name is too long!";
            }
            if(!user.Email.Contains(".com")){
                return "Invalid Email";
            }
            bool userExists = Users.Any(u=>u.Name==user.Name ||  u.Email==user.Email);
            if(userExists){
                return "User name or email already exist";
            }
            // check visited country
            foreach(var visitedCountry in user.VisitedCountrys){
                // validate vistied country name and capital
                if(string.IsNullOrEmpty(visitedCountry.Name) || string.IsNullOrEmpty(visitedCountry.Capital)){
                    return "Country name or Capital name cannot be empty!";
                }
                bool countryExists = Users.Any(u=>u.VisitedCountrys.Any(c=>c.Name==visitedCountry.Name));
                if(countryExists){
                    return "Visited country already exist";
                }
            }

            Users.Add(user);
            return "User created successfully!";
        }


        
        public async Task<string> PublishLicenseEvent(LicenseEvent licenseEvent)
        {
            if(!licenseEvent.Licenses.Any(l=>l.Sku=="meldminds.ellie.com")){
                return "Invalid sku name";
            }
            licenses.Add(licenseEvent);
            return "event published successfully!";
        }

       
    }
}