using System;
namespace Model
{
	[Serializable]
	public class Orderdetailouhfl
	{

		public Int32 ID { get; set; }

		public String UserName { get; set; }

		public String OrderID { get; set; }

		public DateTime Time { get; set; }

		public String Leaguecn { get; set; }

		public String Leaguetw { get; set; }

		public String Leagueen { get; set; }

		public String Leagueth { get; set; }

		public String Leaguevn { get; set; }

		public String Homecn { get; set; }

		public String Hometw { get; set; }

		public String Homeen { get; set; }

		public String Hometh { get; set; }

		public String Homevn { get; set; }

		public String Awaycn { get; set; }

		public String Awaytw { get; set; }

		public String Awayen { get; set; }

		public String Awayth { get; set; }

		public String Awayvn { get; set; }

		public DateTime BeginTime { get; set; }

		public String BetType { get; set; }

		public String IsHalf { get; set; }

		public String BetItem { get; set; }

		public String Score { get; set; }

		public String Handicap { get; set; }

		public Decimal Odds { get; set; }

		public String OddsType { get; set; }

		public Decimal Amount { get; set; }

		public Decimal ValidAmount { get; set; }

		public String Status { get; set; }

		public String Agent { get; set; }

		public Decimal AgentPercent { get; set; }

		public Decimal AgentCommission { get; set; }

		public Decimal ZAgentPercent { get; set; }

		public String ZAgent { get; set; }

		public Decimal ZAgentCommission { get; set; }

		public Decimal PartnerPercent { get; set; }

		public Decimal PartnerCommission { get; set; }

		public String Partner { get; set; }

		public Decimal CompanyPercent { get; set; }

		public Decimal CompanyCommission { get; set; }

		public String IP { get; set; }

		public String SubCompany { get; set; }

		public Decimal SubCompanyCommission { get; set; }

		public Decimal SubCompanyPercent { get; set; }

		public Int32 WebSiteiID { get; set; }

		public String UserLevel { get; set; }

		public Decimal Coefficient { get; set; }

		public Decimal Proportion { get; set; }

		public String Currency { get; set; }

		public String Reason { get; set; }

		public Int32 Gameid { get; set; }
        public String Betflag { get; set; }

        public Decimal MemberCommission { get; set; }

        public Decimal MemberPercent { get; set; }

        public Decimal Rate { get; set; }
	}
}
