using System;
namespace Model
{
	[Serializable]
	public class Agentservers
	{

		public String Ip { get; set; }

		public Int32 Port { get; set; }

		public Int32 Enable { get; set; }

		public Int32 Id { get; set; }
	}
}
