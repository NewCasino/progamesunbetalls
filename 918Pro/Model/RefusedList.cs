using System;
namespace Model
{
	[Serializable]
	public class RefusedList
	{

		public Int32 ID { get; set; }

		public String Reasoncn { get; set; }

		public String Reasontw { get; set; }

		public String Reasonen { get; set; }

		public String Reasonth { get; set; }

		public String Reasonvn { get; set; }

		public DateTime Isdate { get; set; }

		public String Operator { get; set; }

		public DateTime Operationtime { get; set; }

		public String Ip { get; set; }
	}
}
