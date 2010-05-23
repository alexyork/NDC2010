using System;
using NUnit.Framework;

namespace NDC2010.Tests.SpeakerPresenterTests
{
	[TestFixture]
	public class Getting_heading_text : SpeakerPresenterTestBase
	{
		[SetUp]
		public void SetUp()
		{
			SetupPresenterAndMocks();
		}
		
		[Test]
		public void Should_return_correct_text_for_name()
		{
			Presenter.GetHeadingTextForName().ShouldBe("Name");
		}
		
		[Test]
		public void Should_return_correct_text_for_bio()
		{
			Presenter.GetHeadingTextForBio().ShouldBe("Bio");
		}
		
		/*
		[Test]
		public void Should_return_correct_text_for_sessions()
		{
			Presenter.GetHeadingTextForSessions().ShouldBe("Sessions");
		}
		*/
	}
}