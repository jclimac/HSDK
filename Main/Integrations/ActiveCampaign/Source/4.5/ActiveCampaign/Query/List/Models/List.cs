namespace EyeSoft.ActiveCampaign.Query.List.Models
{
	using System;

	public class List
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public DateTime Cdate { get; set; }

		public string Private { get; set; }

		public string Userid { get; set; }

		public int SubscriberCount { get; set; }
	}
}