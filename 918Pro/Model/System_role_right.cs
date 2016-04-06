using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class System_role_right
    {

        public Int32 Role_right_id { get; set; }

        public Int32 RoleId { get; set; }

        public Int32 Module_right_id { get; set; }
    }
}
