using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class BankInfo
    {
        public Int32 Id { get; set; }

        public String BankNamecn { get; set; }

        public String BankNametw { get; set; }

        public String BankNameen { get; set; }

        public String BankNameth { get; set; }

        public String BankNamevn { get; set; }

        public String Currency { get; set; }

        public String Operator { get; set; }

        public DateTime OperationTime { get; set; }

        public String IP { get; set; }

        public String Status { get; set; }
    }
}
