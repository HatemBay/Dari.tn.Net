using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Dari.tn.Models
{
	public class Commande
	{


		public long id { get; set; }
		public DateTime? date { get; set; }
		public double? montant { get; set; }
		public string status { get; set; }
		public string typedePayment { get; set; }
		public string remise { get; set; }
		public double? PourcentageDeRemise { get; set; }
		public double? total { get; set; }


		public long? UserId { get; set; }

		public virtual User user { get; set; }


		public int? LigneCommandeId { get; set; }

		public virtual LigneCommande ligneCommande { get; set; }

		public virtual Factures factures { get; set; }

		public virtual ICollection<Furniture> furniture { get; set; }


		public long? DeliveryId { get; set; }
		public virtual Delivery delivery { get; set; }
	}

}