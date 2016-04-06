using System;
namespace Model
{
	[Serializable]
	public class Updatematches
	{

		public Int32 Id { get; set; }

		public Int32 Type1 { get; set; }

		public String Content { get; set; }

		public DateTime Updatetime { get; set; }
	}
}
