using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace Util
{
    /// <summary>
    /// Excel��ز�����
    /// </summary>
    public class ExcelHelper
    {
        private ExcelHelper() { }

        #region ����Excel�ļ���(�������ڵ�·��)���DataTable

        /// <summary>
        /// ����Excel�ļ���(�������ڵ�·��)���DataTable
        /// </summary>
        /// <param name="strExcelFilePath">Excel�ļ���(�������ڵ�·��)</param>
        /// <returns>���ص�DataTable</returns>
        public static DataTable GetDataTable(string strExcelFilePath)
        {
            return GetDataTable(strExcelFilePath, 0);
        }

        /// <summary>
        /// ����Excel�ļ���(�������ڵ�·��)���DataTable
        /// </summary>
        /// <param name="strExcelFilePath">Excel�ļ���(�������ڵ�·��)</param>
        /// <param name="TableIndex"></param>
        /// <returns>���ص�DataTable</returns>
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

        #region ȡ��Sheet����

        /// <summary>
        /// ȡ��Sheet����
        /// </summary>
        /// <param name="strExcelFilePath">Excel�ļ���(�������ڵ�·��)</param>
        /// <param name="TableIndex">ҳǩ����</param>
        /// <returns>Sheet����</returns>
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
