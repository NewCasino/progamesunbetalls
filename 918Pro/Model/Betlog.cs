using System;
namespace Model
{
	[Serializable]
	public class Betlog
	{

		public Int32 Id { get; set; }

		public String Userid { get; set; }

		public DateTime Time { get; set; }

		public Int32 T1 { get; set; }

		public Int32 T2 { get; set; }

		public Int32 T3 { get; set; }

		public Int32 T4 { get; set; }

		public Int32 T5 { get; set; }

		public Int32 T6 { get; set; }

		public Int32 T7 { get; set; }

		public String Casino { get; set; }

		public String Gametype { get; set; }
	}
}
