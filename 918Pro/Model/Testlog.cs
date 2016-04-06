using System;
namespace Model
{
	[Serializable]
	public class Testlog
	{

		public Int32 Id { get; set; }

		public String Userid { get; set; }

		public DateTime Begintime { get; set; }

		public DateTime Endtime { get; set; }

		public Int32 Lengths { get; set; }

		public Int32 Times { get; set; }
	}
}
