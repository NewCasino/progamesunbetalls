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
	public class MatchesManager
	{
		private static MatchesService matchesService=new MatchesService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-9-17 20:45:48
		///</sumary>
		public static Matches GetMatchesByPK(object pk) 
		{
			try
			{
				return matchesService.GetMatchesByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-9-17 20:45:48
		///</sumary>
		public static Boolean AddMatches(Matches matches) 
		{
			try
			{
				return matchesService.AddMatches(matches);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-9-17 20:45:48
		///</sumary>
		public static Boolean UpdateMatches(Matches matches) 
		{
			try
			{
				return matchesService.UpdateMatches(matches);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-9-17 20:45:48
		///</sumary>
		public static Boolean DeleteMatchesByPK(object pk) 
		{
			try
			{
				return matchesService.DeleteMatchesByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-9-17 20:45:48
		///</sumary>
		public static DataTable GetMutilDTMatches() 
		{
			try
			{
				return matchesService.GetMutilDTMatches();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-9-17 20:45:48
		///</sumary>
		public static IList<Matches> GetMutilILMatches() 
		{
			try
			{
				return matchesService.GetMutilILMatches();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion
        #region 编写人:李毅
        ///<summary>		
        ///根据ID获得所有数据，返回泛型集合		
        ///生成时间：2010-9-17 21:43:00		
        ///</summary>		
        public static IList<Matches> GetMutilILMatches(int id)
        {
            return matchesService.GetMutilILMatches(id);
        }
        /// <summary>
        /// 查询所有数据并根据number排序
        /// </summary>
        /// <returns></returns>
        public static string GetAllToJson1(string language)
        {
            return matchesService.GetAllToJson1(language);
        }
        public static string GetAllToJson2(string language,string first,string end)
        {
            return matchesService.GetAllToJson2(language,first,end);
        }
        public static string GetAllToJson3(string language)
        {
            return matchesService.GetAllToJson3(language);
        }
        public static string GetAllToJson4(string language,string time)
        {
            return matchesService.GetAllToJson4(language,time);
        }

        public static string GetLeagueByWhere(string language, string league, string home, string away, string beginTime, string endTime)
        {
            return matchesService.GetLeagueByWhere(language,league,home,away,beginTime,endTime);
        }

        public static string GetCount()
        {
            return matchesService.GetCount();
        }
        public static Boolean updatescore(string id, string home, string away, string halfhome, string halfaway, string scoreinputuser)
        {
            return matchesService.updatescore(id, home, away, halfhome, halfaway, DateTime.Now, scoreinputuser);
        }

        public static Boolean updateInfo(string id, string time, string leaguecolor, string leaguetype, string display, string running, string score,
            string redcard, string danger, string number)
        {
            return matchesService.updateInfo(id, time, leaguecolor, leaguetype, display, running, score, redcard, danger, number);
        }

        /// <summary>
        /// 查询联赛信息
        /// </summary>
        /// <returns></returns>
        public static string GetLeagueToJson(string language)
        {
            return matchesService.GetLeagueToJson(language);
        }

        /// <summary>
        /// 查询对战球队信息
        /// </summary>
        /// <returns></returns>
        public static string GetBollToJson(string language)
        {
            return matchesService.GetBollToJson(language);
        }

        /// <summary>
        /// 查询对战球队信息
        /// </summary>
        /// <returns></returns>
        public static string GetBollToJson1(string language)
        {
            return matchesService.GetBollToJson1(language);
        }
        #endregion

        public static string GetUserLevel(string language)
        {
            return matchesService.GetUserLevel(language);
        }
	}

}
