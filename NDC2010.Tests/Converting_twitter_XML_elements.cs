using System;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;
using NDC2010.Model;
using NDC2010.Logic;

namespace NDC2010.Tests
{
	[TestFixture]
	public class Converting_twitter_XML_elements
	{
		private XDocument _twitterXml;
		private XNamespace _ns;
		private Tweet _firstTweet;
		
		[SetUp]
		public void SetUp()
		{
			_ns = TweetConverter.NS;
			
			_twitterXml = XDocument.Parse(
						  @"<?xml version='1.0' encoding='utf-16'?>
							<feed xmlns:google='http://base.google.com/ns/1.0' xml:lang='en-US' xmlns:openSearch='http://a9.com/-/spec/opensearch/1.1/' xmlns='http://www.w3.org/2005/Atom' xmlns:twitter='http://api.twitter.com/'>
							  <entry>
							    <id>tag:search.twitter.com,2005:11888749530</id>
							    <published>2010-04-09T16:22:00Z</published>
							    <link type='text/html' href='http://twitter.com/lcorneliussen/statuses/11888749530' rel='alternate' />
							    <title>content from first tweet</title>
							    <updated>2010-04-09T16:22:00Z</updated>
							    <link type='image/png' href='http://twitter.com/user1.jpg' rel='image' />
							    <author>
							      <name>first twitter user</name>
							      <uri>http://twitter.com/user1</uri>
							    </author>
							  </entry>
							  <entry>
							    <id>tag:search.twitter.com,2005:11882613726</id>
							    <published>2010-04-09T14:15:00Z</published>
							    <link type='text/html' href='http://twitter.com/anoras/statuses/11882613726' rel='alternate' />
							    <title>content from second tweet</title>
							    <updated>2010-04-09T14:15:00Z</updated>
							    <link type='image/png' href='http://twitter.com/user2.jpg' rel='image' />
							    <author>
							      <name>second twitter user</name>
							      <uri>http://twitter.com/user2</uri>
							    </author>
							  </entry>
							</feed>");
			
			var tweetXml = _twitterXml.Descendants(_ns + "entry").First();
			_firstTweet = TweetConverter.FromXml(tweetXml);
		}
		
		[Test]
		public void Should_set_AuthorImageUrl_correctly()
		{
			_firstTweet.AuthorImageUrl.ShouldBe("http://twitter.com/user1.jpg");
		}
		
		[Test]
		public void Should_set_AuthorName_correctly()
		{
			_firstTweet.AuthorName.ShouldBe("first twitter user");
		}
		
		[Test]
		public void Should_set_AuthorUrl_correctly()
		{
			_firstTweet.AuthorUrl.ShouldBe("http://twitter.com/user1");
		}
		
		[Test]
		public void Should_set_Content_correctly()
		{
			_firstTweet.Content.ShouldBe("content from first tweet");
		}
		
		[Test]
		public void Should_set_ID_correctly()
		{
			_firstTweet.ID.ShouldBe(11888749530);
		}
		
		[Test]
		public void Should_set_Timestamp_correctly()
		{
			// 2010-04-09T16:22:00Z
			// Should be two hours ahead of what the XML says
			_firstTweet.Timestamp.ShouldBe(new DateTime(2010, 4, 9, 18, 22, 00, 00));
		}
	}			                                                   
}