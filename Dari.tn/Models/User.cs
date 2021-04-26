using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Dari.tn.Models
{
	public class User
	{
		public int MyProperty { get; set; }

		public long id { get; set; }

		public string FirstName { get; set; }

		public string Lastname { get; set; }

		public DateTime dateNaissance { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		// foreign Key properties


		public virtual ICollection<Commande> commandes { get; set; }
		public virtual LigneCommande ligneCommande { get; set; }
	}
}