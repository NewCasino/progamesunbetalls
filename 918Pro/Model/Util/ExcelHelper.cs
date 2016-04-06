using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace Util
{
    /// <summary>
    /// Excel相关操作类
    /// </summary>
    public class ExcelHelper
    {
        private ExcelHelper() { }

        #region 根据Excel文件名(包含所在的路径)获得DataTable

        /// <summary>
        /// 根据Excel文件名(包含所在的路径)获得DataTable
        /// </summary>
        /// <param name="strExcelFilePath">Excel文件名(包含所在的路径)</param>
        /// <returns>返回的DataTable</returns>
        public static DataTable GetDataTable(string strExcelFilePath)
        {
            return GetDataTable(strExcelFilePath, 0);
        }

        /// <summary>
        /// 根据Excel文件名(包含所在的路径)获得DataTable
        /// </summary>
        /// <param name="strExcelFilePath">Excel文件名(包含所在的路径)</param>
        /// <param name="TableIndex"></param>
        /// <returns>返回的DataTable</returns>
        public static DataTable GetDataTable(string strExcelFilePath, int TableIndex)
        {
            DataTable dtResuilt = new DataTable();
            string TableName = GetTableName(strExcelFilePath, TableIndex);
            string strConn = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + strExcelFilePath.Trim() + ";Extended Properties=\"Excel 8.0;IMEX=1\"";
            using (OleDbDataAdapter cmd = new OleDbDataAdapter("SELECT * FROM [" + TableName + "]", strConn))
            {
                cmd.Fill(dtResuilt);
                return dtResuilt;
            }
        }

        #endregion

        #region 取得Sheet名称

        /// <summary>
        /// 取得Sheet名称
        /// </summary>
        /// <param name="strExcelFilePath">Excel文件名(包含所在的路径)</param>
        /// <param name="TableIndex">页签索引</param>
        /// <returns>Sheet名称</returns>
        public static string GetTableName(string strExcelFilePath, int TableIndex)
        {
            string strConn = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + strExcelFilePath.Trim() + "; Extended Properties=\"Excel 8.0;IMEX=1\"";

            using (OleDbConnection ExcelConnection = new OleDbConnection(strConn))
            {
                try
                {
                    ExcelConnection.Open();
                    return ExcelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" }).Rows[TableIndex][2].ToString();

                }
                catch (OleDbException ex)
                {
                    throw ex;
                }
            }
        }

        #endregion

    }
}
