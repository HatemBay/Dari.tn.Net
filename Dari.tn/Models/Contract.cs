using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dari.tn.Models
{
    public class Contract
    {
		public long contractId { get; set; }
		public int duration { get; set; }
		public DateTime startDate { get; set; }
		public double price { get; set; }
		public double totalPrice { get; set; }
		[Range(0,1)]
		public int surveillance { get; set; }
		public int payed { get; set; }
        public int? Id { get; set; }
        public User user { get; set; }
        public ICollection<SurveillanceImages> surveillanceImages { get; set; }
    }
}