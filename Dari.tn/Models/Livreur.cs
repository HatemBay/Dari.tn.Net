using System;
using System.Collections.Generic;
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


		public string Nom { get; set; }


		public string Prenom { get; set; }


		public string Email { get; set; }


		public int Telephone { get; set; }


		public DateTime DatedeNaissance { get; set; }


		public int NbMission { get; set; }


		public string LieuxTravail { get; set; }

		public StateLivreur stateLivreur { get; set; }



		public virtual ICollection<Delivery> delivery { get; set; }
	}
}