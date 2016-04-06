using System;
namespace Model
{
	[Serializable]
	public class Grade
	{

		public Int32 ID { get; set; }

		public String LevelNamecn { get; set; }

        public String LevelNametw { get; set; }

        public String LevelNameen { get; set; }

        public String LevelNameth { get; set; }

        public String LevelNamevn { get; set; }

		public String LevelRemark { get; set; }
	} 
}
