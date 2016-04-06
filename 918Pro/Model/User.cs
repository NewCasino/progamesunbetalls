using System;
namespace Model
{
	[Serializable]
	public class User
	{

		public Int32 ID { get; set; }

		public String UserName { get; set; }

		public String Password { get; set; }

        public string TCpassword { get; set; }

		public Decimal Balance { get; set; }

		public String Name { get; set; }

		public String Mobile { get; set; }

		public String Currency { get; set; }

		public String Email { get; set; }

		public String Tel { get; set; }

		public Int32 Status { get; set; }

		public Decimal CompanyPercent { get; set; }

		public Decimal CompanyCommission { get; set; }

		public String SubCompany { get; set; }

		public Decimal SubCompanyPercent { get; set; }

		public Decimal SubCompanyCommission { get; set; }

		public String Partner { get; set; }

		public Decimal PartnerPercent { get; set; }

		public Decimal PartnerCommission { get; set; }

		public String GeneralAgent { get; set; }

		public Decimal GeneralAgentPercent { get; set; }

		public Decimal GeneralAgentCommission { get; set; }

		public String Agent { get; set; }

		public Decimal AgentPercent { get; set; }

		public Decimal AgentCommission { get; set; }

		public Decimal Percent { get; set; }

		public Decimal Commission { get; set; }

		public Decimal Credit { get; set; }

		public Int32 IsReport { get; set; }

		public Int32 MaxUser { get; set; }

		public String Plate { get; set; }

		public Int32 RoleId { get; set; }

		public Int32 SubAccount { get; set; }

		public DateTime RegistrationTime { get; set; }

		public DateTime LastLoginTime { get; set; }

		public String LastLoginIP { get; set; }

		public String UpUserName { get; set; }

		public Int32 UpUserID { get; set; }

		public Int32 UpRoleId { get; set; }

		public Decimal ItemMin { get; set; }

		public Decimal ItemMax { get; set; }

		public Decimal ItemsMax { get; set; }

		public String UserLevel { get; set; }

		public Decimal Coefficient { get; set; }

		public Decimal Proportion { get; set; }

		public String Group { get; set; }

		public String Key { get; set; }

		public String ResetCredit { get; set; }

		public String LastName { get; set; }

		public String FirstName { get; set; }

		public String Sex { get; set; }

		public DateTime Birthday { get; set; }

		public String Country { get; set; }

		public String Addr { get; set; }

		public String City { get; set; }

		public String Province { get; set; }

		public String Post { get; set; }

		public String LoginName { get; set; }

		public String Question { get; set; }

		public String Answer { get; set; }

		public String Know { get; set; }

		public String MoneyType { get; set; }

        public String fstatus { get; set; }

        public int qkcs { get; set; }

        public DateTime soucunsj { get; set; }

        public String registerIP { get; set; }

        public String cunkuanfs { get; set; }

        public Decimal cunkuan { get; set; }

        public Decimal qukuan { get; set; }

        public Decimal hongli { get; set; }

        public Decimal fanshui { get; set; }

        public String nicheng { get; set; }

        public String regip { get; set; }

        public string Demo { get; set; }
        public Decimal ValidAmount { get; set; }
        public string post { get;set;}
        public string mark { get; set; }
        public Decimal Wincoins { get; set; }
        public string WincoinInfo { get; set; }
        public string parentcode { get; set; }
        public string bankName { get; set; }
        public string bankUserName { get; set; }

        public string bankCard { get; set; }
       

	}
}
