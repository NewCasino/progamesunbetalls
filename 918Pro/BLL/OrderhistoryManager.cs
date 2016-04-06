using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Model;
using DAL;
namespace BLL
{
		///<sumary>
		///业务逻辑类
		///</sumary>
	public class OrderhistoryManager
	{
		private static OrderhistoryService orderhistoryService=new OrderhistoryService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-9-24 21:03:40
		///</sumary>
		public static Orderhistory GetOrderhistoryByPK(object pk) 
		{
			try
			{
				return orderhistoryService.GetOrderhistoryByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-9-24 21:03:40
		///</sumary>
		public static Boolean AddOrderhistory(Orderhistory orderhistory) 
		{
			try
			{
				return orderhistoryService.AddOrderhistory(orderhistory);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-9-24 21:03:40
		///</sumary>
		public static Boolean UpdateOrderhistory(Orderhistory orderhistory) 
		{
			try
			{
				return orderhistoryService.UpdateOrderhistory(orderhistory);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-9-24 21:03:40
		///</sumary>
		public static Boolean DeleteOrderhistoryByPK(object pk) 
		{
			try
			{
				return orderhistoryService.DeleteOrderhistoryByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-9-24 21:03:40
		///</sumary>
		public static DataTable GetMutilDTOrderhistory() 
		{
			try
			{
				return orderhistoryService.GetMutilDTOrderhistory();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-9-24 21:03:40
		///</sumary>
		public static IList<Orderhistory> GetMutilILOrderhistory() 
		{
			try
			{
				return orderhistoryService.GetMutilILOrderhistory();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion

        public static string GetMatchAll(string time1, string time2, string language, string status, string agentName, string roleId)
        {
            return orderhistoryService.GetMatchAll(time1, time2,language, status,agentName,roleId);
        }

        public static string GetMatchAll2(string time1, string time2, string language, string status, string agentName, string roleId, string mtype)
        {
            return orderhistoryService.GetMatchAll2(time1, time2, language, status, agentName, roleId, mtype);
        }

        public static IList<Orderhistory> GetMatchUser(string time, string language, string status, string ID)
        {
            IList<Orderhistory> list = orderhistoryService.GetMatchUser(time, language, status, ID);
             return list;
        }

        public static string GetMatchs(string time1,string time2 ,string language, string status, int roleId, string UpUserName)
        {
            string type = "";
            string uptype = "";
            if (roleId == 3)
            {
                type = "Partner";
                uptype = "SubCompany";
            }
            if (roleId == 4)
            {
                type = "ZAgent";
                uptype = "Partner";
            }
            if (roleId == 5)
            {
                type = "Agent";
                uptype = "ZAgent";
            }
            if (roleId == 6)
            {
                type = "UserName";
                uptype = "Agent";
            }
            string list = orderhistoryService.GetMatchs(time1,time2 ,language, status, type,uptype, UpUserName);
            return list;
        }

        public static string GetMatchs2(string time1, string time2, string language, string status, int roleId, string UpUserName, string mtype)
        {
            string type = "";
            string uptype = "";
            if (roleId == 3)
            {
                type = "Partner";
                uptype = "SubCompany";
            }
            if (roleId == 4)
            {
                type = "ZAgent";
                uptype = "Partner";
            }
            if (roleId == 5)
            {
                type = "Agent";
                uptype = "ZAgent";
            }
            if (roleId == 6)
            {
                type = "UserName";
                uptype = "Agent";
            }
            string list = orderhistoryService.GetMatchs2(time1, time2, language, status, type, uptype, UpUserName, mtype);
            return list;
        }

        public static string GetMatchs2Agent(string time1, string time2, string language, string status, int roleId, string UpUserName, string mtype)
        {
            string type = "";
            string uptype = "";
            if (roleId == 3)
            {
                type = "Partner";
                uptype = "SubCompany";
            }
            if (roleId == 4)
            {
                type = "ZAgent";
                uptype = "Partner";
            }
            if (roleId == 5)
            {
                type = "Agent";
                uptype = "ZAgent";
            }
            if (roleId == 6)
            {
                type = "UserName";
                uptype = "Agent";
            }
            string list = orderhistoryService.GetMatchs2Agent(time1, time2, language, status, type, uptype, UpUserName, mtype);
            return list;
        }

        public static string GetMatchs3(string time1, string time2, string language, string status, int roleId, string UpUserName, string mtype)
        {
            string type = "";
            string uptype = "";
            if (roleId == 3)
            {
                type = "Partner";
                uptype = "SubCompany";
            }
            if (roleId == 4)
            {
                type = "ZAgent";
                uptype = "Partner";
            }
            if (roleId == 5)
            {
                type = "Agent";
                uptype = "ZAgent";
            }
            if (roleId == 6)
            {
                type = "UserName";
                uptype = "Agent";
            }
            string list = orderhistoryService.GetMatchs3(time1, time2, language, status, type, uptype, UpUserName, mtype);
            return list;
        }

        public static string GetUserName(string time1,string time2, string language,string status, string userName)
        {
            return orderhistoryService.GetUserName(time1,time2, language,status,userName);
        }

        public static string GetUserName2(string time1, string time2, string language, string status, string userName, string mtype)
        {
            return orderhistoryService.GetUserName2(time1, time2, language, status, userName, mtype);
        }

        public static string LeagueOrderDetail(string time1, string time2, string language, string status, string gameid, string betType, string agentName, string roleId)
        {
            return orderhistoryService.LeagueOrderDetail(time1, time2, language, status, gameid, betType, agentName, roleId);
        }

        public static string LeagueOrderDetail2(string time1, string time2, string language, string status, string gameid, string betType, string agentName, string roleId, string mtype)
        {
            return orderhistoryService.LeagueOrderDetail2(time1, time2, language, status, gameid, betType, agentName, roleId, mtype);
        }

        public static string GetMatch(string time1,string time2, string language, string status, int roleId)
        {
            string type = "";
            if (roleId == 2)
            {
                type = "SubCompany";
            }
            string list = orderhistoryService.GetMatch(time1, time2, language, status, type);
            return list;
        }

        public static string GetMatch2(string time1, string time2, string language, string status, int roleId, string mtype)
        {
            string type = "";
            if (roleId == 2)
            {
                type = "SubCompany";
            }
            string list = orderhistoryService.GetMatch2(time1, time2, language, status, type, mtype);
            return list;
        }

        public static string GetMatch3(string time1, string time2, string language, string status, int roleId, string mtype)
        {
            string type = "";
            if (roleId == 2)
            {
                type = "SubCompany";
            }
            string list = orderhistoryService.GetMatch3(time1, time2, language, status, type, mtype);
            return list;
        }      
        public static string GetMatch(string time1, string time2, string language, string status, int roleIds, string user)
        {
            string type = "";
            if (roleIds == 2)
            {
                type = "SubCompany";
            }
            if (roleIds == 3)
            {
                type = "Partner";
            }
            if (roleIds == 4)
            {
                type = "ZAgent";
            }
            if (roleIds == 5)
            {
                type = "Agent";
            }
            string list = orderhistoryService.GetMatch(time1, time2, language, status, type,user);
            return list;
        }

        public static string GetStatisticsT(string time1, string time2, string group, int sort, string user, string ip)
        {
            string sorts = "";
            if (sort == 1)
            {
                sorts = "asc";
            }
            if (sort == 0)
            {
                sorts = "desc";
            }
            return orderhistoryService.GetStatisticsT(time1, time2, group, sorts,user,ip);
        }

        public static string GetStatisticsIpT(string time1, string time2, string group, int sort, string user, string ip)
        {
            string sorts = "";
            if (sort == 1)
            {
                sorts = "asc";
            }
            if (sort == 0)
            {
                sorts = "desc";
            }
            return orderhistoryService.GetStatisticsIpT(time1, time2, group, sorts, user, ip);
        }

        public static string GetStatisticsY(string type, int number, string group, int sort,string user,string ip)
        {
            string json = "";
            string sorts = "";
            if (sort == 1)
            {
                sorts = "asc";
            }
            if (sort == 0)
            {
                sorts = "desc";
            }
            int day1=0;
            int day2 = 0;
            string date = null;
            string time = "";
            
            if (type == "wk")
            {

                day1 = number-1;
                day2 = number;
                date = "week";
                time = DateTime.Now.ToString("yyyy") + "-01-01";
               json= orderhistoryService.GetStatistics(day1,day2, date, time,group,sorts,user,ip);
            }
            if (type == "tenUp")
            {
                //day1 = 1;
                day2 = 10;
                date = "day";
                string times = "";
                if (number < 10)
                {
                    times = "0" + number;
                }
                else {
                    times = number.ToString();
                }
                time = DateTime.Now.ToString("yyyy-")+""+times+"-01";
                json= orderhistoryService.GetStatistics(day1,day2, date, time,group,sorts,user,ip);
            }
            if (type == "tenIn")
            {
                day1 = 10;
                day2 = day1 + 10;
                date = "day";
                string times = "";
                if (number < 10)
                {
                    times = "0" + number;
                }
                else
                {
                    times = number.ToString();
                }
                time = DateTime.Now.ToString("yyyy-") + "" + times + "-01";
                json= orderhistoryService.GetStatistics(day1,day2, date, time,group,sorts,user,ip);
            }
            if (type == "tenNext")
            {
                day1 = 20;
                day2 = day1 + 11;
                date = "day";
                string times = "";
                if (number < 10)
                {
                    times = "0" + number;
                }
                else
                {
                    times = number.ToString();
                }
                time = DateTime.Now.ToString("yyyy-") + "" + times + "-01";
                json= orderhistoryService.GetStatistics(day1,day2, date, time,group,sorts,user,ip);
            }

            if (type == "halfUp")
            {
                day1 = 0;
                day2 = day1 + 15;
                date = "day";
                string times = "";
                if (number < 10)
                {
                    times = "0" + number;
                }
                else
                {
                    times = number.ToString();
                }
                time = DateTime.Now.ToString("yyyy-") + "" + times + "-01";
                json= orderhistoryService.GetStatistics(day1,day2, date, time,group,sorts,user,ip);
            }
            if (type == "halfNext")
            {
                day1 = 15;
                day2 = day1 + 16;
                date = "day";
                string times = "";
                if (number < 10)
                {
                    times = "0" + number;
                }
                else
                {
                    times = number.ToString();
                }
                time = DateTime.Now.ToString("yyyy-") + "" + times + "-01";
                json= orderhistoryService.GetStatistics(day1,day2, date, time,group,sorts,user,ip);
            }
            if (type == "allM")
            {
                //day1 = 15;
                day2 = day1 + 31;
                date = "day";
                string times = "";
                if (number < 10)
                {
                    times = "0" + number;
                }
                else
                {
                    times = number.ToString();
                }
                time = DateTime.Now.ToString("yyyy-") + "" + times + "-01";
                json= orderhistoryService.GetStatistics(day1,day2, date, time,group,sorts,user,ip);
            }
            if (type == "oneQuarter")
            {
                if (number == 1)
                {
                    day1 = 0;
                    day2 = 3;
                }
                if (number == 2)
                {
                    day1 = 3;
                    day2 = 6;
                }
                if (number == 3)
                {
                    day1 = 6;
                    day2 = 9;
                }
                if (number == 4)
                {
                    day1 = 9;
                    day2 = 12;
                }
                date = "month";
                time = DateTime.Now.ToString("yyyy") + "-01-01";
                json= orderhistoryService.GetStatistics(day1,day2, date, time,group,sorts,user,ip);
            }
            return json;
        }

        public static string GetStatisticsIpY(string type, int number, string group, int sort, string user, string ip)
        {
            string json = "";
            string sorts = "";
            if (sort == 1)
            {
                sorts = "asc";
            }
            if (sort == 0)
            {
                sorts = "desc";
            }
            int day1 = 0;
            int day2 = 0;
            string date = null;
            string time = "";

            if (type == "wk")
            {

                day1 = number - 1;
                day2 = number;
                date = "week";
                time = DateTime.Now.ToString("yyyy") + "-01-01";
                json = orderhistoryService.GetStatisticsIpY(day1, day2, date, time, group, sorts, user, ip);
            }
            if (type == "tenUp")
            {
                //day1 = 1;
                day2 = 10;
                date = "day";
                string times = "";
                if (number < 10)
                {
                    times = "0" + number;
                }
                else
                {
                    times = number.ToString();
                }
                time = DateTime.Now.ToString("yyyy-") + "" + times + "-01";
                json = orderhistoryService.GetStatisticsIpY(day1, day2, date, time, group, sorts, user, ip);
            }
            if (type == "tenIn")
            {
                day1 = 10;
                day2 = day1 + 10;
                date = "day";
                string times = "";
                if (number < 10)
                {
                    times = "0" + number;
                }
                else
                {
                    times = number.ToString();
                }
                time = DateTime.Now.ToString("yyyy-") + "" + times + "-01";
                json = orderhistoryService.GetStatisticsIpY(day1, day2, date, time, group, sorts, user, ip);
            }
            if (type == "tenNext")
            {
                day1 = 20;
                day2 = day1 + 11;
                date = "day";
                string times = "";
                if (number < 10)
                {
                    times = "0" + number;
                }
                else
                {
                    times = number.ToString();
                }
                time = DateTime.Now.ToString("yyyy-") + "" + times + "-01";
                json = orderhistoryService.GetStatisticsIpY(day1, day2, date, time, group, sorts, user, ip);
            }

            if (type == "halfUp")
            {
                day1 = 0;
                day2 = day1 + 15;
                date = "day";
                string times = "";
                if (number < 10)
                {
                    times = "0" + number;
                }
                else
                {
                    times = number.ToString();
                }
                time = DateTime.Now.ToString("yyyy-") + "" + times + "-01";
                json = orderhistoryService.GetStatisticsIpY(day1, day2, date, time, group, sorts, user, ip);
            }
            if (type == "halfNext")
            {
                day1 = 15;
                day2 = day1 + 16;
                date = "day";
                string times = "";
                if (number < 10)
                {
                    times = "0" + number;
                }
                else
                {
                    times = number.ToString();
                }
                time = DateTime.Now.ToString("yyyy-") + "" + times + "-01";
                json = orderhistoryService.GetStatisticsIpY(day1, day2, date, time, group, sorts, user, ip);
            }
            if (type == "allM")
            {
                //day1 = 15;
                day2 = day1 + 31;
                date = "day";
                string times = "";
                if (number < 10)
                {
                    times = "0" + number;
                }
                else
                {
                    times = number.ToString();
                }
                time = DateTime.Now.ToString("yyyy-") + "" + times + "-01";
                json = orderhistoryService.GetStatisticsIpY(day1, day2, date, time, group, sorts, user, ip);
            }
            if (type == "oneQuarter")
            {
                if (number == 1)
                {
                    day1 = 0;
                    day2 = 3;
                }
                if (number == 2)
                {
                    day1 = 3;
                    day2 = 6;
                }
                if (number == 3)
                {
                    day1 = 6;
                    day2 = 9;
                }
                if (number == 4)
                {
                    day1 = 9;
                    day2 = 12;
                }
                date = "month";
                time = DateTime.Now.ToString("yyyy") + "-01-01";
                json = orderhistoryService.GetStatisticsIpY(day1, day2, date, time, group, sorts, user, ip);
            }
            return json;
        }

        public static string GetMatchAlls(string time1, string time2, string language, string status, int roleId, string user)
        {
            string date="";
            if (roleId==2)
            {
                date = "SubCompany";
            }
            if (roleId == 3)
            {
                date = "Partner";
            }
            if (roleId == 4)
            {
                date = "ZAgent";
            }
            if (roleId == 5)
            {
                date = "Agent";
            }
            return orderhistoryService.GetMatchAlls(time1, time2, language, status, date, user);
        }


        public static string GetMatchResult(string time1, string time2, string language,string league,string home,string away, string status)
        {
            return orderhistoryService.GetMatchResult(time1, time2, language, league, home, away, status);
        }

        public static string GetMatchResults(string time1, string time2, string language, string status, int roleId, string user)
        {
            string date = "";
            if (roleId == 2)
            {
                date = "SubCompany";
            }
            if (roleId == 3)
            {
                date = "Partner";
            }
            if (roleId == 4)
            {
                date = "ZAgent";
            }
            if (roleId == 5)
            {
                date = "Agent";
            }
            return orderhistoryService.GetMatchResults(time1, time2, language, status, date, user);
        }


        public static string StatisticsIp(string Ip, string language)
        {
            return orderhistoryService.StatisticsIp(Ip,language);
        }
        public static string StatisticsIpT(string time1, string time2, string group, int sort, string ip, string language)
        {
            string sorts = "";
            if (sort == 1)
            {
                sorts = "asc";
            }
            if (sort == 0)
            {
                sorts = "desc";
            }
            return orderhistoryService.StatisticsIpT(time1, time2, group, sorts, ip, language);
        }
        public static string StatisticsIpY(string type, int number, string group, int sort,string ip, string language)
        {
            string json = "";
            string sorts = "";
            if (sort == 1)
            {
                sorts = "asc";
            }
            if (sort == 0)
            {
                sorts = "desc";
            }
            int day1 = 0;
            int day2 = 0;
            string date = null;
            string time = "";

            if (type == "wk")
            {

                day1 = number - 1;
                day2 = number;
                date = "week";
                time = DateTime.Now.ToString("yyyy") + "-01-01";
                json = orderhistoryService.StatisticsIpY(day1, day2, date, time, group, sorts, ip, language);
            }
            if (type == "tenUp")
            {
                //day1 = 1;
                day2 = 10;
                date = "day";
                string times = "";
                if (number < 10)
                {
                    times = "0" + number;
                }
                else
                {
                    times = number.ToString();
                }
                time = DateTime.Now.ToString("yyyy-") + "" + times + "-01";
                json = orderhistoryService.StatisticsIpY(day1, day2, date, time, group, sorts, ip, language);
            }
            if (type == "tenIn")
            {
                day1 = 10;
                day2 = day1 + 10;
                date = "day";
                string times = "";
                if (number < 10)
                {
                    times = "0" + number;
                }
                else
                {
                    times = number.ToString();
                }
                time = DateTime.Now.ToString("yyyy-") + "" + times + "-01";
                json = orderhistoryService.StatisticsIpY(day1, day2, date, time, group, sorts, ip, language);
            }
            if (type == "tenNext")
            {
                day1 = 20;
                day2 = day1 + 11;
                date = "day";
                string times = "";
                if (number < 10)
                {
                    times = "0" + number;
                }
                else
                {
                    times = number.ToString();
                }
                time = DateTime.Now.ToString("yyyy-") + "" + times + "-01";
                json = orderhistoryService.StatisticsIpY(day1, day2, date, time, group, sorts, ip, language);
            }

            if (type == "halfUp")
            {
                day1 = 0;
                day2 = day1 + 15;
                date = "day";
                string times = "";
                if (number < 10)
                {
                    times = "0" + number;
                }
                else
                {
                    times = number.ToString();
                }
                time = DateTime.Now.ToString("yyyy-") + "" + times + "-01";
                json = orderhistoryService.StatisticsIpY(day1, day2, date, time, group, sorts, ip, language);
            }
            if (type == "halfNext")
            {
                day1 = 15;
                day2 = day1 + 16;
                date = "day";
                string times = "";
                if (number < 10)
                {
                    times = "0" + number;
                }
                else
                {
                    times = number.ToString();
                }
                time = DateTime.Now.ToString("yyyy-") + "" + times + "-01";
                json = orderhistoryService.StatisticsIpY(day1, day2, date, time, group, sorts, ip, language);
            }
            if (type == "allM")
            {
                //day1 = 15;
                day2 = day1 + 31;
                date = "day";
                string times = "";
                if (number < 10)
                {
                    times = "0" + number;
                }
                else
                {
                    times = number.ToString();
                }
                time = DateTime.Now.ToString("yyyy-") + "" + times + "-01";
                json = orderhistoryService.StatisticsIpY(day1, day2, date, time, group, sorts, ip,language);
            }
            if (type == "oneQuarter")
            {
                if (number == 1)
                {
                    day1 = 0;
                    day2 = 3;
                }
                if (number == 2)
                {
                    day1 = 3;
                    day2 = 6;
                }
                if (number == 3)
                {
                    day1 = 6;
                    day2 = 9;
                }
                if (number == 4)
                {
                    day1 = 9;
                    day2 = 12;
                }
                date = "month";
                time = DateTime.Now.ToString("yyyy") + "-01-01";
                json = orderhistoryService.StatisticsIpY(day1, day2, date, time, group, sorts, ip,language);
            }
            return json;
        }
    }
}
