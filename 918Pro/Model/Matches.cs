using System;
namespace Model
{
	[Serializable]
	public class Matches
	{

		public Int32 Id { get; set; }

		public Int32 Number { get; set; }

		public String Matchid { get; set; }

		public String Leaguecn { get; set; }

		public String Leaguetw { get; set; }

		public String Leagueen { get; set; }

		public String Leagueth { get; set; }

		public String Leaguevn { get; set; }

		public String League1 { get; set; }

		public String Color { get; set; }

        public String Time { get; set; }

		public DateTime Begintime { get; set; }

		public String Homecn { get; set; }

		public String Hometw { get; set; }

		public String Homeen { get; set; }

		public String Hometh { get; set; }

		public String Homevn { get; set; }

		public String Home1 { get; set; }

		public String Awaycn { get; set; }

		public String Awaytw { get; set; }

		public String Awayen { get; set; }

		public String Awayth { get; set; }

		public String Awayvn { get; set; }

		public String Away1 { get; set; }

        public Int32 Running { get; set; }

		public String Score { get; set; }

		public String Redcard { get; set; }

        public Int32 Danger { get; set; }

		public String Dotime { get; set; }

		public Int32 Isstart { get; set; }

        public Int32 State { get; set; }

        public Int32 Display { get; set; }

		public String Resulthomescore { get; set; }

		public String Resultawayscore { get; set; }

		public String Halfhomescore { get; set; }

		public String Halfawayscore { get; set; }

		public DateTime Updatetime { get; set; }

        public Int32 Type { get; set; }

        public Int32 Casino { get; set; }

        public String Reason { get; set; }

        public DateTime Scoreinputtime { get; set; }

        public String Scoreinputuser { get; set; }

        public String Resulthomescore2 { get; set; }

        public String Resultawayscore2 { get; set; }

        public String Halfhomescore2 { get; set; }

        public String Halfawayscore2 { get; set; }

	}
}
