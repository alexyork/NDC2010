using System;
using System.Linq;
using NUnit.Framework;

namespace NDC2010.Tests.SpeakerPresenterTests
{
	[TestFixture]
	public class Getting_title : SpeakerPresenterTestBase
	{
		[SetUp]
		public void SetUp()
		{
			SetupPresenterAndMocks();
		}
		
		[Test]
		public void Should_return_correct_title()
		{
			Presenter.GetTitle().ShouldBe("Speaker");
		}
	}
}