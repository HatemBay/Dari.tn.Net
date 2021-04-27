using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Dari.tn.Models
{
    public class Stripe
    {
        [DisplayName("Your customer id")]
        public string idCustomer { get; set; }
        [DisplayName("Card number")]
        public string numcart { get; set; }
        [DisplayName("Month")]
        public string mois { get; set; }
        [DisplayName("Year")]
        public string year { get; set; }
        [DisplayName("Password")]
        public string password { get; set; }

        public int? coin { get; set; }

        public string type { get; set; }


    }
}