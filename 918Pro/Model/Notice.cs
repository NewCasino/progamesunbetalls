using System;
namespace Model
{
	[Serializable]
	public class Notice
	{

		public Int32 ID { get; set; }

		public String Msgcn { get; set; }

		public String Msgtw { get; set; }

		public String Msgen { get; set; }

		public String Msgth { get; set; }

		public String Msgvn { get; set; }

		public String Displayuser { get; set; }

		public String Windowagent { get; set; }

		public String Windowuser { get; set; }

		public DateTime Createdate { get; set; }

		public String Createuser { get; set; }

		public String Displayagent { get; set; }
	}
}
