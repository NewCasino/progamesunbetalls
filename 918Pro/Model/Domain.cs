using System;
namespace Model
{
	[Serializable]
	public class Domain
	{

		public Int32 ID { get; set; }

		public String DomainName { get; set; }

		public String Ismain { get; set; }

		public String Status { get; set; }

		public DateTime UpdateDate { get; set; }

		public DateTime AddDate { get; set; }

    }
}
