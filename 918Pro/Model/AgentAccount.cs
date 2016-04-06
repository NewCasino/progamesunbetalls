using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class AgentAccount
    {
        public Int32 ID { get; set; }

        public String Name { get; set; }

        public String AgentName { get; set; }

        public String Password { get; set; }

        public String Casino { get; set; }

        public String Cookie { get; set; }

        public String Address { get; set; }

        public String Address2 { get; set; }

        public String IsEnable { get; set; }

        public String IsLogin { get; set; }

        public String Operator { get; set; }

        public DateTime OperationTime { get; set; }

        public String Status { get; set; }

        public String IP { get; set; }
    }
}
