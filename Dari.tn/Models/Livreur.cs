using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dari.tn.Models
{
	public class Livreur
	{

		public enum StateLivreur
		{
			Active, InActive
		}




		public long id { get; set; }

		[DisplayName("LastName")]
		public string nom { get; set; }

		[DisplayName("FirstName")]
		public string prenom { get; set; }

		[DisplayName("E-mail")]
		public string email { get; set; }

		[DisplayName("Phone")]
		public int? telephone { get; set; }

		[DisplayName("Date of Birth")]
		public DateTime? DatedeNaissance { get; set; }


		public int nbMission { get; set; }

		[DisplayName("Region")]
		public string lieuxTravail { get; set; }

		public StateLivreur stateLivreur { get; set; }



		public virtual ICollection<Delivery> delivery { get; set; }
	}
}