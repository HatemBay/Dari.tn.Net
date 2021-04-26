using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
namespace Dari.tn.Models
{
	public class Delivery
	{


		public enum StateDelivery
		{
			IN_PROGRESS,
			Approved
		}

		public HttpPostedFileBase Imagefile { get; set; }

		public long deliveryId { get; set; }






		public string customerName { get; set; }


		public string Lieu { get; set; }


		public string description { get; set; }

		public StateDelivery stateDelivery { get; set; }


		public int LivreurId { get; set; }

		public virtual Livreur livreur { get; set; }
		public virtual ICollection<Commande> commande { get; set; }

	}
}