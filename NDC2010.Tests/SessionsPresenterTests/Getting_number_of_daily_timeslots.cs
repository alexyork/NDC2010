using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NDC2010.Model;
using NDC2010.Logic.Presenters;

namespace NDC2010.Tests.SessionsPresenterTests
{
	[TestFixture]
	public class Getting_number_of_daily_timeslots : SessionsPresenterTestBase
	{
		[Test]
		public void Should_contain_7_timeslots_for_day_1()
		{
			SetupPresenterForDay(1);
			Presenter.GetNumberOfDailyTimeslots().ShouldBe(7);
		}
		
		[Test]
		public void Should_contain_7_timeslots_for_day_2()
		{
			SetupPresenterForDay(2);
			Presenter.GetNumberOfDailyTimeslots().ShouldBe(7);
		}
		
		[Test]
		public void Should_contain_6_timeslots_for_day_3()
		{
			SetupPresenterForDay(3);
			Presenter.GetNumberOfDailyTimeslots().ShouldBe(6);
		}
	}
}