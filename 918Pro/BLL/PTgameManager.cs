using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace BLL
{
    public class PTgameManager
    {
        /// <summary>
        /// 导入数据到数据集中
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="TableName"></param>
        /// <param name="tablename2">如果这个有就以他为表名，没有的话就以TableName</param>
        /// <returns></returns>
        public static DataTable InputExcel(string Path, string fileName)
        {
            try
            {
                //exl
                //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
                //csv
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties='text;HDR=Yes;IMEX=1;FMT=Delimited';Data Source=" + Path;
                OleDbConnection conn = new OleDbConnection(strConn);
                DataTable dt1 = new DataTable();
                string sql = "select * from " + fileName;
                conn.Open();
                OleDbDataAdapter dr = new OleDbDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                dr.Fill(ds, "table1");
                dt1 = ds.Tables["table1"];

                return dt1;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Excel数据导入数据库
        /// </summary>
        /// <param name="path"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static bool ExcelToData(string path, string filename, DateTime uptime, ref int isexistcount)
        {
            DataTable excelData = InputExcel(path, filename);
            foreach (DataRow row in excelData.Rows)
            {
                Model.PTgame info = new Model.PTgame();
                info.Login = row[0].ToString().ToLower();
                info.Gamecode = "801";
                info.Gameid = "801";
                info.Status = 1;
                info.Startdate = uptime;
                info.Enddate = uptime;
                info.Hold = -Convert.ToDecimal(row[5]);
                info.Bet_amount = Convert.ToDecimal(row[3]);
                info.Payout_amount = Convert.ToDecimal(row[4]);

                if (info.Login.IndexOf("total cny") == -1)
                {
                    //判断数据是否重复插入
                    if (!DAL.PTgame.IsExistData(info.Login, uptime, info.Hold, info.Bet_amount))
                    {
                        //插入数据
                        DAL.PTgame.InsertData(info);
                    }
                    else
                    {
                        isexistcount++;
                    }
                   
                }
            }
            return true;
        }
    }
}
