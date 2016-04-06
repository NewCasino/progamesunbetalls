using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace DAL
{
    public class ModelConvertHelper<T> where T:new()
    {
        public static IList<T> ConvertToModel(DataTable dt)
        { 
            //定义集合
            IList<T> ts = new List<T>();
            String tempName = "";
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    
                    tempName = pi.Name;
                    //检查DataTable是否包含此列
                    if (dt.Columns.Contains(tempName))
                    {
                        
                        //判断此属性是否有set
                        if (!pi.CanWrite) continue;
                        object value = dr[tempName];
                        if (value.GetType().Name == "UInt32")
                        { 
                            value=Convert.ToInt32(value);
                        }
                        if (value != DBNull.Value)
                        {
                            pi.SetValue(t,value , null);
                        }
                        
                    }
                }
                ts.Add(t);
            }
            return ts;
        }
    }
}
