using System;
namespace Dari.tn.Models { 
public class Factures
{
   
	public long? id { get; set; }
	public double? montant { get; set; }


	public DateTime? date_de_depart { get; set; }

	public string type { get; set; }


	public virtual Commande commande { get; set; }


}}
