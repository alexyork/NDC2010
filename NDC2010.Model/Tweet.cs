using System;
using System.Drawing;

namespace NDC2010.Model
{
	public class Tweet
	{
		public long ID { get; set; }
		public string Content { get; set; }
		public string AuthorName { get; set; }
		public string AuthorUrl { get; set; }
		public SizeF LabelSize { get; set; }
		public SizeF CellSize { get; set; }
		public string AuthorImageUrl { get; set; }
		public DateTime Timestamp { get; set; }
	}
}