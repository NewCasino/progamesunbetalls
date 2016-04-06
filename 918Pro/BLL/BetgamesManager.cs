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
	public class BetgamesManager
	{
		private static BetgamesService betgamesService=new BetgamesService();

        public static IList<Betgames> GetNameAndIdByRootId(int rootId)
        {
            try
            {
                return betgamesService.GetNameAndIdByRootId(rootId);
            }
            catch (Exception)
            {

                return null;
            }
        }
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-8-28 22:55:50
		///</sumary>
		public static Betgames GetBetgamesByPK(object pk) 
		{
			try
			{
				return betgamesService.GetBetgamesByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-8-28 22:55:50
		///</sumary>
		public static Boolean AddBetgames(Betgames betgames) 
		{
			try
			{
				return betgamesService.AddBetgames(betgames);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-8-28 22:55:50
		///</sumary>
		public static Boolean UpdateBetgames(Betgames betgames) 
		{
			try
			{
				return betgamesService.UpdateBetgames(betgames);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-8-28 22:55:50
		///</sumary>
		public static Boolean DeleteBetgamesByPK(object pk) 
		{
			try
			{
				return betgamesService.DeleteBetgamesByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-8-28 22:55:50
		///</sumary>
		public static DataTable GetMutilDTBetgames() 
		{
			try
			{
				return betgamesService.GetMutilDTBetgames();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-8-28 22:55:50
		///</sumary>
		public static IList<Betgames> GetMutilILBetgames() 
		{
			try
			{
				return betgamesService.GetMutilILBetgames();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion
	}
}
