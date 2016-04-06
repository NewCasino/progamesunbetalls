using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class serverlog
    {
        public Int32 ID { get; set; }

        public String IP { get; set; }
        public String magnerUser { get; set; }
        public DateTime LoginBegin { get; set; }

        public DateTime LoginEnd { get; set; }
        public DateTime LoginTime { get; set; }
        
    }
}
