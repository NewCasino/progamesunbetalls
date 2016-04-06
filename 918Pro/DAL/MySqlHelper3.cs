using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient; 

namespace DAL
{
    public class MySqlHelper3
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static readonly String ConnectionString = ConfigurationManager.ConnectionStrings["ConnPay"].ConnectionString;
        #region 执行操作，返回受影响的行数
        /// <summary>
        /// 执行操作，返回受影响的行数
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="commandParameters">执行命令需要的参数</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteNonQuery(string cmdText, params MySqlParameter[] commandParameters)
        {
            return ExecuteNonQuery(CommandType.Text, cmdText, commandParameters);
        }

        /// <summary>
        /// 执行操作，返回受影响的行数
        /// </summary>
        /// <param name="tran">已存在的事务</param>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="commandParameters">执行命令需要的参数</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteNonQuery(MySqlTransaction trans, string cmdText, params MySqlParameter[] commandParameters)
        {
            return ExecuteNonQuery(trans, CommandType.Text, cmdText, commandParameters);

        }
        /// <summary>
        /// 执行操作，返回受影响的行数(存储过程)
        /// </summary>
        /// <param name="cmdText">存储过程名称</param>
        /// <param name="commandParameters">执行命令需要的参数</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteNonQueryProc(String cmdText, params MySqlParameter[] commandParameters)
        {
            return ExecuteNonQuery(CommandType.StoredProcedure, cmdText, commandParameters);
        }
        /// <summary>
        /// 执行操作，返回受影响的行数(存储过程)
        /// </summary>
        /// <param name="tran">已存在的事务</param>
        /// <param name="cmdText">存储过程名称</param>
        /// <param name="commandParameters">执行命令需要的参数</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteNonQueryProc(MySqlTransaction trans, string cmdText, params MySqlParameter[] commandParameters)
        {
            return ExecuteNonQuery(trans, CommandType.StoredProcedure, cmdText, commandParameters);
        }

        private static int ExecuteNonQuery(CommandType cmdType, String cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }
        private static int ExecuteNonQuery(MySqlTransaction tran, CommandType cmdType, String cmdText, params MySqlParameter[] cmdParams)
        {
            MySqlCommand cmd = new MySqlCommand();
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                PrepareCommand(cmd, conn, tran, cmdType, cmdText, cmdParams);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }
        #endregion

        #region 执行查询，返回SqlDataReader

        /// <summary>
        /// 执行查询，返回SqlDataReader
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <param name="commandParameters">执行命令的参数集</param>
        /// <returns>一个结果集对象SqlDataReader</returns>
        public static MySqlDataReader ExecuteReader(string cmdText, params MySqlParameter[] commandParameters)
        {
            return ExecuteReader(CommandType.Text, cmdText, commandParameters);
        }

        /// <summary>
        /// 执行查询，返回SqlDataReader(存储过程)
        /// </summary>
        /// <param name="commandText">存储过程名称</param>
        /// <param name="commandParameters">执行命令的参数集</param>
        /// <returns>一个结果集对象SqlDataReader</returns>
        public static MySqlDataReader ExecuteReaderProc(string cmdText, params MySqlParameter[] commandParameters)
        {
            return ExecuteReader(CommandType.StoredProcedure, cmdText, commandParameters);
        }

        public static MySqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();

            MySqlConnection conn = new MySqlConnection(ConnectionString);

            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);

                MySqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                cmd.Parameters.Clear();

                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }
        #endregion
        #region 执行操作，返回表中第一行，第一列的值

        /// <summary>
        /// 执行操作，返回表中第一行，第一列的值
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <param name="commandParameters">执行命令的参数集</param>        
        /// <returns>返回的对象</returns>
        public static object ExecuteScalar(string cmdText, params MySqlParameter[] commandParameters)
        {
            return ExecuteScalar(CommandType.Text, cmdText, commandParameters);
        }

        /// <summary>
        /// 执行操作，返回表中第一行，第一列的值(存储过程)
        /// </summary>
        /// <param name="commandText">存储过程名称</param>
        /// <param name="commandParameters">执行命令的参数集</param>        
        /// <returns>返回的对象</returns>
        public static object ExecuteScalarProc(string cmdText, params MySqlParameter[] commandParameters)
        {
            return ExecuteScalar(CommandType.StoredProcedure, cmdText, commandParameters);
        }

        public static object ExecuteScalar(CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);

                object val = cmd.ExecuteScalar();

                cmd.Parameters.Clear();

                return val;
            }
        }

        #endregion
        #region 执行一个命令，返回数据集或数据表

        /// <summary>
        /// 执行一个命令，返回数据表
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <param name="commandParameters">执行命令的参数集</param>
        /// <returns>返回数据表</returns>
        public static DataTable ExecuteDataTable(string commandText, params MySqlParameter[] commandParameters)
        {
            return ExecuteDataSet(commandText, commandParameters).Tables[0];
        }

        /// <summary>
        /// 执行一个命令，返回数据表(存储过程)
        /// </summary>
        /// <param name="commandText">存储过程名称</param>
        /// <param name="commandParameters">执行命令的参数集</param>
        /// <returns>返回数据表</returns>
        public static DataTable ExecuteDataTableProc(string commandText, params MySqlParameter[] commandParameters)
        {
            return ExecuteDataSetProc(commandText, commandParameters).Tables[0];
        }

        /// <summary>
        /// 执行一个命令，返回数据集
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <param name="commandParameters">执行命令的参数集</param>
        /// <returns>返回数据集</returns>
        public static DataSet ExecuteDataSet(string commandText, params MySqlParameter[] commandParameters)
        {
            return ExecuteDataSet(CommandType.Text, commandText, commandParameters);
        }

        /// <summary>
        /// 执行一个命令，返回数据集(存储过程)
        /// </summary>
        /// <param name="commandText">存储过程名称</param>
        /// <param name="commandParameters">执行命令的参数集</param>
        /// <returns>返回数据集</returns>
        public static DataSet ExecuteDataSetProc(string commandText, params MySqlParameter[] commandParameters)
        {
            return ExecuteDataSet(CommandType.StoredProcedure, commandText, commandParameters);
        }

        public static DataSet ExecuteDataSet(CommandType cmdType, string commandText, params MySqlParameter[] commandParameters)
        {

            MySqlCommand cmd = new MySqlCommand();

            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, commandText, commandParameters);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                cmd.Parameters.Clear();
                return ds;
            }
        }

        #endregion
        /// <summary>
        /// 设置SqlCommand对象
        /// </summary>
        /// <param name="cmd">SqlCommand对象</param>
        /// <param name="conn">SqlConnection 对象</param>
        /// <param name="trans">SqlTransaction 对象</param>
        /// <param name="cmdType">CommandType(执行存储过程或SQL语句)</param>
        /// <param name="cmdText">存储过程名称或SQL语句</param>
        /// <param name="cmdParms">命令中用到的参数集</param>
        private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, CommandType cmdType, String cmdText, MySqlParameter[] cmdParas)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = cmdType;
            if (cmdParas != null)
            {
                foreach (MySqlParameter param in cmdParas)
                    cmd.Parameters.Add(param);
            }

        }
    }
}
