using System;
namespace Model
{
	[Serializable]
	public class Rotedshdphf1
	{

		public Int32 Id { get; set; }

        public Int32 Allowchange { get; set; }

		public String Matchid { get; set; }

		public Int32 Gameid { get; set; }

		public Int32 Flag { get; set; }

		public String Cindex { get; set; }

		public String Favourite { get; set; }

		public String Handicap { get; set; }

		public Decimal Homeodds { get; set; }

		public Decimal Awayodds { get; set; }

		public String Homeid { get; set; }

		public String Awayid { get; set; }

		public DateTime Time { get; set; }

		public Int32 State { get; set; }

		public Decimal MaxBet { get; set; }

		public Decimal MinBet { get; set; }

		public Decimal SingleMaxBet { get; set; }
	}
}
