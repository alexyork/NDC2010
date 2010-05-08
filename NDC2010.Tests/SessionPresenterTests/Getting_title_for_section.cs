using System;
using NUnit.Framework;

namespace NDC2010.Tests.SessionPresenterTests
{
	[TestFixture]
	public class Getting_title_for_section : SessionPresenterTestBase
	{
		[SetUp]
		public void SetUp()
		{
			SetupPresenterAndMocks();
		}
		
		[Test]
		public void Should_return_correct_text_for_title_section()
		{
			Presenter.GetSectionHeadingText(0).ShouldBe("Title");
		}
		
		[Test]
		public void Should_return_correct_text_for_description_section()
		{
			Presenter.GetSectionHeadingText(1).ShouldBe("Description");
		}
		
		[ExpectedException]
		public void Should_throw_exception_for_invalid_section()
		{
			Presenter.GetSectionHeadingText(-1).ShouldBe("foobar");
		}
	}
}
