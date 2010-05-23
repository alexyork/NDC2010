using System;
using NDC2010.Model;
using NUnit.Framework;

namespace NDC2010.Tests.SessionPresenterTests
{
	[TestFixture]
	public class Getting_session_text : SessionPresenterTestBase
	{
		[SetUp]
		public void SetUp()
		{
			SetupPresenterAndMocks();
		}
		
		[Test]
		public void Should_get_speaker_text_with_1_speaker()
		{
			Presenter.Session = new Session {
				Speakers = new Speaker [] {
					new Speaker { Name = "Speaker 1" }
				}
			};
			
			Presenter.GetTextForSpeakers().ShouldBe("Speaker 1");
		}
		
		[Test]
		public void Should_get_speaker_text_with_2_speakers()
		{
			Presenter.Session = new Session {
				Speakers = new Speaker [] {
					new Speaker { Name = "Speaker 1" },
					new Speaker { Name = "Speaker 2" }
				}
			};
			
			Presenter.GetTextForSpeakers().ShouldBe("Speaker 1, Speaker 2");
		}
		
		[Test]
		public void Should_get_session_date_and_track_info()
		{
			Presenter.Session = new Session {
				Day = 2,
				Time = "9:00 - 10:00",
				Track = 5
			};
			
			Presenter.GetTextForTimeAndPlace().ShouldBe("Day 2; 9:00 - 10:00; Track 5");
		}
	}
}
