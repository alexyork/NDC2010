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
		public void GetDayTimeTrackInfo_Should_get_day_time_and_track_info()
		{
			var session = new Session
			{
				Day = 2,
				Time = "9:00 - 10:00",
				Track = 5
			};
			
			session.GetDayTimeTrackInfo().ShouldBe("Day 2; 9:00 - 10:00; Track 5");
		}
		
		[Test]
		public void GetTimeTrackSpeakerInfo_Should_get_time_track_and_speaker_info()
		{
			var session = new Session
			{
				Time = "9:00 - 10:00",
				Track = 5,
				Speakers = new Speaker[] { new Speaker { Name = "Alex York" } }
			};
			
			session.GetTimeTrackSpeakerInfo().ShouldBe("9:00 - 10:00; Track 5; Alex York");
		}
	}
}

