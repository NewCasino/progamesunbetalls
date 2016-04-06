using System;
namespace Model
{
	[Serializable]
	public class Server
	{

		public Int32 ID { get; set; }

		public String ServerName { get; set; }

		public String Ip1 { get; set; }

		public String Ip2 { get; set; }

		public String Ip3 { get; set; }

		public String SubDomain { get; set; }

		public Int32 OnlineNumber { get; set; }

		public String Area { get; set; }

		public String Status { get; set; }

		public DateTime UpdateDate { get; set; }

		public DateTime AddDate { get; set; }

		public String ReMark { get; set; }
	}
}
