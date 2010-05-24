using System;
using NUnit.Framework;
using NDC2010.Model;
using NDC2010.Logic;

namespace NDC2010.Tests
{
	[TestFixture]
	public class Session_extension_method_tests
	{
		[Test]
		public void Should_get_session_date_and_track_info()
		{
			var session = new Session
			{
				Day = 2,
				Time = "9:00 - 10:00",
				Track = 5
			};
			
			session.GetInfo().ShouldBe("Day 2; 9:00 - 10:00; Track 5");
		}
	}
}

