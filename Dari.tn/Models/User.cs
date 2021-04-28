using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dari.tn.Models
{
    public class User

    {

        public long id { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "Please enter last name")]
        public string lastname { get; set; }
        [Required(ErrorMessage = "Please enter date")]
        [DataType(DataType.Date)]
        public DateTime? dateNaissance { get; set; }
        [Required(ErrorMessage = "Please email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public ICollection<Contract> contracts { get; set; }
        public ICollection<Insurance> insurances { get; set; }
        public int? subId { get; set; }
        public Subscription subscription { get; set; }



    }
}