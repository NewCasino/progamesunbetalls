using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Collections;
using System.Reflection;

namespace DAL
{
    /// <summary>
    /// 不同的对象转JSON格式
    /// </summary>
    public class ObjectToJson
    {
        /// <summary>
        /// DataReader转换成JSON格式
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static String ReaderToJson(DbDataReader reader)
        {
            if (reader.FieldCount <= 0) return string.Empty;
            StringBuilder jsonString = new StringBuilder();
            jsonString.Append("[");
            try
            {
                while (reader.Read())
                {
                    jsonString.Append("{");
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Type type = reader.GetFieldType(i);
                        string strKey = reader.GetName(i);
                        string strValue = reader[i].ToString();
                        jsonString.Append("\"" + strKey + "\":");
                        try
                        {
                            strValue = StringFormat(strValue, type);
                        }
                        catch (Exception) {
                            strValue = "";
                        }
                        if (i < reader.FieldCount - 1)
                        {
                            jsonString.Append(strValue + ",");
                        }
                        else
                        {
                            jsonString.Append(strValue);
                        }
                    }
                    jsonString.Append("},");
                }
            }
            catch (Exception e)
            { }
            reader.Close();
            jsonString.Remove(jsonString.Length - 1, 1);
            jsonString.Append("]");
            
            return jsonString.ToString();
        }
        /// <summary>  
        /// 过滤特殊字符  
        /// </summary>  
        /// <param name="s"></param>  
        /// <returns></returns>  
        private static String String2Json(String s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s.ToCharArray()[i];
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\""); break;
                    case '\\':
                        sb.Append("\\\\"); break;
                    case '/':
                        sb.Append("\\/"); break;
                    case '\b':
                        sb.Append("\\b"); break;
                    case '\f':
                        sb.Append("\\f"); break;
                    case '\n':
                        sb.Append("\\n"); break;
                    case '\r':
                        sb.Append("\\r"); break;
                    case '\t':
                        sb.Append("\\t"); break;
                    default:
                        sb.Append(c); break;
                }
            }
            return sb.ToString();
        }
        /// <summary>  
        /// 格式化字符型、日期型、布尔型  
        /// </summary>  
        /// <param name="str"></param>  
        /// <param name="type"></param>  
        /// <returns></returns>  
        private static String StringFormat(String str, Type type)
        {
            if (type == typeof(string))
            {
                str = String2Json(str);
                str = "\"" + str + "\"";
            }
            else if (type == typeof(DateTime))
            {
                str = "\"" + str + "\"";
            }
            else if (type == typeof(bool))
            {
                str = str.ToLower();
                str = "\"" + str + "\"";
            }
            else
            {
                str = "\"" + str + "\"";
            }
            return str;
        }
        /// <summary> 
        /// String转换为Json 
        /// </summary> 
        /// <param name="value">String对象</param> 
        /// <returns>Json字符串</returns> 
        public static string ToJson(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            string temstr;
            temstr = value;
            temstr = temstr.Replace("{", "｛").Replace("}", "｝").Replace(":", "：").Replace(",", "，").Replace("[", "【").Replace("]", "】").Replace(";", "；").Replace("\n", "<br/>").Replace("\r", "");

            temstr = temstr.Replace("\t", "   ");
            temstr = temstr.Replace("'", "\'");
            temstr = temstr.Replace(@"\", @"\\");
            temstr = temstr.Replace("\"", "\"\"");
            return temstr;
        }
        /// <summary> 
        /// DataSet转换为Json 
        /// </summary> 
        /// <param name="dataSet">DataSet对象</param> 
        /// <returns>Json字符串</returns> 
        public static string ToJson(DataSet dataSet)
        {
            string jsonString = "{";
            foreach (DataTable table in dataSet.Tables)
            {
                jsonString += "\"" + ToJson(table.TableName) + "\":" + ToJson(table) + ",";
            }
            return jsonString = DeleteLast(jsonString) + "}";
        }
        /// <summary> 
        /// 删除结尾字符 
        /// </summary> 
        /// <param name="str">需要删除的字符</param> 
        /// <returns>完成后的字符串</returns> 
        private static string DeleteLast(string str)
        {
            if (str.Length > 1)
            {
                return str.Substring(0, str.Length - 1);
            }
            return str;
        }
        /// <summary>
        /// 对象集合转换JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonName"></param>
        /// <param name="IL"></param>
        /// <returns></returns>
        public static string ObjectListToJson<T>( IList<T> IL) 
        { 
            StringBuilder Json = new StringBuilder(); 
            Json.Append("["); 
            if (IL.Count > 0) 
            { 
                for (int i = 0; i < IL.Count; i++) 
                { 
                    T obj = Activator.CreateInstance<T>(); 
                    Type type = obj.GetType(); 
                    PropertyInfo[] pis = type.GetProperties(); 
                    Json.Append("{"); 
                    for (int j = 0; j < pis.Length; j++) 
                    { 
                        Json.Append("\"" + pis[j].Name.ToString() + "\":\"" + pis[j].GetValue(IL[i], null) + "\""); 
                        if (j < pis.Length - 1) 
                        { 
                            Json.Append(","); 
                        } 
                    } 
                    Json.Append("}"); 
                    if (i < IL.Count - 1) 
                    { 
                        Json.Append(","); 
                    } 
                } 
            } 
            Json.Append("]"); 
            return Json.ToString(); 
        }

        /// <summary>
        /// 对象转换JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonName"></param>
        /// <param name="IL"></param>
        /// <returns></returns>
        public static string ObjectsToJson<T>(T IL)
        {
            StringBuilder Json = new StringBuilder();
            Json.Append("[");
                    T obj = Activator.CreateInstance<T>();
                    Type type = obj.GetType();
                    PropertyInfo[] pis = type.GetProperties();
                    Json.Append("{");
                    for (int j = 0; j < pis.Length; j++)
                    {
                        Json.Append("\"" + pis[j].Name.ToString() + "\":\"" + pis[j].GetValue(IL, null) + "\"");
                        if (j < pis.Length - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
            Json.Append("]");
            return Json.ToString();
        } 

        public static string DataTableToJson(DataTable dt) 
        { 
            StringBuilder Json = new StringBuilder();
            Json.Append("[");
            if (dt.Rows.Count > 0) 
            { 
                for (int i = 0; i < dt.Rows.Count; i++) 
                { 
                    Json.Append("{"); 
                    for (int j = 0; j < dt.Columns.Count; j++) 
                    { 
                        Json.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":\"" + dt.Rows[i][j].ToString() + "\""); 
                        if (j < dt.Columns.Count - 1) 
                        { 
                            Json.Append(","); 
                        } 
                    } 
                    Json.Append("}"); 
                    if (i < dt.Rows.Count - 1) 
                    { 
                        Json.Append(","); 
                    } 
                } 
            } 
            Json.Append("]"); 
            return Json.ToString(); 
    } 
        /// <summary> 
        /// 对象集合转换Json 
        /// </summary> 
        /// <param name="array">集合对象</param> 
        /// <returns>Json字符串</returns> 
        public static string ToJson(IEnumerable array)
        {
            string jsonString = "[";
            foreach (object item in array)
            {
                jsonString += ToJson(item) + ",";
            }
            return DeleteLast(jsonString) + "]";
        }
        /// <summary> 
        /// 对象转换为Json字符串 
        /// </summary> 
        /// <param name="jsonObject">对象</param> 
        /// <returns>Json字符串</returns> 
        public static string ToJson(object jsonObject)
        {
            string jsonString = "{";
            PropertyInfo[] propertyInfo = jsonObject.GetType().GetProperties();
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                object objectValue = propertyInfo[i].GetGetMethod().Invoke(jsonObject, null);
                string value = string.Empty;
                if (objectValue is DateTime || objectValue is Guid || objectValue is TimeSpan)
                {
                    value = "'" + objectValue.ToString() + "'";
                }
                else if (objectValue is string)
                {
                    value = "'" + ToJson(objectValue.ToString()) + "'";
                }
                else if (objectValue is IEnumerable)
                {
                    value = ToJson((IEnumerable)objectValue);
                }
                else
                {
                    value = ToJson(objectValue.ToString());
                }
                jsonString += "\"" + ToJson(propertyInfo[i].Name) + "\":" + value + ",";
            }
            return DeleteLast(jsonString) + "}";
        } 
        /// <summary> 
        /// Datatable转换为Json 
        /// </summary> 
        /// <param name="table">Datatable对象</param> 
        /// <returns>Json字符串</returns> 
        public static string ToJson(DataTable table)
        {
            string jsonString = "[";
            DataRowCollection drc = table.Rows;
            for (int i = 0; i < drc.Count; i++)
            {
                jsonString += "{";
                foreach (DataColumn column in table.Columns)
                {
                    jsonString += "\"" + ToJson(column.ColumnName) + "\":";
                    if (column.DataType == typeof(DateTime) || column.DataType == typeof(string))
                    {
                        jsonString += "\"" + ToJson(drc[i][column.ColumnName].ToString()) + "\",";
                    }
                    else
                    {
                        jsonString += ToJson(drc[i][column.ColumnName].ToString()) + ",";
                    }
                }
                jsonString = DeleteLast(jsonString) + "},";
            }
            return DeleteLast(jsonString) + "]";
        }
        /// <summary> 
        /// 普通集合转换Json 
        /// </summary> 
        /// <param name="array">集合对象</param> 
        /// <returns>Json字符串</returns> 
        public static string ToArrayString(IEnumerable array)
        {
            string jsonString = "[";
            foreach (object item in array)
            {
                jsonString = ToJson(item.ToString()) + ",";
            }
            return DeleteLast(jsonString) + "]";
        }

        //生成无重复的随机数　使用 Guid
        public static string GetPassWord(int pwdlen)
        {
            string guidStr = Guid.NewGuid().ToString();
            guidStr = guidStr.Replace("-", "");
            string pwdchar = guidStr.Substring(0, pwdlen);

            return pwdchar;
        }
        //生成随机数
        public static string MakePassword(int pwdlen)
        {
            string pwdchars = "0123456789";
            string tmpstr = "";
            int iRandNum;
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < pwdlen; i++)
            {
                iRandNum = rnd.Next(pwdchars.Length);
                tmpstr += pwdchars[iRandNum];
            }
            return tmpstr;
        }

        } 

}
