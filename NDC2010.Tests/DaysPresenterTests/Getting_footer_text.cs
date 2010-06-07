using System;
using NUnit.Framework;

namespace NDC2010.Tests.DaysPresenterTests
{
	[TestFixture]
	public class Getting_footer_text : DaysPresenterTestBase
	{
		[SetUp]
		public void SetUp()
		{
			SetupPresenterAndMocks();
		}
		
		[Test]
		public void Should_return_some_footer_text()
		{
			Presenter.GetFooterText().ShouldNotBeNullOrEmpty();
		}
	}
}