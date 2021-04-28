using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dari.tn.Models
{
    public class Offer
    {
        public int? offerId { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string name { get; set; }
        [Required(ErrorMessage = "Please enter description")]
        public string description { get; set; }
        [Required(ErrorMessage = "Please enter adress")]
        public string adress { get; set; }
        [Required(ErrorMessage = "Please enter chamber number")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int chamNb { get; set; }
        [Required(ErrorMessage = "space")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int space { get; set; }
        [Required(ErrorMessage = "Please enter price")]
        [Range(0, float.MaxValue, ErrorMessage = "Please enter valid Number")]
        public float price { get; set; }
        [Required(ErrorMessage = "Please enter how many levels")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int levelNb { get; set; }
        [Required(ErrorMessage = "Please enter start date")]
        [DataType(DataType.Date)]
        public DateTime? startD { get; set; }
        [Required(ErrorMessage = "Please enter end date")]
        [DataType(DataType.Date)]
        public DateTime? endD { get; set; }
        [Required(ErrorMessage = "Please enter pool")]
        public string pool { get; set; }
        [Required(ErrorMessage = "Please enter type")]
        public string type { get; set; }
        [Required(ErrorMessage = "Please enter air condition")]
        public string airC { get; set; }


        // foreign Key properties
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Seller> Sellers { get; set; }



    }
}