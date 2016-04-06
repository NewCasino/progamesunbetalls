using System;
namespace Model
{
	[Serializable]
	public class Loginservers
	{

		public Int32 Id { get; set; }

		public String Name { get; set; }

		public String Ip { get; set; }

		public Int32 Status { get; set; }

		public String Webserverip { get; set; }

		public String Sessionid { get; set; }
	}
}
