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
	public class GradeManager
	{
		private static GradeService gradeService=new GradeService();

        /// <summary>
        /// 获取系统默认的会员等级
        /// </summary>
        /// <returns></returns>
        public Grade GetDefaultGrade()
        {
            return gradeService.GetDefaultGrade();
        }

        public bool IsExistGrade(string levelName,string lan)
        {
            Grade grade = gradeService.IsExistGrade(levelName,lan);
            if (grade == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-10-20 21:48:09
		///</sumary>
		public static Grade GetGradeByPK(object pk) 
		{
			try
			{
				return gradeService.GetGradeByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-10-20 21:48:09
		///</sumary>
		public static Boolean AddGrade(Grade grade,string lan) 
		{
			try
			{
				return gradeService.AddGrade(grade,lan);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-10-20 21:48:09
		///</sumary>
		public static Boolean UpdateGrade(Grade grade,string lan) 
		{
			try
			{
				return gradeService.UpdateGrade(grade,lan);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-10-20 21:48:09
		///</sumary>
		public static Boolean DeleteGradeByPK(object pk) 
		{
			try
			{
				return gradeService.DeleteGradeByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-10-20 21:48:09
		///</sumary>
		public static DataTable GetMutilDTGrade() 
		{
			try
			{
				return gradeService.GetMutilDTGrade();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-10-20 21:48:09
		///</sumary>
		public static IList<Grade> GetMutilILGrade() 
		{
			try
			{
				return gradeService.GetMutilILGrade();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion

        #region 编写人:李毅
        public static string getJson(string lan)
        {
            return gradeService.getJson(lan);
        }

        /// <summary>
        /// 修改方法
        /// </summary>
        /// <param name="n">等级名称</param>
        /// <param name="r">等级描述</param>
        /// <param name="i">等级ID</param>
        /// <returns></returns>
        public static string Update(string n, string r, string i,string lan)
        {
            return gradeService.Update(n, r, i,lan);
        }
        #endregion

        public static string GetGrade(string lan)
        {
           return ObjectToJson.ReaderToJson(gradeService.GetGrade(lan));
        }

        public static string GetGradeName(int id,string lan)
        {
            return ObjectToJson.ReaderToJson(gradeService.GetGradeName(id,lan));
        }

        public static string GetGradeId(string name,string lan)
        {
            return ObjectToJson.ReaderToJson(gradeService.GetGradeId(name,lan));
        }
        /// <summary>
        /// 根据多语言返回json数据
        /// </summary>
        /// <param name="lan">多语言</param>
        /// <returns></returns>
        public string GetGradeByLan(string lan)
        {
            return gradeService.GetGradeByLan(lan);
        }

    }
}
