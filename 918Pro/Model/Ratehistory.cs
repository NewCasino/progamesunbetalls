using System;
namespace Model
{
	[Serializable]
	public class Ratehistory
	{

		public Int32 Id { get; set; }

		public String Name_cn { get; set; }

		public String Name_tw { get; set; }

		public String Name_en { get; set; }

		public String Name_th { get; set; }

		public String Name_vn { get; set; }

		public Decimal Rate { get; set; }

		public DateTime Lasttime { get; set; }

		public String Operator { get; set; }

		public String Ip { get; set; }
	}
}
