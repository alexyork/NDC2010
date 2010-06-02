using System;
using System.Linq;
using System.Xml.Linq;
using NDC2010.Model;

namespace NDC2010.Logic
{
	public static class TweetConverter
	{
			/*
			Tweets = (from tweet in twitterXml.Descendants(ns + "entry")
					  let author = tweet.Element(ns + "author")
			          let id = tweet.Element(ns + "id").Value.Split(new [] {':'}).ElementAt(2)
			          let thumb = tweet.Elements(ns + "link").Where(e => e.Attribute("type").Value == "image/png").FirstOrDefault()
				      select new Tweet
					  {
						  ID = long.Parse(id),
						  Content = (string) tweet.Element(ns + "title"),
						  AuthorName = (string) author.Element(ns + "name"),
						  AuthorUrl = (string) author.Element(ns + "url"),
						  AuthorImageUrl = (string) thumb.Attribute("href")
					  }).ToList();
			*/
		
		public static XNamespace NS = "http://www.w3.org/2005/Atom";
		
		public static Tweet FromXml(XElement xml)
   		{
			var id = xml.Element(NS + "id").Value.Split(new [] {':'}).ElementAt(2);
			var thumbnail = xml.Elements(NS + "link").Where(e => e.Attribute("type").Value == "image/png").FirstOrDefault();
			var author = xml.Element(NS + "author");
			
			return new Tweet
			{
				ID = long.Parse(id),
				AuthorImageUrl = (string) thumbnail.Attribute("href"),
				AuthorName = (string) author.Element(NS + "name"),
				AuthorUrl = (string) author.Element(NS + "uri"),
				Content = (string) xml.Element(NS + "title"),
				Timestamp = GetPublishedDate((string) xml.Element(NS + "published"))
			};
   		}
		
		private static DateTime GetPublishedDate(string tweetedDate)
		{
			Console.WriteLine("Tweet date: " + tweetedDate);
			
			// Before: 2010-04-09T16:22:00Z
			tweetedDate = tweetedDate.Replace("T", "-")
									 .Replace("Z", "")
									 .Replace(":", "-");
			
			// After: 2010-04-09-16-22-00
			var dateParts = tweetedDate.Split('-');
			
			return new DateTime(int.Parse(dateParts[0]),
			                    int.Parse(dateParts[1]),
			                    int.Parse(dateParts[2]),
			                    int.Parse(dateParts[3]) + 2,
			                    int.Parse(dateParts[4]),
			                    int.Parse(dateParts[5]));
		}
	}
}