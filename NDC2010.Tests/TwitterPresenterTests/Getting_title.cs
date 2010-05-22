using System;
using NUnit.Framework;

namespace NDC2010.Tests.TwitterPresenterTests
{
	[TestFixture]
	public class Getting_title : TwitterPresenterTestBase
	{
		[SetUp]
		public void SetUp()
		{
			SetupPresenterAndMocks();
		}
		
		[Test]
		public void Should_return_the_correct_title()
		{
			Presenter.GetTitle().ShouldBe("Twitter");
		}
	}
}