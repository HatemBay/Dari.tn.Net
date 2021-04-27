using System;
using System.Collections.Generic;
<<<<<<< HEAD
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
=======

namespace Dari.tn.Models
{
    public class User
    {
        public long Id { get; set; }
        public string firstName { get; set; }
        public string lastname { get; set; }
        public DateTime dateNaissance { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public ICollection<Contract> contracts { get; set; }
        public ICollection<Insurance> insurances { get; set; }
        //public int subId { get; set; }
        public Subscription subscription { get; set; }
    }
>>>>>>> main
}