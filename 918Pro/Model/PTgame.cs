using System;

namespace Model
{
    [Serializable]
    public class PTgame
    {
        public String Gameid { get; set; }
        public String Login { get; set; }
        public String Gamecode { get; set; }
        public String Dealcode { get; set; }
        public Int32 Status { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public Decimal Hold { get; set; }
        public Decimal Handle { get; set; }
        public Decimal Bet_amount { get; set; }
        public Decimal Payout_amount { get; set; }
        public String Result { get; set; }
    }
}
