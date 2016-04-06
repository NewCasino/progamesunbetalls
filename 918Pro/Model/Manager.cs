using System;
namespace Model
{
    [Serializable]
    public class Manager
    {

        public Int32 ID { get; set; }

        public String ManagerId { get; set; }

        public String PassWord { get; set; }

        public Int32 RoleId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public String CreateUser { get; set; }

        public String IP { get; set; }

        public Int32 Enable { get; set; }

        public Int32 SubAccount { get; set; }

        public String UpUserName { get; set; }

        public Int32 UpUserID { get; set; }

        public Int32 UpRoleId { get; set; }
    }
}