using System;
namespace Model
{
	[Serializable]
	public class Bankhistory
	{

		public Int32 ID { get; set; }

		public DateTime Isdate { get; set; }

		public String Currency { get; set; }

		public String Bank { get; set; }

		public String Cardno { get; set; }

		public String Typ { get; set; }

		public Decimal Amount { get; set; }

		public Decimal Balance { get; set; }

		public String Operator { get; set; }

		public DateTime Operationtime { get; set; }

		public String Ip { get; set; }
	}
}
