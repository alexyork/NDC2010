using System;
using NUnit.Framework;

namespace NDC2010.Tests.DaysPresenterTests
{
	[TestFixture]
	public class Getting_heading_text : DaysPresenterTestBase
	{
		[SetUp]
		public void SetUp()
		{
			SetupPresenterAndMocks();
		}
		
		[Test]
		public void Should_return_correct_title()
		{
			Presenter.GetHeadingText().ShouldNotBeNullOrEmpty();
		}
	}
}