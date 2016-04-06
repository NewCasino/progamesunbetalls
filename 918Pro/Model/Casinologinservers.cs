using System;
namespace Model
{
	[Serializable]
	public class Casinologinservers
	{

		public Int32 Id { get; set; }

		public String Webserverid { get; set; }

		public String Casino { get; set; }

		public String Webserverip { get; set; }

		public String Loginserverip { get; set; }

		public Int32 Status { get; set; }
	}
}
