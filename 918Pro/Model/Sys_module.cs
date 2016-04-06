using System;
namespace Model
{
    [Serializable]
    public class Sys_module
    {

        public String Module_code { get; set; }

        public String Module_parent_code { get; set; }

        public String Module_text { get; set; }

        public String Module_url { get; set; }

        public String Module_target { get; set; }

        public String Status { get; set; }

        public String Sorts { get; set; }

        public Int32 BetGamesID { get; set; }

        public String Module_type { get; set; }

        public String Module_tip { get; set; }
    }
}