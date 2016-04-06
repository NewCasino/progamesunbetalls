using System;
namespace Model
{
	[Serializable]
	public class BillLog
	{

		public Int32 ID { get; set; }

		public String UserName { get; set; }

		public String Names { get; set; }

		public String Type { get; set; }

		public Decimal Amount { get; set; }

		public DateTime SubmitTime { get; set; }

		public DateTime UpdateTime { get; set; }

		public String Status { get; set; }

		public String Reasoncn { get; set; }

		public String Reasontw { get; set; }

		public String Reasonen { get; set; }

		public String Reasonth { get; set; }

		public String Reasonvn { get; set; }

		public Int32 BankID { get; set; }

		public String Bank { get; set; }

		public String Bankaccount { get; set; }

		public String Bankno { get; set; }

		public String Cardno { get; set; }

		public String Operator { get; set; }

		public DateTime Operationtime { get; set; }

		public String Ip { get; set; }

		public String Currency { get; set; }
	}
}
