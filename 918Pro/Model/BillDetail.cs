using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class BillDetail
    {
        public Int32 Id { get; set; }

        public String UserName { get; set; }

        public String Type { get; set; }

        public Decimal InAmount { get; set; }

        public Decimal OutAmount { get; set; }

        public Decimal Balance { get; set; }

        public DateTime BillTime { get; set; }

        public String CardNo { get; set; }

        public String Names { get; set; }

        public String Currency { get; set; }

        public String Remark { get; set; }
    }
}
