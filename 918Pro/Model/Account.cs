using System;
namespace Model
{
    [Serializable]
    public class Account
    {

        public Int32 Id { get; set; }

        public String Userid { get; set; }

        public Int32 Casino { get; set; }

        public String Password { get; set; }

        public Int32 Group1 { get; set; }

        public String Address { get; set; }

        public String Address2 { get; set; }

        public String Cookie { get; set; }

        public String loginname { get; set; }

        public DateTime Time { get; set; }

        public Int32 Isquzhi { get; set; }

        public Int32 Enable { get; set; }

        public String Operat { get; set; }

        public String Operatortime { get; set; }

        public String Operatorip { get; set; }
    }
}