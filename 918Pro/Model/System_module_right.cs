using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class System_module_right
    {

        public Int32 Module_right_id { get; set; }

        public String Module_code { get; set; }

        public Int32 OperateID { get; set; }

        public String Status { get; set; }

        public String Right_page { get; set; }
    }
}
