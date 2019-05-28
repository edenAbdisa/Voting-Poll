using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voting.Models
{
    public class applicationUser:IdentityUser
    {
        public applicationUser() : base() {
        } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MotherName { get; set; }
        public string BirthDate { get; set; }
        public string Woreda { get; set; }
        public string HouseNumber { get; set; }
        public string Subcity { get; set; }
        public string City { get; set; }
        public string IdNumber { get; set; }
        public string FileNumber { get; set; }
    }
}
