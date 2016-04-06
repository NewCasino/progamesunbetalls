using System;
namespace Model
{
	[Serializable]
	public class Role
	{

		public Int32 Id { get; set; }

		public String RoleName { get; set; }

		public String Remark { get; set; }

		public String Status { get; set; }

		public Int32 RootId { get; set; }

		public String CreateUser { get; set; }

		public DateTime CreateDate { get; set; }

		public String IP { get; set; }

		public String AgentId { get; set; }
	}
}
