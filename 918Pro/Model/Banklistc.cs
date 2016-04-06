using System;
namespace Model
{
	[Serializable]
	public class Banklistc
	{

		public Int32 ID { get; set; }

		public String Currency { get; set; }

        public String Namecn { get; set; }

        public String Nametw { get; set; }

        public String Nameen { get; set; }

        public String Nameth { get; set; }
        
		public String Cardno { get; set; }

		public String Bank { get; set; }

		public String Province { get; set; }

		public String City { get; set; }

		public String Branch { get; set; }

		public String Status { get; set; }

		public String Operator { get; set; }

		public DateTime Operationtime { get; set; }

		public String Ip { get; set; }

        public Decimal amount { get; set; }
	}
}
