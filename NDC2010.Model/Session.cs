using System;

namespace NDC2010.Model
{
	public class Session
	{
		public Guid ID  { get; set; }
		public string Title { get; set; }
		public Speaker[] Speakers { get; set; }
		public int Day { get; set; }
		public int Track { get; set; }
		public string Time { get; set; }
        public string Description { get; set; }
		public bool IsSelected { get; set; }
	}
}