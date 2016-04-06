using System;
namespace Model
{
    [Serializable]
    public class Casino
    {

        public Int32 Id { get; set; }

        public String Namecn { get; set; }

        public String Nametw { get; set; }

        public String Nameen { get; set; }

        public String Nameth { get; set; }

        public String Nametv { get; set; }

        public Byte Display { get; set; }

        public String Address { get; set; }

        public String Path { get; set; }

        public Int32 Ord { get; set; }
    }
}