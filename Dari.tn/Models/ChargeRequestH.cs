using System.ComponentModel.DataAnnotations;

namespace Dari.tn.Models
{
    public class ChargeRequestH
    {
        public int chargeId { get; set; }
        public string description { get; set; }
        public int amount { get; set; }
        public Currency currency { get; set; }
        [EmailAddress]
        public string stripeEmail { get; set; }
        public string stripeToken { get; set; }
        public int? contractId { get; set; }
        public Contract contract { get; set; }
        public int? insId { get; set; }
        public Insurance insurance { get; set; }
        public int? subId { get; set; }
        public Subscription subscription { get; set; }

    }
}