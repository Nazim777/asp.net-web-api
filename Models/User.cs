using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<CountryDetails> VisitedCountrys{ get; set; }
    }

    public class CountryDetails{
        public string Name { get; set; }
        public string Capital { get; set; }
    }
}