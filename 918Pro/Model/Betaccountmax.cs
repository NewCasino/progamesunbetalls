using System;
namespace Model
{
	[Serializable]
	public class Betaccountmax
	{

		public Int32 Id { get; set; }

		public Int32 Casino { get; set; }

		public String Userid { get; set; }

		public String Password { get; set; }

		public String Agent { get; set; }

		public String Loginname { get; set; }

		public Int32 Betcount { get; set; }

		public Decimal WebsitePossess { get; set; }

		public Decimal SelfPossess { get; set; }

		public Decimal Commission { get; set; }

		public Decimal Multiple { get; set; }

		public Int32 Group1 { get; set; }

		public String Address { get; set; }

		public String Address2 { get; set; }

		public Int32 Enable { get; set; }

		public Decimal Credit { get; set; }

		public String Zemo { get; set; }

		public Int32 Isquzhi { get; set; }

		public String Cookie { get; set; }

		public DateTime Time { get; set; }

		public Int32 Islogin { get; set; }

		public String Operator { get; set; }

		public DateTime Operatortime { get; set; }

		public String Operatorip { get; set; }
	}
}
