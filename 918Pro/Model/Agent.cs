using System;
namespace Model
{
    [Serializable]
    public class Agent
    {

        public Int32 ID { get; set; }

        public String UserName { get; set; }

        public String Password { get; set; }

        public String Name { get; set; }

        public String Mobile { get; set; }

        public String Email { get; set; }

        public String Tel { get; set; }

        public Int32 Status { get; set; }

        public String SubCompany { get; set; }

        public Int32 SCnumber { get; set; }

        public String Partner { get; set; }

        public Int32 Pnumber { get; set; }

        public String GeneralAgent { get; set; }

        public Int32 Ganumber { get; set; }

        public String Agents { get; set; }

        public Int32 Agentsnumber { get; set; }

        public Int32 MaxUser { get; set; }

        public Int32 RoleId { get; set; }

        public String SubAccount { get; set; }

        public String UpUserName { get; set; }

        public Int32 UpUserID { get; set; }

        public Int32 UpRoleId { get; set; }

        public DateTime RegistrationTime { get; set; }

        public DateTime LastLoginTime { get; set; }

        public String LastLoginIP { get; set; }

        public Decimal ItemMin { get; set; }

        public Decimal ItemMax { get; set; }

        public Decimal ItemsMax { get; set; }

        public String UserLevel { get; set; }

        public Decimal Coefficient { get; set; }

        public Decimal Proportion { get; set; }

        public String Area { get; set; }

        public Double Percent { get; set; }

        public Decimal Credit { get; set; }

        public Decimal CommissionA { get; set; }

        public Decimal CommissionB { get; set; }

        public Decimal CommissionC { get; set; }

        public String UpRoleName { get; set; }

        public String RoleName { get; set; }

        public Decimal UserCredit { get; set; }

        public Decimal Balance { get; set; }

        public String ResetCredit { get; set; }

        public Int32 AgentID { get; set; }

        public String AgentUserName { get; set; }

        public String AgentRoleName { get; set; }

        public Int32 AgentRoleID { get; set; }

        public String MoneyType { get; set; }

        public String Currency { get; set; }

        public String ParentCode { get; set; }

        public Decimal Amount { get; set; }
    }
}
