using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 自动抓取工商信息实体类
    /// </summary>
    [Serializable]
    public class payrecord
    {
         public Int32 payID { get; set; }
         public String payNumID { get; set; }
         public String payType { get; set; }
         public String payUser { get; set; }
         public Decimal payMoney { get; set; }
         public String payState { get; set; }
         public String userRealName { get; set; }
         public Decimal curMoney { get; set; }
         public Decimal oldMoney { get; set; }
         public String thisPayState { get; set; }
         public DateTime payTime { get; set; }
         public String source { get; set; }
         public DateTime createTime { get; set; }       
         public Decimal amount{ get; set; }
         public Decimal payFree{ get; set; }
    }
}
