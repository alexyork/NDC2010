using System;
using NDC2010.Logic.Presenters;
using NUnit.Framework;

namespace NDC2010.Tests.SessionsPresenterTests
{
	[TestFixture]
	public class Getting_title : SessionsPresenterTestBase
	{
		[Test]
		public void Should_return_correct_title_for_day_1()
		{
			SetupPresenterForDay(1);
			
			Presenter.GetTitle().ShouldContain("Day 1");
		}
		
		[Test]
		public void Should_return_correct_title_for_day_2()
		{
			SetupPresenterForDay(2);
			
			Presenter.GetTitle().ShouldContain("Day 2");
		}
		
		[Test]
		public void Should_return_correct_title_for_day_3()
		{
			SetupPresenterForDay(3);
			
			Presenter.GetTitle().ShouldContain("Day 3");
		}
	}
}