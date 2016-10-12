using System;

namespace Demo.WebSite.Mvc.Routing.Models
{
	public class CertifiedItem
	{
		public int CertifiedItemID { get; set; }
		public int CertifiedBatchID { get; set; }
		public string Address { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public string ImagePath { get; set; }
		public DateTime DateCreated { get; set; }
	}
}