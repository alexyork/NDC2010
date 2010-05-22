using System;
using System.Linq;
using NUnit.Framework;

namespace NDC2010.Tests.SessionPresenterTests
{
	[TestFixture]
	public class Getting_title : SessionPresenterTestBase
	{
		[SetUp]
		public void SetUp()
		{
			SetupPresenterAndMocks();
		}
		
		[Test]
		public void Should_return_correct_title()
		{
			Presenter.GetTitle().ShouldBe("Session");
		}
	}
}