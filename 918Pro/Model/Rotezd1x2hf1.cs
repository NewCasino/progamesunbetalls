using System;
namespace Model
{
	[Serializable]
	public class Rotezd1x2hf1
	{

		public Int32 Id { get; set; }

		public String Matchid { get; set; }

		public Int32 Gameid { get; set; }

		public String Cindex { get; set; }

		public Decimal Oddshome { get; set; }

		public Decimal Oddsaway { get; set; }

		public Decimal Oddsdraw { get; set; }

		public String Homeid { get; set; }

		public String Awayid { get; set; }

		public String Drawid { get; set; }

		public DateTime Time { get; set; }

		public Int32 State { get; set; }

		public Decimal MaxBet { get; set; }

		public Decimal MinBet { get; set; }

		public Decimal SingleMaxBet { get; set; }

        public Int32 Allowchange { get; set; }
	}
}
