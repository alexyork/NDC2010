using System;
using NUnit.Framework;

namespace NDC2010.Tests.SessionsPresenterTests
{
	[TestFixture]
	public class Getting_title : SessionsPresenterTestBase
	{
		[SetUp]
		public void SetUp()
		{
			SetupPresenterAndMocks();
		}
		
		[Test]
		public void Should_return_correct_title_for_day_1()
		{
			Presenter.Day = 1;
			Presenter.GetTitle().ShouldBe("Sessions, Day 1");
		}
		
		[Test]
		public void Should_return_correct_title_for_day_2()
		{
			Presenter.Day = 2;
			Presenter.GetTitle().ShouldBe("Sessions, Day 2");
		}
		
		[Test]
		public void Should_return_correct_title_for_day_3()
		{
			Presenter.Day = 3;
			Presenter.GetTitle().ShouldBe("Sessions, Day 3");
		}
	}
}