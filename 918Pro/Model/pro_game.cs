using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{   

    [Serializable]
    public class pro_game
    {

        public Int32 Id { get; set; }

        public Int32 type { get; set; }

        public Int32 number { get; set; }

        public String BigPric { get; set; }

        public String samlPric { get; set; }

        public String title { get; set; }

        public String conent { get; set; }

       
    }


}
