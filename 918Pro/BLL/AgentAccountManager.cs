using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class AgentAccountManager
    {
        public static AgentAccountService agentAccService = new AgentAccountService();

        public static bool Insert(AgentAccount agentAcc)
        {
            return agentAccService.Insert(agentAcc);
        }

        public static bool Update(AgentAccount agentAcc)
        {
            return agentAccService.Update(agentAcc);
        }

        public static string SelectAll()
        {
            return agentAccService.SelectAll();
        }

        public static string SelectByWhere(string name, string casino, string isEnable)
        {
            return agentAccService.SelectByWhere(name,casino,isEnable);
        }

        public static bool Delete(string id)
        {
            return agentAccService.Delete(id);
        }

        public static string getCount(string casino, string time1, string time2, string enable)
        {
            return agentAccService.getCount(casino, time1, time2, enable);
        }

        public static string getInfo(string username)
        {
            return agentAccService.getInfo(username);
        }

        public static string getDataAll(int IDex, int IDexC, string casino, string time1, string time2, string enable)
        {
            return agentAccService.getDataAll(IDex, IDexC, casino, time1, time2, enable);
        }
    }
}
