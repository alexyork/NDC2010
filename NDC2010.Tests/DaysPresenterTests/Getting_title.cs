using System;
using NUnit.Framework;

namespace NDC2010.Tests.DaysPresenterTests
{
	[TestFixture]
	public class Getting_title : DaysPresenterTestBase
	{
		[SetUp]
		public void SetUp()
		{
			SetupPresenterAndMocks();
		}
		
		[Test]
		public void Should_return_correct_number_of_rows()
		{
			Presenter.GetTitle().ShouldBe("Select day");
		}
	}
}