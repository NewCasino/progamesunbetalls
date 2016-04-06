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
	public class OrderdetailouManager
	{
		private static OrderdetailouService orderdetailouService=new OrderdetailouService(); 

        /// <summary>
        /// 即时监控（亚洲盘及大小盘）
        /// </summary>
        /// <param name="language">语言</param>
        /// <param name="league">联赛</param>
        /// <param name="gameId">队伍</param>
        /// <param name="agentUserName">代理用户名</param>
        /// <param name="role">角色ID</param>
        /// <param name="limi">取记录数</param>
        /// <param name="btype">类型 all:全部，hf:半场，fl:全场</param>
        /// <returns></returns>
        public string GetHdpAndOu(string language, string league, string gameId, string agentUserName, string role, string limi, string btype)
        {
            return orderdetailouService.GetHdpAndOu(language, league, gameId, agentUserName, role, limi, btype);
        }

        public string GetHdpAndOu2(string language, string league, string gameId, string agentUserName, string role, string limi, string btype, string mtype)
        {
            return orderdetailouService.GetHdpAndOu2(language, league, gameId, agentUserName, role, limi, btype, mtype);
        }

        /// <summary>
        /// 即时监控（1x2）
        /// </summary>
        /// <param name="language">语言</param>
        /// <param name="league">联赛</param>
        /// <param name="gameId">队伍</param>
        /// <param name="agentUserName">代理用户名</param>
        /// <param name="role">角色ID</param>
        /// <param name="limi">取记录数</param>
        /// <returns></returns>
        public string Get1x2(string language, string league, string gameId, string agentUserName, string role, string limi)
        {
            return orderdetailouService.Get1x2(language, league, gameId, agentUserName, role, limi);
        }

        public string Get1x22(string language, string league, string gameId, string agentUserName, string role, string limi, string mtype)
        {
            return orderdetailouService.Get1x22(language, league, gameId, agentUserName, role, limi, mtype);
        }

        /// <summary>
        /// 会员注单
        /// </summary>
        /// <param name="userName">上级代理帐号</param>
        /// <param name="roleId">当前角色ID</param>
        /// <returns></returns>
        public string GetUserOrder(string userName, string roleId)
        {
            return orderdetailouService.GetUserOrder(userName, roleId);
        }

		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-9-24 21:01:20
		///</sumary>
		public static Orderdetailou GetOrderdetailouByPK(object pk) 
		{
			try
			{
				return orderdetailouService.GetOrderdetailouByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-9-24 21:01:20
		///</sumary>
		public static Boolean AddOrderdetailou(Orderdetailou orderdetailou) 
		{
			try
			{
				return orderdetailouService.AddOrderdetailou(orderdetailou);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-9-24 21:01:20
		///</sumary>
		public static Boolean UpdateOrderdetailou(Orderdetailou orderdetailou) 
		{
			try
			{
				return orderdetailouService.UpdateOrderdetailou(orderdetailou);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-9-24 21:01:20
		///</sumary>
		public static Boolean DeleteOrderdetailouByPK(object pk) 
		{
			try
			{
				return orderdetailouService.DeleteOrderdetailouByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-9-24 21:01:20
		///</sumary>
		public static DataTable GetMutilDTOrderdetailou() 
		{
			try
			{
				return orderdetailouService.GetMutilDTOrderdetailou();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-9-24 21:01:20
		///</sumary>
		public static IList<Orderdetailou> GetMutilILOrderdetailou() 
		{
			try
			{
				return orderdetailouService.GetMutilILOrderdetailou();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion

        #region 编写人:李毅
        /// <summary>
        /// 根据联赛名称，比赛ID，当前语言查询
        /// </summary>
        /// <param name="league">联赛名称</param>
        /// <param name="game">比赛ID</param>
        /// <param name="language">语言</param>
        /// <returns></returns>
        public static string GetAllToJson(string league, string game, string language,string username,string roid)
        {
            return orderdetailouService.GetAllToJson(league, game, language,username,roid);
        }

        /// <summary>
        /// 根据表名,比赛ID以及下注类型查询注单
        /// </summary>
        /// <param name="table1">表1名</param>
        /// <param name="table2">表2名</param>
        /// <param name="type">下注类型(H:主队,A:客队,O:大,U:小,X:标准)</param>
        /// <param name="game">比赛ID</param>
        /// <returns></returns>
        public static string GetDataByType(string table1, string table2, string type, string game, string username, string roid)
        {
            return orderdetailouService.GetDataByType(table1, table2, type, game, username, roid);
        }

        /// <summary>
        /// 根据表名,比赛ID以及下注类型查询注单
        /// </summary>
        /// <param name="table1">表1名</param>
        /// <param name="table2">表2名</param>
        /// <param name="type">下注类型(H:主队,A:客队,O:大,U:小,X:标准)</param>
        /// <param name="game">比赛ID</param>
        /// <returns></returns>
        public static string GetDataByType(string table1, string table2, string game)
        {
            return orderdetailouService.GetDataByType(table1, table2, game);
        }

        /// <summary>
        /// 标准盘信息
        /// </summary>
        /// <param name="league"></param>
        /// <param name="game"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public static string GetData1x2(string league, string game, string language,string username,string roid)
        {
            return orderdetailouService.GetData1x2(league, game, language, username, roid);
        }
        #endregion
	}
}
