using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Dari.tn.Models
{
    public class LigneCommande
    {

        public long? id { get; set; }

        public long? UserId { get; set; }
        public virtual User User { get; set; }


        public virtual ICollection<Commande> commande { get; set; }

        public virtual ICollection<Furniture> furniture { get; set; }

    }
}