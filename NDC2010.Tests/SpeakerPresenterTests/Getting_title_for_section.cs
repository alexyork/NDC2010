using System;
using NUnit.Framework;

namespace NDC2010.Tests.SpeakerPresenterTests
{
	[TestFixture]
	public class Getting_title_for_section : SpeakerPresenterTestBase
	{
		[SetUp]
		public void SetUp()
		{
			SetupPresenterAndMocks();
		}
		
		[Test]
		public void Should_return_title_for_section_0()
		{
			Presenter.GetSectionHeadingText(0).ShouldBe("Name");
		}
		
		[Test]
		public void Should_return_bio_for_section_1()
		{
			Presenter.GetSectionHeadingText(1).ShouldBe("Bio");
		}
		
		[Test]
		public void Should_return_sessions_for_section_2()
		{
			Presenter.GetSectionHeadingText(2).ShouldBe("Sessions");
		}
		
		[ExpectedException]
		public void Should_throw_exception_for_section_3()
		{
			var result = Presenter.GetSectionHeadingText(3);
		}
		
		[ExpectedException]
		public void Should_throw_exception_for_section_minus1()
		{
			var result = Presenter.GetSectionHeadingText(-1);
		}
	}
}