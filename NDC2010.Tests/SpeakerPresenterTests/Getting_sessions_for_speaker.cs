using System;
using System.Linq;
using NUnit.Framework;
using NDC2010.Model;

namespace NDC2010.Tests.SpeakerPresenterTests
{
	[TestFixture]
	public class Getting_sessions_for_speaker : SpeakerPresenterTestBase
	{
		[SetUp]
		public void SetUp()
		{
			SetupPresenterAndMocks();
		}
		
		[Test]
		public void Should_only_return_sessions_for_current_speaker()
		{
			Presenter.Sessions = SessionBuilder.CreateListWithSize(5)
									.WhereTheFirst(3)
										.HasSpeakers(new [] { MockSpeaker })
									.AndTheNext(2)
										.HasSpeakers(new [] { new Speaker { Name = "Bill Gates" } })
									.Build();
			
			Presenter.GetSessions().Length.ShouldBe(3);
		}
		
		[Test]
		public void Should_work_when_a_session_has_multiple_speakers()
		{
			var aSpeakerWeAreNotInterestedIn = new Speaker { Name = "Bill Gates" };
			
			Presenter.Sessions = SessionBuilder.CreateListWithSize(5)
									.WhereTheFirst(2)
										.HasSpeakers(new [] { MockSpeaker })
									.AndTheNext(2)
										.HasSpeakers(new [] { aSpeakerWeAreNotInterestedIn })
									.AndTheNext(1)
										.HasSpeakers(new [] { MockSpeaker, aSpeakerWeAreNotInterestedIn })
									.Build();
			
			Presenter.GetSessions().Length.ShouldBe(3);
		}
	}
}