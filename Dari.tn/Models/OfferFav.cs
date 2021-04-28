using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dari.tn.Models
{
    public class OfferFav

    {
        public int? offerId { get; set; }
        public virtual Offer offer { get; set; }
    }
}