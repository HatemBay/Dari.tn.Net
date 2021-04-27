using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dari.tn.Models
{
    public class Subscription
    {
        [ForeignKey("User")]
        public int subId { get; set; }
        public int duration { get; set; }
        public double price { get; set; }
        public DateTime startDate { get; set; }
        public DateTime finishDate { get; set; }
        public int fidelity { get; set; }
        public int state { get; set; }
        public int payed { get; set; }
        public int? chargeId { get; set; }
        public ChargeRequestH chargeRequest{ get; set; }
        public long Id { get; set; }
        public User user { get; set; }
    }
}