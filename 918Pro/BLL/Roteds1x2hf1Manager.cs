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
	public class Roteds1x2hf1Manager
	{
		private static Roteds1x2hf1Service roteds1x2hf1Service=new Roteds1x2hf1Service(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-11-2 10:27:09
		///</sumary>
		public static Roteds1x2hf1 GetRoteds1x2hf1ByPK(object pk) 
		{
			try
			{
				return roteds1x2hf1Service.GetRoteds1x2hf1ByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-11-2 10:27:09
		///</sumary>
		public static Boolean AddRoteds1x2hf1(Roteds1x2hf1 roteds1x2hf1) 
		{
			try
			{
				return roteds1x2hf1Service.AddRoteds1x2hf1(roteds1x2hf1);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-11-2 10:27:09
		///</sumary>
		public static Boolean UpdateRoteds1x2hf1(Roteds1x2hf1 roteds1x2hf1) 
		{
			try
			{
				return roteds1x2hf1Service.UpdateRoteds1x2hf1(roteds1x2hf1);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-11-2 10:27:09
		///</sumary>
		public static Boolean DeleteRoteds1x2hf1ByPK(object pk) 
		{
			try
			{
				return roteds1x2hf1Service.DeleteRoteds1x2hf1ByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-11-2 10:27:09
		///</sumary>
		public static DataTable GetMutilDTRoteds1x2hf1() 
		{
			try
			{
				return roteds1x2hf1Service.GetMutilDTRoteds1x2hf1();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-11-2 10:27:09
		///</sumary>
		public static IList<Roteds1x2hf1> GetMutilILRoteds1x2hf1() 
		{
			try
			{
				return roteds1x2hf1Service.GetMutilILRoteds1x2hf1();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion

        #region 编写人:李毅
        public static string updateAll(string a, string l, string s)
        {
            return roteds1x2hf1Service.updateAll(a, l, s);
        }

        public static string updateOne(string i, string l, string t, string s)
        {
            return roteds1x2hf1Service.updateOne(i, l, t, s);
        }

        public static string getXX(string t, string b, string l, string lg, string g)
        {
            return roteds1x2hf1Service.getXX(t, b, l, lg, g);
        }

        public static string getInfo(int i, string t)
        {
            return roteds1x2hf1Service.getInfo(i, t);
        }

        public static string getrqInfo(int i, string t)
        {
            return roteds1x2hf1Service.getrqInfo(i, t);
        }

        public static string getdxInfo(int i, string t)
        {
            return roteds1x2hf1Service.getdxInfo(i, t);
        }

        public static string updaInfo(string t, string mi, string ma, string sm, int i)
        {
            return roteds1x2hf1Service.updaInfo(t,mi,ma,sm,i);
        }
        #endregion
	}
}
