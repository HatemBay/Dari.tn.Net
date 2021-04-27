using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Dari.tn.Models
{
	public class Furniture
	{


		public int Id { get; set; }
		[DisplayName("Name")]
		public string name { get; set; }
		[DisplayName("Description")]
		public string description { get; set; }
		[DisplayName("Price")]
		public float price { get; set; }
		public int? quantity { get; set; }
		public long? Barcode { get; set; }
		public DateTime? publishedDate { get; set; }

		[DisplayName("Upload your image")]
		public string image { get; set; }


  
        public FurnitureState state { get; set; }


		public virtual ICollection<Commande> commande { get; set; }
		public virtual ICollection<LigneCommande> ligneCommande { get; set; }
	}
}

