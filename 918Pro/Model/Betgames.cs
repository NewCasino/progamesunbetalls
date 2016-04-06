using System;
namespace Model
{
	[Serializable]
	public class Betgames
	{

		public Int32 BetGamesID { get; set; }

		public String BetName { get; set; }

		public String Remark { get; set; }

		public Int32 RootId { get; set; }

		public Int32 Sorts { get; set; }
	}
}
