using System;
using System.Collections.Generic;

namespace Dari.tn.Models
{
    public class Contract
    {
		public int contractId { get; set; }
		public int duration { get; set; }
		public DateTime startDate { get; set; }
		public double price { get; set; }
		public double totalPrice { get; set; }
		public int surveillance { get; set; }
		public int payed { get; set; }
        public int? Id { get; set; }
        public User user { get; set; }
        public ICollection<SurveillanceImages> surveillanceImages { get; set; }
    }
}