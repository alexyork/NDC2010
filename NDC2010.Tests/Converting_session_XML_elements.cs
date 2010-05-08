using System;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;
using NDC2010.Model;
using NDC2010.Logic;

namespace NDC2010.Tests
{
	[TestFixture]
	public class Converting_session_XML_elements
	{
		[Test]
		public void Should_convert_XElement_to_Session()
		{
			Console.WriteLine("1");
			var xml = XElement.Parse(
			            @"<session>
						    <title>Test session title</title>
						    <speakers>
						      <speaker>
						        <name>Alex York</name>
						        <info>Alex York info</info>
						      </speaker>
						    </speakers>
						    <time>13:40 - 14:40</time>
						    <day>1</day>
						    <track>2</track>
						    <description>Test description</description>
						  </session>");
			Console.WriteLine("2");
			
			var session = SessionConverter.FromXml(xml);
			
			session.Title.ShouldBe("Test session title");
			session.Speakers.Count().ShouldBe(1);
			session.Speakers[0].Name.ShouldBe("Alex York");
			session.Speakers[0].Info.ShouldBe("Alex York info");
			session.Time.ShouldBe("13:40 - 14:40");
			session.Day.ShouldBe(1);
			session.Track.ShouldBe(2);
			session.Description.ShouldBe("Test description");
		}
		
		[Test]
		public void Should_convert_XElement_to_Session_with_multiple_speakers()
		{
			Console.WriteLine("1");
			var xml = XElement.Parse(
			            @"<session>
						    <title>Test session title</title>
						    <speakers>
						      <speaker>
						        <name>Alex York</name>
						        <info>Alex York info</info>
						      </speaker>
						      <speaker>
	        						<name>Bill Gates</name>
	        						<info>Bill Gates info</info>
						      </speaker>
						      <speaker>
	        						<name>Steve Jobs</name>
	        						<info>Steve Jobs info</info>
						      </speaker>
						    </speakers>
						    <time>13:40 - 14:40</time>
						    <day>1</day>
						    <track>2</track>
						    <description>Test description</description>
						  </session>");
			Console.WriteLine("2");
			
			var session = SessionConverter.FromXml(xml);
			
			session.Speakers.Count().ShouldBe(3);
			session.Speakers[0].Name.ShouldBe("Alex York");
			session.Speakers[1].Name.ShouldBe("Bill Gates");
			session.Speakers[2].Name.ShouldBe("Steve Jobs");
		}
	}
}
