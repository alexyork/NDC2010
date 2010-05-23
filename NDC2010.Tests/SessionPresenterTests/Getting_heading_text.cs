using System;
using NUnit.Framework;

namespace NDC2010.Tests.SessionPresenterTests
{
	[TestFixture]
	public class Getting_heading_text : SessionPresenterTestBase
	{
		[SetUp]
		public void SetUp()
		{
			SetupPresenterAndMocks();
		}
		
		[Test]
		public void Should_return_correct_text_for_session_info()
		{
			Presenter.GetHeadingTextForSessionInfo().ShouldBe("Session Info");
		}
		
		[Test]
		public void Should_return_correct_text_for_session_description()
		{
			Presenter.GetHeadingTextForSessionDescription().ShouldBe("Description");
		}
	}
}
