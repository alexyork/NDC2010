using System;
using System.Linq;
using NUnit.Framework;

namespace NDC2010.Tests.SpeakersPresenterTests
{
	[TestFixture]
	public class Getting_title : SpeakersPresenterTestBase
	{
		[SetUp]
		public void SetUp()
		{
			SetupPresenterAndMocks();
		}
		
		[Test]
		public void Should_return_correct_title()
		{
			Presenter.GetTitle().ShouldBe("Speakers");
		}
	}
}