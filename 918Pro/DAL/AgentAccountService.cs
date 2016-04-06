using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;

namespace DAL
{
    public class AgentAccountService
    {
        private const string SQL_SELECTALL = "select ID,Name,AgentName,Password,casino,cookie,Address,Address2,isEnable,isLogin,operator,operationTime,status,ip from agentaccount";
        private const string SQL_INSERT = "insert into agentaccount(Name,AgentName,Password,casino,cookie,Address,Address2,isEnable,isLogin,operator,operationTime,ip) values(?Name,?AgentName,?Password,?Casino,?Cookie,?Address,?Address2,?IsEnable,?IsLogin,?Operator,?OperationTime,?IP)";
        private const string SQL_UPDATE = "update agentaccount set Name=?Name,AgentName=?AgentName,Password=?Password,casino=?Casino,cookie=?Cookie,Address=?Address,Address2=?Address2,isEnable=?IsEnable,isLogin=?IsLogin,operator=?Operator,operationTime=?OperationTime,ip=?IP where ID=?ID";
        private const string SQL_DELETE = "delete from agentaccount where ID=?ID";
        private const string SQL_SELECTBYCASINO = "select Name,AgentName,Password,casino,cookie,Address,Address2 from agentaccount where isEnable = 1 and casino=?Casino";

        public bool Insert(AgentAccount agentAcc)
        {
            MySqlParameter[] parm = new MySqlParameter[] {
                new MySqlParameter("?Name",agentAcc.Name),
                new MySqlParameter("?AgentName",agentAcc.AgentName),
                new MySqlParameter("?Password",agentAcc.Password),
                new MySqlParameter("?Casino",agentAcc.Casino),
                new MySqlParameter("?Cookie",agentAcc.Cookie),
                new MySqlParameter("?Address",agentAcc.Address),
                new MySqlParameter("?Address2",agentAcc.Address2),
                new MySqlParameter("?IsEnable",agentAcc.IsEnable),
                new MySqlParameter("?IsLogin",agentAcc.IsLogin),
                new MySqlParameter("?Operator",agentAcc.Operator),
                new MySqlParameter("?OperationTime",agentAcc.OperationTime),
                new MySqlParameter("?IP",agentAcc.IP)
            };
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, parm) > 0;
        }

        public bool Update(AgentAccount agentAcc)
        {
            MySqlParameter[] parm = new MySqlParameter[] {
                new MySqlParameter("?Name",agentAcc.Name),
                new MySqlParameter("?AgentName",agentAcc.AgentName),
                new MySqlParameter("?Password",agentAcc.Password),
                new MySqlParameter("?Casino",agentAcc.Casino),
                new MySqlParameter("?Cookie",agentAcc.Cookie),
                new MySqlParameter("?Address",agentAcc.Address),
                new MySqlParameter("?Address2",agentAcc.Address2),
                new MySqlParameter("?IsEnable",agentAcc.IsEnable),
                new MySqlParameter("?IsLogin",agentAcc.IsLogin),
                new MySqlParameter("?Operator",agentAcc.Operator),
                new MySqlParameter("?OperationTime",agentAcc.OperationTime),
                new MySqlParameter("?IP",agentAcc.IP),
                new MySqlParameter("?ID",agentAcc.ID)
            };
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, parm) > 0;            
        }

        public string SelectAll()
        {
            string json = string.Empty;
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECTALL)) {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "[]" ? "" : json;
        }

        public string SelectByWhere(string name, string casino, string isEnable)
        {
            string json = string.Empty;
            string SQL_SELECT = "select select ID,Name,AgentName,Password,casino,cookie,Address,Address2,isEnable,isLogin,operator,operationTime,status,ip from agentaccount where 1=1";
            if (name != "") {
                SQL_SELECT += " and Name like %'"+name+"'%";
            }
            if (casino != "") {
                SQL_SELECT += " and casino='"+casino+"'";
            }
            if (isEnable != "") {
                SQL_SELECT += " and isEnable='"+isEnable+"'";
            }
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "[]" ? "" : json;
        }

        public bool Delete(string id)
        {
            MySqlParameter[] parm = new MySqlParameter[] {
                new MySqlParameter("?ID",id)
            };
            return MySqlHelper.ExecuteNonQuery(SQL_DELETE, parm) > 0;
        }

        public string getCount(string casino, string time1, string time2, string enable)
        {
            string str = "select count(*) from agentaccount where 1=1";
            if (casino != "0")
            {
                str += " and casino=" + casino.Replace("'", "") + "";
            }
            if (time1 != "" || time2 != "")
            {
                time1 = time1 == "" ? time2 : time1;
                time2 = time2 == "" ? time1 : time2;
                str += " and date(operationTime)>=date('" + DateTime.Parse(time1) + "')";
                str += " and date(operationTime)<=date('" + DateTime.Parse(time2) + "')";
            }
            if (enable != "-1")
            {
                str += " and isEnable=" + enable + "";
            }
            return MySqlHelper.ExecuteScalar(str).ToString();
        }

        public string getInfo(string username)
        {
            string str = "select count(*) from agentaccount where Name=?username";
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?username",username)
            };
            return MySqlHelper.ExecuteScalar(str, param).ToString();
        }

        public string getDataAll(int IDex, int IDexC, string casino,string time1, string time2, string enable)
        {
            string json = string.Empty;
            string str = SQL_SELECTALL+" where 1=1";
            if (casino != "0")
            {
                str += " and casino=" + casino.Replace("'", "") + "";
            }
            if (time1 != "" || time2 != "")
            {
                time1 = time1 == "" ? time2 : time1;
                time2 = time2 == "" ? time1 : time2;
                str += " and date(operationTime)>=date('" + DateTime.Parse(time1) + "')";
                str += " and date(operationTime)<=date('" + DateTime.Parse(time2) + "')";
            }
            if (enable != "-1")
            {
                str += " and isEnable=" + enable + "";
            }
            json = ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str + " limit " + IDex + "," + IDexC));
            return json == "[]" ? "" : json;
        }

        public IList<AgentAccount> SelectByCasino(string casino)
        {
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?Casino",casino)
            };
            return MySqlModelHelper<AgentAccount>.GetObjectsBySql(SQL_SELECTBYCASINO, parm);
        }
    }
}
