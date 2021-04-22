using System;
using System.Collections.Generic;

namespace Dari.tn.Models
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public DateTime dateNaissance { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Contract> contracts { get; set; }
        public ICollection<Insurance> insurances { get; set; }
        //public int subId { get; set; }
        public Subscription subscription { get; set; }
    }
}