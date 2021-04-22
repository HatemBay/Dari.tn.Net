using System;
using System.Collections.Generic;

namespace Dari.tn.Models
{
    public class Insurance
    {
        public int insId { get; set; }
        public double price { get; set; }
        public int payed { get; set; }
        public Partner partner { get; set; }
        public DateTime startDate { get; set; }
        public ICollection<ChargeRequestH> chargeRequests{ get; set; }
        public long? Id { get; set; }
        public User user { get; set; }
    }
}