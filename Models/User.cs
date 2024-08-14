using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Models
{
    public sealed class User
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<CountryDetails> VisitedCountrys{ get; set; } = null!;
    }

    public class CountryDetails{
        public string Name { get; set; } = null!;
        public string Capital { get; set; } = null!;
    }
}